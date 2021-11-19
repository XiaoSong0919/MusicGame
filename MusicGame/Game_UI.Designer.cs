
namespace MusicGame
{
    partial class Game_UI
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
            this.break1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tap1 = new System.Windows.Forms.Button();
            this.hold1 = new System.Windows.Forms.Button();
            this.two_tap1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // break1
            // 
            this.break1.BackColor = System.Drawing.Color.Red;
            this.break1.FlatAppearance.BorderSize = 0;
            this.break1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.break1.Location = new System.Drawing.Point(528, 226);
            this.break1.Margin = new System.Windows.Forms.Padding(1);
            this.break1.Name = "break1";
            this.break1.Size = new System.Drawing.Size(80, 8);
            this.break1.TabIndex = 0;
            this.break1.UseVisualStyleBackColor = false;
            this.break1.Click += new System.EventHandler(this.break1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(707, 222);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // tap1
            // 
            this.tap1.BackColor = System.Drawing.Color.Black;
            this.tap1.FlatAppearance.BorderSize = 0;
            this.tap1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tap1.Location = new System.Drawing.Point(528, 204);
            this.tap1.Margin = new System.Windows.Forms.Padding(1);
            this.tap1.Name = "tap1";
            this.tap1.Size = new System.Drawing.Size(80, 8);
            this.tap1.TabIndex = 9;
            this.tap1.UseVisualStyleBackColor = false;
            // 
            // hold1
            // 
            this.hold1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.hold1.FlatAppearance.BorderSize = 0;
            this.hold1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hold1.Location = new System.Drawing.Point(528, 250);
            this.hold1.Margin = new System.Windows.Forms.Padding(1);
            this.hold1.Name = "hold1";
            this.hold1.Size = new System.Drawing.Size(80, 8);
            this.hold1.TabIndex = 10;
            this.hold1.UseVisualStyleBackColor = false;
            // 
            // two_tap1
            // 
            this.two_tap1.BackColor = System.Drawing.Color.Gold;
            this.two_tap1.FlatAppearance.BorderSize = 0;
            this.two_tap1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.two_tap1.Location = new System.Drawing.Point(528, 274);
            this.two_tap1.Margin = new System.Windows.Forms.Padding(1);
            this.two_tap1.Name = "two_tap1";
            this.two_tap1.Size = new System.Drawing.Size(80, 8);
            this.two_tap1.TabIndex = 11;
            this.two_tap1.UseVisualStyleBackColor = false;
            // 
            // Game_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.two_tap1);
            this.Controls.Add(this.hold1);
            this.Controls.Add(this.tap1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.break1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Game_UI";
            this.Text = "Game_UI";
            this.Load += new System.EventHandler(this.Game_UI_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_UI_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Game_UI_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button break1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button tap1;
        private System.Windows.Forms.Button hold1;
        private System.Windows.Forms.Button two_tap1;
    }
}