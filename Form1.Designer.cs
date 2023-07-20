namespace Snake
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Feld = new System.Windows.Forms.Panel();
            this.tlabel2 = new System.Windows.Forms.Label();
            this.tlabel1 = new System.Windows.Forms.Label();
            this.tlabel0 = new System.Windows.Forms.Label();
            this.Scoreboard = new System.Windows.Forms.Label();
            this.Apfel = new System.Windows.Forms.Panel();
            this.test = new System.Windows.Forms.Label();
            this.Head = new System.Windows.Forms.Panel();
            this.Main = new System.Windows.Forms.Timer(this.components);
            this.Feld.SuspendLayout();
            this.SuspendLayout();
            // 
            // Feld
            // 
            this.Feld.Controls.Add(this.tlabel2);
            this.Feld.Controls.Add(this.tlabel1);
            this.Feld.Controls.Add(this.tlabel0);
            this.Feld.Controls.Add(this.Scoreboard);
            this.Feld.Controls.Add(this.Apfel);
            this.Feld.Controls.Add(this.test);
            this.Feld.Controls.Add(this.Head);
            this.Feld.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Feld.Location = new System.Drawing.Point(0, 0);
            this.Feld.Name = "Feld";
            this.Feld.Size = new System.Drawing.Size(250, 250);
            this.Feld.TabIndex = 0;
            // 
            // tlabel2
            // 
            this.tlabel2.AutoSize = true;
            this.tlabel2.BackColor = System.Drawing.Color.Transparent;
            this.tlabel2.Location = new System.Drawing.Point(156, 90);
            this.tlabel2.Name = "tlabel2";
            this.tlabel2.Size = new System.Drawing.Size(38, 13);
            this.tlabel2.TabIndex = 6;
            this.tlabel2.Text = "tlabel2";
            // 
            // tlabel1
            // 
            this.tlabel1.AutoSize = true;
            this.tlabel1.BackColor = System.Drawing.Color.Transparent;
            this.tlabel1.Location = new System.Drawing.Point(156, 67);
            this.tlabel1.Name = "tlabel1";
            this.tlabel1.Size = new System.Drawing.Size(38, 13);
            this.tlabel1.TabIndex = 5;
            this.tlabel1.Text = "tlabel1";
            // 
            // tlabel0
            // 
            this.tlabel0.AutoSize = true;
            this.tlabel0.BackColor = System.Drawing.Color.Transparent;
            this.tlabel0.Location = new System.Drawing.Point(156, 44);
            this.tlabel0.Name = "tlabel0";
            this.tlabel0.Size = new System.Drawing.Size(38, 13);
            this.tlabel0.TabIndex = 2;
            this.tlabel0.Text = "tlabel0";
            // 
            // Scoreboard
            // 
            this.Scoreboard.AutoSize = true;
            this.Scoreboard.Location = new System.Drawing.Point(181, 11);
            this.Scoreboard.Name = "Scoreboard";
            this.Scoreboard.Size = new System.Drawing.Size(47, 13);
            this.Scoreboard.TabIndex = 4;
            this.Scoreboard.Text = "Score: 0";
            // 
            // Apfel
            // 
            this.Apfel.BackColor = System.Drawing.Color.Red;
            this.Apfel.Location = new System.Drawing.Point(30, 10);
            this.Apfel.Name = "Apfel";
            this.Apfel.Size = new System.Drawing.Size(10, 10);
            this.Apfel.TabIndex = 2;
            // 
            // test
            // 
            this.test.AutoSize = true;
            this.test.Location = new System.Drawing.Point(953, 9);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(35, 13);
            this.test.TabIndex = 1;
            this.test.Text = "label1";
            // 
            // Head
            // 
            this.Head.BackColor = System.Drawing.Color.DarkGreen;
            this.Head.Location = new System.Drawing.Point(10, 10);
            this.Head.Name = "Head";
            this.Head.Size = new System.Drawing.Size(10, 10);
            this.Head.TabIndex = 0;
            // 
            // Main
            // 
            this.Main.Enabled = true;
            this.Main.Interval = 60;
            this.Main.Tick += new System.EventHandler(this.MainTimer);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 250);
            this.Controls.Add(this.Feld);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Drücken);
            this.Feld.ResumeLayout(false);
            this.Feld.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Feld;
        private System.Windows.Forms.Panel Head;
        private System.Windows.Forms.Timer Main;
        private System.Windows.Forms.Panel Apfel;
        private System.Windows.Forms.Label Scoreboard;
        private System.Windows.Forms.Label tlabel0;
        private System.Windows.Forms.Label test;
        private System.Windows.Forms.Label tlabel1;
        private System.Windows.Forms.Label tlabel2;
    }
}

