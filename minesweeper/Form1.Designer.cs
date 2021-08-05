
namespace minesweeper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.grpTime = new System.Windows.Forms.GroupBox();
            this.grpTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.SystemColors.Window;
            this.txtResult.Enabled = false;
            this.txtResult.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtResult.Location = new System.Drawing.Point(6, 22);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(69, 29);
            this.txtResult.TabIndex = 1;
            this.txtResult.Text = "00:00:00";
            this.txtResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(342, 841);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(115, 38);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Reset";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // grpTime
            // 
            this.grpTime.Controls.Add(this.txtResult);
            this.grpTime.Location = new System.Drawing.Point(12, 821);
            this.grpTime.Name = "grpTime";
            this.grpTime.Size = new System.Drawing.Size(80, 58);
            this.grpTime.TabIndex = 3;
            this.grpTime.TabStop = false;
            this.grpTime.Text = "Time";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 891);
            this.Controls.Add(this.grpTime);
            this.Controls.Add(this.btnStop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Minesweeper [Beta]";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpTime.ResumeLayout(false);
            this.grpTime.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox grpTime;
    }
}

