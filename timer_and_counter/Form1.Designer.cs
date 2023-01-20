namespace timer_and_counter
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxTimerDecision = new System.Windows.Forms.TextBox();
            this.textBoxSubmitted = new System.Windows.Forms.TextBox();
            this.textBoxSkipped = new System.Windows.Forms.TextBox();
            this.textBoxAdt = new System.Windows.Forms.TextBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonSkip = new System.Windows.Forms.Button();
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxTimerDecision
            // 
            this.textBoxTimerDecision.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTimerDecision.Location = new System.Drawing.Point(7, 82);
            this.textBoxTimerDecision.Name = "textBoxTimerDecision";
            this.textBoxTimerDecision.Size = new System.Drawing.Size(90, 32);
            this.textBoxTimerDecision.TabIndex = 15;
            this.textBoxTimerDecision.Text = "00:00:00";
            this.textBoxTimerDecision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxTimerDecision.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTimerDecision_KeyDown);
            this.textBoxTimerDecision.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxTimerDecision_MouseDoubleClick);
            // 
            // textBoxSubmitted
            // 
            this.textBoxSubmitted.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSubmitted.Location = new System.Drawing.Point(103, 82);
            this.textBoxSubmitted.Name = "textBoxSubmitted";
            this.textBoxSubmitted.Size = new System.Drawing.Size(44, 32);
            this.textBoxSubmitted.TabIndex = 17;
            this.textBoxSubmitted.Text = "000";
            this.textBoxSubmitted.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxSubmitted.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSubmitted_KeyDown);
            // 
            // textBoxSkipped
            // 
            this.textBoxSkipped.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSkipped.Location = new System.Drawing.Point(103, 44);
            this.textBoxSkipped.Name = "textBoxSkipped";
            this.textBoxSkipped.Size = new System.Drawing.Size(43, 32);
            this.textBoxSkipped.TabIndex = 18;
            this.textBoxSkipped.Text = "000";
            this.textBoxSkipped.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxSkipped.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSkipped_KeyDown);
            // 
            // textBoxAdt
            // 
            this.textBoxAdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAdt.Location = new System.Drawing.Point(7, 44);
            this.textBoxAdt.Name = "textBoxAdt";
            this.textBoxAdt.Size = new System.Drawing.Size(90, 32);
            this.textBoxAdt.TabIndex = 19;
            this.textBoxAdt.Text = "00.00";
            this.textBoxAdt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonReset.BackgroundImage = global::timer_and_counter.Properties.Resources.reset_icon;
            this.buttonReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.Location = new System.Drawing.Point(47, 8);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(34, 32);
            this.buttonReset.TabIndex = 7;
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSubmit.BackgroundImage = global::timer_and_counter.Properties.Resources.submiticon;
            this.buttonSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmit.Location = new System.Drawing.Point(153, 82);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(34, 32);
            this.buttonSubmit.TabIndex = 6;
            this.buttonSubmit.UseVisualStyleBackColor = false;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonSkip
            // 
            this.buttonSkip.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSkip.BackgroundImage = global::timer_and_counter.Properties.Resources.skip_icon;
            this.buttonSkip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSkip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSkip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSkip.Location = new System.Drawing.Point(153, 44);
            this.buttonSkip.Name = "buttonSkip";
            this.buttonSkip.Size = new System.Drawing.Size(34, 32);
            this.buttonSkip.TabIndex = 5;
            this.buttonSkip.UseVisualStyleBackColor = false;
            this.buttonSkip.Click += new System.EventHandler(this.buttonSkip_Click);
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonStartStop.BackgroundImage = global::timer_and_counter.Properties.Resources.play_icon;
            this.buttonStartStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonStartStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStartStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartStop.Location = new System.Drawing.Point(7, 8);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(34, 32);
            this.buttonStartStop.TabIndex = 0;
            this.buttonStartStop.UseVisualStyleBackColor = false;
            this.buttonStartStop.Click += new System.EventHandler(this.buttonStartStop_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(159, 8);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(28, 13);
            this.labelVersion.TabIndex = 20;
            this.labelVersion.Text = "v0.0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(197, 117);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.textBoxAdt);
            this.Controls.Add(this.textBoxSkipped);
            this.Controls.Add(this.textBoxSubmitted);
            this.Controls.Add(this.textBoxTimerDecision);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.buttonSkip);
            this.Controls.Add(this.buttonStartStop);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ADT Tracker";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartStop;
        private System.Windows.Forms.Button buttonSkip;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.TextBox textBoxTimerDecision;
        private System.Windows.Forms.TextBox textBoxSubmitted;
        private System.Windows.Forms.TextBox textBoxSkipped;
        private System.Windows.Forms.TextBox textBoxAdt;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelVersion;
    }
}

