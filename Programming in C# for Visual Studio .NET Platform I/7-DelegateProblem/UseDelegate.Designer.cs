namespace DelegateProblem
{
    partial class UseDelegate
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
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.formatButton = new System.Windows.Forms.Button();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.percentRadioButton = new System.Windows.Forms.RadioButton();
            this.dollarRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(32, 35);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(142, 22);
            this.inputTextBox.TabIndex = 0;
            // 
            // formatButton
            // 
            this.formatButton.Location = new System.Drawing.Point(199, 35);
            this.formatButton.Name = "formatButton";
            this.formatButton.Size = new System.Drawing.Size(128, 23);
            this.formatButton.TabIndex = 1;
            this.formatButton.Text = "Format Text";
            this.formatButton.UseVisualStyleBackColor = true;
            this.formatButton.Click += new System.EventHandler(this.formatButton_Click);
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(353, 35);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(131, 22);
            this.outputTextBox.TabIndex = 2;
            // 
            // percentRadioButton
            // 
            this.percentRadioButton.AutoSize = true;
            this.percentRadioButton.Location = new System.Drawing.Point(32, 92);
            this.percentRadioButton.Name = "percentRadioButton";
            this.percentRadioButton.Size = new System.Drawing.Size(168, 21);
            this.percentRadioButton.TabIndex = 3;
            this.percentRadioButton.TabStop = true;
            this.percentRadioButton.Text = "Format as percentage";
            this.percentRadioButton.UseVisualStyleBackColor = true;
            this.percentRadioButton.CheckedChanged += new System.EventHandler(this.percentRadioButton_CheckedChanged);
            // 
            // dollarRadioButton
            // 
            this.dollarRadioButton.AutoSize = true;
            this.dollarRadioButton.Location = new System.Drawing.Point(32, 129);
            this.dollarRadioButton.Name = "dollarRadioButton";
            this.dollarRadioButton.Size = new System.Drawing.Size(182, 21);
            this.dollarRadioButton.TabIndex = 4;
            this.dollarRadioButton.TabStop = true;
            this.dollarRadioButton.Text = "Format as dollar amount";
            this.dollarRadioButton.UseVisualStyleBackColor = true;
            this.dollarRadioButton.CheckedChanged += new System.EventHandler(this.dollarRadioButton_CheckedChanged);
            // 
            // UseDelegate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 218);
            this.Controls.Add(this.dollarRadioButton);
            this.Controls.Add(this.percentRadioButton);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.formatButton);
            this.Controls.Add(this.inputTextBox);
            this.Name = "UseDelegate";
            this.Text = "Use a Delegate";
            this.Load += new System.EventHandler(this.UseDelegate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button formatButton;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.RadioButton percentRadioButton;
        private System.Windows.Forms.RadioButton dollarRadioButton;
    }
}

