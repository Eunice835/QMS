namespace Register
{
    partial class Feedback
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            dgFeedback = new Guna.UI2.WinForms.Guna2DataGridView();
            Description = new DataGridViewTextBoxColumn();
            Rating = new DataGridViewTextBoxColumn();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgFeedback).BeginInit();
            SuspendLayout();
            // 
            // dgFeedback
            // 
            dataGridViewCellStyle4.BackColor = Color.White;
            dgFeedback.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgFeedback.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgFeedback.ColumnHeadersHeight = 22;
            dgFeedback.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgFeedback.Columns.AddRange(new DataGridViewColumn[] { Description, Rating });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgFeedback.DefaultCellStyle = dataGridViewCellStyle6;
            dgFeedback.GridColor = Color.FromArgb(231, 229, 255);
            dgFeedback.Location = new Point(158, 123);
            dgFeedback.Name = "dgFeedback";
            dgFeedback.RowHeadersVisible = false;
            dgFeedback.RowHeadersWidth = 51;
            dgFeedback.Size = new Size(483, 234);
            dgFeedback.TabIndex = 0;
            dgFeedback.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgFeedback.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgFeedback.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgFeedback.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgFeedback.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgFeedback.ThemeStyle.BackColor = Color.White;
            dgFeedback.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgFeedback.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgFeedback.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgFeedback.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgFeedback.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgFeedback.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgFeedback.ThemeStyle.HeaderStyle.Height = 22;
            dgFeedback.ThemeStyle.ReadOnly = false;
            dgFeedback.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgFeedback.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgFeedback.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgFeedback.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgFeedback.ThemeStyle.RowsStyle.Height = 29;
            dgFeedback.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgFeedback.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // Description
            // 
            Description.HeaderText = "Description";
            Description.MinimumWidth = 6;
            Description.Name = "Description";
            // 
            // Rating
            // 
            Rating.HeaderText = "Rating";
            Rating.MinimumWidth = 6;
            Rating.Name = "Rating";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(317, 45);
            label1.Name = "label1";
            label1.Size = new Size(151, 41);
            label1.TabIndex = 1;
            label1.Text = "Feedback";
            // 
            // Feedback
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Navy;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(dgFeedback);
            Name = "Feedback";
            Text = "Feedback";
            ((System.ComponentModel.ISupportInitialize)dgFeedback).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgFeedback;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Rating;
        private Label label1;
    }
}