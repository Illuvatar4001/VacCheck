namespace VacCheck
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
            this.loaddumps = new System.Windows.Forms.Button();
            this.vacs = new System.Windows.Forms.Button();
            this.settings = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loaddumps
            // 
            this.loaddumps.Location = new System.Drawing.Point(12, 12);
            this.loaddumps.Name = "loaddumps";
            this.loaddumps.Size = new System.Drawing.Size(168, 60);
            this.loaddumps.TabIndex = 0;
            this.loaddumps.Text = "Load new dumps";
            this.loaddumps.UseVisualStyleBackColor = true;
            // 
            // vacs
            // 
            this.vacs.Location = new System.Drawing.Point(186, 12);
            this.vacs.Name = "vacs";
            this.vacs.Size = new System.Drawing.Size(168, 60);
            this.vacs.TabIndex = 1;
            this.vacs.Text = "Inspect Bans";
            this.vacs.UseVisualStyleBackColor = true;
            // 
            // settings
            // 
            this.settings.Location = new System.Drawing.Point(360, 12);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(168, 60);
            this.settings.TabIndex = 2;
            this.settings.Text = "Settings";
            this.settings.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 60);
            this.button1.TabIndex = 3;
            this.button1.Text = "DILDOS";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 183);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.settings);
            this.Controls.Add(this.vacs);
            this.Controls.Add(this.loaddumps);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loaddumps;
        private System.Windows.Forms.Button vacs;
        private System.Windows.Forms.Button settings;
        private System.Windows.Forms.Button button1;
    }
}

