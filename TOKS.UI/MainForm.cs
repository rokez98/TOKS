using System;
using System.IO.Ports;
using System.Windows.Forms;
using TOKS.SerialPortCommunicator.Core;
using TOKS.SerialPortCommunicator.Enums;
using TOKS.SerialPortCommunicator.Interfaces;
using TOKS.SerialPortCommunicator.Models;
using TOKS.UI.Extensions;

namespace TOKS.UI
{
    public partial class MainWindow : Form
    {
        private readonly SerialPortCommunicator.Core.SerialPortCommunicator _serialPortCommunicator;

        public MainWindow()
        {
            InitializeComponent();

            IMessageCoder coder = new BaseCoder();

            _serialPortCommunicator = new SerialPortCommunicator.Core.SerialPortCommunicator(coder);

            baudrateComboBox.InitializeWithEnum(typeof(EBaudRate), item => (int)item, selectedIndex: 1);
            dataBitsComboBox.InitializeWithEnum(typeof(EDataBits), item => (int)item, selectedIndex: 3);
            parityComboBox.InitializeWithEnum(typeof(Parity), item => item, selectedIndex: 0);
            stopBitsComboBox.InitializeWithEnum(typeof(StopBits), item => item, selectedIndex: 1);

            RefreshView();

            FormClosed += (sender, e) => _serialPortCommunicator.Close();
            currentPortComboBox.DropDown += (sender, args) => { RefreshPortsList(); };
        }

        private void RefreshPortsList()
        {
            currentPortComboBox.Items.Clear();

            foreach (var port in SerialPort.GetPortNames())
                currentPortComboBox.Items.Add(port);
        }

        private void OpenSerialPort()
        {
            var serialPortConfig = new SerialPortConfig()
            {
                PortName = (string)currentPortComboBox.SelectedItem,
                BaudRate = (EBaudRate)baudrateComboBox.SelectedItem,
                Parity = (Parity)parityComboBox.SelectedItem,
                DataBits = (EDataBits)dataBitsComboBox.SelectedItem,
                StopBits = (StopBits)stopBitsComboBox.SelectedItem
            };

            _serialPortCommunicator._portId = Convert.ToByte(SenderAddress.Value);

            try
            {
                _serialPortCommunicator.Open(serialPortConfig, OnMessageRecieved, OnErrorRecieved);
            }
            catch (Exception ex)
            {
                ShowErrorBox($"Cannot open selected port with selected configuration: {ex.Message}");
                _serialPortCommunicator.Close();
            }
        }

        private void CloseSerialPort()
        {
            _serialPortCommunicator.Close();
        }

        public void OnMessageRecieved(object sender, EventArgs args)
        {
            try
            {
                var message = _serialPortCommunicator.Read();
                Invoke((MethodInvoker) delegate { outputTextBox.AppendText(message); });
            }
            catch (Exception ex)
            {
                ShowErrorBox(ex.Message);
            }
        }

        public void OnErrorRecieved(object sender, EventArgs args)
        {
            ShowErrorBox("An exception occured!");
        }

        private void startStopButton_Click(object sender, EventArgs e)
        {
            if (_serialPortCommunicator.IsOpen)
                CloseSerialPort();
            else
                OpenSerialPort();

            RefreshView();
        }

        private void RefreshView()
        {
            var isStarted = _serialPortCommunicator.IsOpen;

            currentPortComboBox.Enabled = !isStarted;
            baudrateComboBox.Enabled = !isStarted;
            dataBitsComboBox.Enabled = !isStarted;
            stopBitsComboBox.Enabled = !isStarted;
            parityComboBox.Enabled = !isStarted;
            SenderAddress.Enabled = !isStarted;

            inputTextBox.Enabled = isStarted;

            startStopButton.Text = (isStarted ? "Stop" : "Start");
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            outputTextBox.Clear();
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (inputTextBox.Text != string.Empty)
                {
                    var destinationAddress = Convert.ToByte(DestinationAdress.Value);
                    _serialPortCommunicator.Send(inputTextBox.Text, destinationAddress);
                }
                inputTextBox.Clear();
            }
            catch (Exception ex)
            {
                ShowErrorBox($"Cannot write to port : {ex.Message}");
            }
        }

        private void inputTextBox_TextChanged(object sender, EventArgs e) => symbolsTypedLabel.Text = inputTextBox.Text.Length.ToString();

        private void outputTextBox_TextChanged(object sender, EventArgs e) => symbolsRecievedLabel.Text = outputTextBox.Text.Length.ToString();

        private void ShowErrorBox(string errorText) => MessageBox.Show(errorText, @"Oops, we have an error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}