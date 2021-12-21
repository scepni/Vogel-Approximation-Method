
namespace optimizasyon_test
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
            this.fabrika_input = new System.Windows.Forms.TextBox();
            this.sehir_input = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fabrika_input
            // 
            this.fabrika_input.Location = new System.Drawing.Point(12, 52);
            this.fabrika_input.Multiline = true;
            this.fabrika_input.Name = "fabrika_input";
            this.fabrika_input.Size = new System.Drawing.Size(212, 45);
            this.fabrika_input.TabIndex = 0;
            this.fabrika_input.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fabrika_input.TextChanged += new System.EventHandler(this.fabrika_input_TextChanged);
            this.fabrika_input.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fabrika_input_KeyPress);
            // 
            // sehir_input
            // 
            this.sehir_input.Location = new System.Drawing.Point(248, 52);
            this.sehir_input.Multiline = true;
            this.sehir_input.Name = "sehir_input";
            this.sehir_input.Size = new System.Drawing.Size(197, 45);
            this.sehir_input.TabIndex = 1;
            this.sehir_input.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sehir_input.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sehir_input_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fabrika Sayısını Giriniz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(248, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "Şehir Sayısını Giriniz";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(150, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 71);
            this.button1.TabIndex = 4;
            this.button1.Text = "Oluştur";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 218);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sehir_input);
            this.Controls.Add(this.fabrika_input);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vogel\'s Approximation Method";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox fabrika_input;
        public System.Windows.Forms.TextBox sehir_input;
    }
}

