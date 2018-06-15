namespace ColorIt
{
    partial class HighscoreEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HighscoreEntry));
            this.label1 = new System.Windows.Forms.Label();
            this.txtboxIme = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPoteziBroj = new System.Windows.Forms.Label();
            this.btnUnos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(42, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "IME:";
            // 
            // txtboxIme
            // 
            this.txtboxIme.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtboxIme.Location = new System.Drawing.Point(105, 24);
            this.txtboxIme.Name = "txtboxIme";
            this.txtboxIme.Size = new System.Drawing.Size(100, 30);
            this.txtboxIme.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(2, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "POTEZI:";
            // 
            // lblPoteziBroj
            // 
            this.lblPoteziBroj.AutoSize = true;
            this.lblPoteziBroj.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPoteziBroj.Location = new System.Drawing.Point(143, 64);
            this.lblPoteziBroj.Name = "lblPoteziBroj";
            this.lblPoteziBroj.Size = new System.Drawing.Size(24, 25);
            this.lblPoteziBroj.TabIndex = 3;
            this.lblPoteziBroj.Text = "0";
            // 
            // btnUnos
            // 
            this.btnUnos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUnos.Location = new System.Drawing.Point(92, 98);
            this.btnUnos.Name = "btnUnos";
            this.btnUnos.Size = new System.Drawing.Size(75, 23);
            this.btnUnos.TabIndex = 4;
            this.btnUnos.Text = "OK";
            this.btnUnos.UseVisualStyleBackColor = true;
            this.btnUnos.Click += new System.EventHandler(this.btnUnos_Click);
            // 
            // HighscoreEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 133);
            this.Controls.Add(this.btnUnos);
            this.Controls.Add(this.lblPoteziBroj);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtboxIme);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HighscoreEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Highscore Entry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HighscoreEntry_FormClosing);
            this.Load += new System.EventHandler(this.HighscoreEntry_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtboxIme;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPoteziBroj;
        private System.Windows.Forms.Button btnUnos;
    }
}