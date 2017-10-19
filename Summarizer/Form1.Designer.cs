namespace Summarizer
{
    partial class Form1
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
            this.lblAmountSentences = new System.Windows.Forms.Label();
            this.grpSentOrPerc = new System.Windows.Forms.GroupBox();
            this.radSentences = new System.Windows.Forms.RadioButton();
            this.radPercentage = new System.Windows.Forms.RadioButton();
            this.rtxtInput = new System.Windows.Forms.RichTextBox();
            this.btnSummarize = new System.Windows.Forms.Button();
            this.txtNumInput = new System.Windows.Forms.TextBox();
            this.rtxtOutput = new System.Windows.Forms.RichTextBox();
            this.grpSentOrPerc.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAmountSentences
            // 
            this.lblAmountSentences.AutoSize = true;
            this.lblAmountSentences.Location = new System.Drawing.Point(451, 9);
            this.lblAmountSentences.Name = "lblAmountSentences";
            this.lblAmountSentences.Size = new System.Drawing.Size(113, 13);
            this.lblAmountSentences.TabIndex = 0;
            this.lblAmountSentences.Text = "Amount of sentences: ";
            // 
            // grpSentOrPerc
            // 
            this.grpSentOrPerc.Controls.Add(this.radPercentage);
            this.grpSentOrPerc.Controls.Add(this.radSentences);
            this.grpSentOrPerc.Location = new System.Drawing.Point(454, 25);
            this.grpSentOrPerc.Name = "grpSentOrPerc";
            this.grpSentOrPerc.Size = new System.Drawing.Size(110, 69);
            this.grpSentOrPerc.TabIndex = 1;
            this.grpSentOrPerc.TabStop = false;
            this.grpSentOrPerc.Text = "Cut down by";
            // 
            // radSentences
            // 
            this.radSentences.AutoSize = true;
            this.radSentences.Location = new System.Drawing.Point(6, 19);
            this.radSentences.Name = "radSentences";
            this.radSentences.Size = new System.Drawing.Size(76, 17);
            this.radSentences.TabIndex = 0;
            this.radSentences.TabStop = true;
            this.radSentences.Text = "Sentences";
            this.radSentences.UseVisualStyleBackColor = true;
            // 
            // radPercentage
            // 
            this.radPercentage.AutoSize = true;
            this.radPercentage.Location = new System.Drawing.Point(6, 42);
            this.radPercentage.Name = "radPercentage";
            this.radPercentage.Size = new System.Drawing.Size(80, 17);
            this.radPercentage.TabIndex = 1;
            this.radPercentage.TabStop = true;
            this.radPercentage.Text = "Percentage";
            this.radPercentage.UseVisualStyleBackColor = true;
            // 
            // rtxtInput
            // 
            this.rtxtInput.Location = new System.Drawing.Point(12, 12);
            this.rtxtInput.Name = "rtxtInput";
            this.rtxtInput.Size = new System.Drawing.Size(433, 327);
            this.rtxtInput.TabIndex = 2;
            this.rtxtInput.Text = "";
            // 
            // btnSummarize
            // 
            this.btnSummarize.Location = new System.Drawing.Point(454, 128);
            this.btnSummarize.Name = "btnSummarize";
            this.btnSummarize.Size = new System.Drawing.Size(110, 23);
            this.btnSummarize.TabIndex = 4;
            this.btnSummarize.Text = "Summarize";
            this.btnSummarize.UseVisualStyleBackColor = true;
            this.btnSummarize.Click += new System.EventHandler(this.btnSummarize_Click);
            // 
            // txtNumInput
            // 
            this.txtNumInput.Location = new System.Drawing.Point(454, 100);
            this.txtNumInput.Name = "txtNumInput";
            this.txtNumInput.Size = new System.Drawing.Size(110, 20);
            this.txtNumInput.TabIndex = 5;
            // 
            // rtxtOutput
            // 
            this.rtxtOutput.Location = new System.Drawing.Point(13, 346);
            this.rtxtOutput.Name = "rtxtOutput";
            this.rtxtOutput.ReadOnly = true;
            this.rtxtOutput.Size = new System.Drawing.Size(432, 184);
            this.rtxtOutput.TabIndex = 6;
            this.rtxtOutput.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 542);
            this.Controls.Add(this.rtxtOutput);
            this.Controls.Add(this.txtNumInput);
            this.Controls.Add(this.btnSummarize);
            this.Controls.Add(this.rtxtInput);
            this.Controls.Add(this.grpSentOrPerc);
            this.Controls.Add(this.lblAmountSentences);
            this.Name = "Form1";
            this.Text = "Form1";
            this.grpSentOrPerc.ResumeLayout(false);
            this.grpSentOrPerc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAmountSentences;
        private System.Windows.Forms.GroupBox grpSentOrPerc;
        private System.Windows.Forms.RadioButton radPercentage;
        private System.Windows.Forms.RadioButton radSentences;
        private System.Windows.Forms.RichTextBox rtxtInput;
        private System.Windows.Forms.Button btnSummarize;
        private System.Windows.Forms.TextBox txtNumInput;
        private System.Windows.Forms.RichTextBox rtxtOutput;
    }
}

