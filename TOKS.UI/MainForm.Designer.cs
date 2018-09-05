namespace TOKS.UI
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.currentPortLabel = new System.Windows.Forms.Label();
            this.baudrateLabel = new System.Windows.Forms.Label();
            this.dataBitsLabel = new System.Windows.Forms.Label();
            this.stopBitsLabel = new System.Windows.Forms.Label();
            this.parityLabel = new System.Windows.Forms.Label();
            this.baudrateComboBox = new System.Windows.Forms.ComboBox();
            this.dataBitsComboBox = new System.Windows.Forms.ComboBox();
            this.stopBitsComboBox = new System.Windows.Forms.ComboBox();
            this.parityComboBox = new System.Windows.Forms.ComboBox();
            this.currentPortComboBox = new System.Windows.Forms.ComboBox();
            this.startStopButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.symbolsTypedLabel = new System.Windows.Forms.Label();
            this.recieved = new System.Windows.Forms.Label();
            this.symbolsRecievedLabel = new System.Windows.Forms.Label();
            this.clearBtn = new System.Windows.Forms.Button();
            this.symbols = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.7384F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(658, 280);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel4.Controls.Add(this.currentPortLabel, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.baudrateLabel, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.dataBitsLabel, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.stopBitsLabel, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.parityLabel, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.baudrateComboBox, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.dataBitsComboBox, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.stopBitsComboBox, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.parityComboBox, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.currentPortComboBox, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.startStopButton, 0, 5);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(332, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.354838F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.032258F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.032258F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.709678F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.032258F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.12903F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(323, 274);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // currentPortLabel
            // 
            this.currentPortLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentPortLabel.AutoSize = true;
            this.currentPortLabel.Location = new System.Drawing.Point(3, 0);
            this.currentPortLabel.Name = "currentPortLabel";
            this.currentPortLabel.Size = new System.Drawing.Size(139, 25);
            this.currentPortLabel.TabIndex = 0;
            this.currentPortLabel.Text = "Current port";
            this.currentPortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // baudrateLabel
            // 
            this.baudrateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.baudrateLabel.AutoSize = true;
            this.baudrateLabel.Location = new System.Drawing.Point(3, 25);
            this.baudrateLabel.Name = "baudrateLabel";
            this.baudrateLabel.Size = new System.Drawing.Size(139, 24);
            this.baudrateLabel.TabIndex = 0;
            this.baudrateLabel.Text = "Baudrate";
            this.baudrateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataBitsLabel
            // 
            this.dataBitsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataBitsLabel.AutoSize = true;
            this.dataBitsLabel.Location = new System.Drawing.Point(3, 49);
            this.dataBitsLabel.Name = "dataBitsLabel";
            this.dataBitsLabel.Size = new System.Drawing.Size(139, 24);
            this.dataBitsLabel.TabIndex = 0;
            this.dataBitsLabel.Text = "Data bits";
            this.dataBitsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stopBitsLabel
            // 
            this.stopBitsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stopBitsLabel.AutoSize = true;
            this.stopBitsLabel.Location = new System.Drawing.Point(3, 73);
            this.stopBitsLabel.Name = "stopBitsLabel";
            this.stopBitsLabel.Size = new System.Drawing.Size(139, 23);
            this.stopBitsLabel.TabIndex = 0;
            this.stopBitsLabel.Text = "Stop bits";
            this.stopBitsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // parityLabel
            // 
            this.parityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parityLabel.AutoSize = true;
            this.parityLabel.Location = new System.Drawing.Point(3, 96);
            this.parityLabel.Name = "parityLabel";
            this.parityLabel.Size = new System.Drawing.Size(139, 24);
            this.parityLabel.TabIndex = 0;
            this.parityLabel.Text = "Parity";
            this.parityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // baudrateComboBox
            // 
            this.baudrateComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.baudrateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baudrateComboBox.FormattingEnabled = true;
            this.baudrateComboBox.Location = new System.Drawing.Point(148, 28);
            this.baudrateComboBox.Name = "baudrateComboBox";
            this.baudrateComboBox.Size = new System.Drawing.Size(172, 21);
            this.baudrateComboBox.TabIndex = 1;
            // 
            // dataBitsComboBox
            // 
            this.dataBitsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataBitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataBitsComboBox.FormattingEnabled = true;
            this.dataBitsComboBox.Location = new System.Drawing.Point(148, 52);
            this.dataBitsComboBox.Name = "dataBitsComboBox";
            this.dataBitsComboBox.Size = new System.Drawing.Size(172, 21);
            this.dataBitsComboBox.TabIndex = 1;
            // 
            // stopBitsComboBox
            // 
            this.stopBitsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stopBitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stopBitsComboBox.FormattingEnabled = true;
            this.stopBitsComboBox.Location = new System.Drawing.Point(148, 76);
            this.stopBitsComboBox.Name = "stopBitsComboBox";
            this.stopBitsComboBox.Size = new System.Drawing.Size(172, 21);
            this.stopBitsComboBox.TabIndex = 1;
            // 
            // parityComboBox
            // 
            this.parityComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.parityComboBox.FormattingEnabled = true;
            this.parityComboBox.Location = new System.Drawing.Point(148, 99);
            this.parityComboBox.Name = "parityComboBox";
            this.parityComboBox.Size = new System.Drawing.Size(172, 21);
            this.parityComboBox.TabIndex = 1;
            // 
            // currentPortComboBox
            // 
            this.currentPortComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentPortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.currentPortComboBox.FormattingEnabled = true;
            this.currentPortComboBox.Location = new System.Drawing.Point(148, 3);
            this.currentPortComboBox.Name = "currentPortComboBox";
            this.currentPortComboBox.Size = new System.Drawing.Size(172, 21);
            this.currentPortComboBox.TabIndex = 1;
            // 
            // startStopButton
            // 
            this.startStopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.SetColumnSpan(this.startStopButton, 2);
            this.startStopButton.Location = new System.Drawing.Point(3, 235);
            this.startStopButton.Margin = new System.Windows.Forms.Padding(3, 115, 3, 13);
            this.startStopButton.Name = "startStopButton";
            this.startStopButton.Size = new System.Drawing.Size(317, 26);
            this.startStopButton.TabIndex = 0;
            this.startStopButton.Text = "Start";
            this.startStopButton.UseVisualStyleBackColor = true;
            this.startStopButton.Click += new System.EventHandler(this.startStopButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel2.Controls.Add(this.outputTextBox, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.inputTextBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.sendBtn, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.symbolsTypedLabel, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.symbols, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.recieved, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.symbolsRecievedLabel, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.clearBtn, 2, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(323, 274);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.outputTextBox, 3);
            this.outputTextBox.Location = new System.Drawing.Point(3, 135);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputTextBox.Size = new System.Drawing.Size(317, 94);
            this.outputTextBox.TabIndex = 1;
            this.outputTextBox.WordWrap = false;
            this.outputTextBox.TextChanged += new System.EventHandler(this.outputTextBox_TextChanged);
            // 
            // inputTextBox
            // 
            this.inputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.inputTextBox, 3);
            this.inputTextBox.Enabled = false;
            this.inputTextBox.Location = new System.Drawing.Point(3, 3);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(317, 94);
            this.inputTextBox.TabIndex = 1;
            this.inputTextBox.TextChanged += new System.EventHandler(this.inputTextBox_TextChanged);
            // 
            // sendBtn
            // 
            this.sendBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sendBtn.Location = new System.Drawing.Point(243, 103);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(77, 26);
            this.sendBtn.TabIndex = 4;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // symbolsTypedLabel
            // 
            this.symbolsTypedLabel.AutoSize = true;
            this.symbolsTypedLabel.Location = new System.Drawing.Point(102, 100);
            this.symbolsTypedLabel.Name = "symbolsTypedLabel";
            this.symbolsTypedLabel.Size = new System.Drawing.Size(13, 13);
            this.symbolsTypedLabel.TabIndex = 6;
            this.symbolsTypedLabel.Text = "0";
            // 
            // recieved
            // 
            this.recieved.AutoSize = true;
            this.recieved.Location = new System.Drawing.Point(3, 232);
            this.recieved.Name = "recieved";
            this.recieved.Size = new System.Drawing.Size(93, 13);
            this.recieved.TabIndex = 8;
            this.recieved.Text = "Symbols recieved:";
            this.recieved.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // symbolsRecievedLabel
            // 
            this.symbolsRecievedLabel.AutoSize = true;
            this.symbolsRecievedLabel.Location = new System.Drawing.Point(102, 232);
            this.symbolsRecievedLabel.Name = "symbolsRecievedLabel";
            this.symbolsRecievedLabel.Size = new System.Drawing.Size(13, 13);
            this.symbolsRecievedLabel.TabIndex = 7;
            this.symbolsRecievedLabel.Text = "0";
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(243, 235);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(77, 26);
            this.clearBtn.TabIndex = 9;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // symbols
            // 
            this.symbols.AutoSize = true;
            this.symbols.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.symbols.Location = new System.Drawing.Point(3, 100);
            this.symbols.Name = "symbols";
            this.symbols.Size = new System.Drawing.Size(81, 13);
            this.symbols.TabIndex = 5;
            this.symbols.Text = "Symbols typed: ";
            this.symbols.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 298);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainWindow";
            this.Text = "Serial port communicator";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button startStopButton;
        private System.Windows.Forms.Label currentPortLabel;
        private System.Windows.Forms.ComboBox currentPortComboBox;
        private System.Windows.Forms.Label baudrateLabel;
        private System.Windows.Forms.Label dataBitsLabel;
        private System.Windows.Forms.Label stopBitsLabel;
        private System.Windows.Forms.Label parityLabel;
        private System.Windows.Forms.ComboBox baudrateComboBox;
        private System.Windows.Forms.ComboBox dataBitsComboBox;
        private System.Windows.Forms.ComboBox stopBitsComboBox;
        private System.Windows.Forms.ComboBox parityComboBox;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.Label symbols;
        private System.Windows.Forms.Label symbolsTypedLabel;
        private System.Windows.Forms.Label symbolsRecievedLabel;
        private System.Windows.Forms.Label recieved;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Button clearBtn;
    }
}

