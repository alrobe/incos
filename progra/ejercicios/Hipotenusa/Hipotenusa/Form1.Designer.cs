namespace Hipotenusa
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxCatA = new TextBox();
            textBoxCatB = new TextBox();
            labelRes = new Label();
            buttonCalculate = new Button();
            SuspendLayout();
            // 
            // textBoxCatA
            // 
            textBoxCatA.Location = new Point(219, 59);
            textBoxCatA.Name = "textBoxCatA";
            textBoxCatA.Size = new Size(100, 23);
            textBoxCatA.TabIndex = 0;
            // 
            // textBoxCatB
            // 
            textBoxCatB.Location = new Point(219, 107);
            textBoxCatB.Name = "textBoxCatB";
            textBoxCatB.Size = new Size(100, 23);
            textBoxCatB.TabIndex = 1;
            // 
            // labelRes
            // 
            labelRes.AutoSize = true;
            labelRes.Location = new Point(223, 155);
            labelRes.Name = "labelRes";
            labelRes.Size = new Size(38, 15);
            labelRes.TabIndex = 2;
            labelRes.Text = "label1";
            // 
            // buttonCalculate
            // 
            buttonCalculate.Location = new Point(226, 196);
            buttonCalculate.Name = "buttonCalculate";
            buttonCalculate.Size = new Size(75, 23);
            buttonCalculate.TabIndex = 3;
            buttonCalculate.Text = "Calcular";
            buttonCalculate.UseVisualStyleBackColor = true;
            buttonCalculate.Click += buttonCalculate_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonCalculate);
            Controls.Add(labelRes);
            Controls.Add(textBoxCatB);
            Controls.Add(textBoxCatA);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxCatA;
        private TextBox textBoxCatB;
        private Label labelRes;
        private Button buttonCalculate;
    }
}
