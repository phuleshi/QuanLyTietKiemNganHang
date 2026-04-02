using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTietKiemNganHang.Helpers
{
    public static class ControlFactory
    {
        public static readonly Color PrimaryColor = Color.FromArgb(37, 99, 235);
        public static readonly Color SecondaryColor = Color.FromArgb(15, 23, 42);
        public static readonly Color BackgroundColor = Color.FromArgb(243, 246, 251);
        public static readonly Color SurfaceColor = Color.White;
        public static readonly Color BorderColor = Color.FromArgb(226, 232, 240);
        public static readonly Color TextColor = Color.FromArgb(30, 41, 59);
        public static readonly Color MutedTextColor = Color.FromArgb(100, 116, 139);
        public static readonly Color SuccessColor = Color.FromArgb(22, 163, 74);
        public static readonly Color WarningColor = Color.FromArgb(245, 158, 11);
        public static readonly Color DangerColor = Color.FromArgb(220, 38, 38);

        public static Panel CreateCard(string title, string value, Color accent)
        {
            var panel = new Panel
            {
                Width = 240,
                Height = 118,
                BackColor = SurfaceColor,
                Margin = new Padding(0, 0, 18, 18),
                Padding = new Padding(18),
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Fill
            };

            var accentBar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 6,
                BackColor = accent
            };

            var content = new Panel { Dock = DockStyle.Fill, Padding = new Padding(14, 0, 0, 0), BackColor = SurfaceColor };

            var titleLabel = new Label
            {
                Text = title,
                Dock = DockStyle.Top,
                Height = 34,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = MutedTextColor
            };

            var valueLabel = new Label
            {
                Text = value,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = accent,
                TextAlign = ContentAlignment.MiddleLeft
            };

            content.Controls.Add(valueLabel);
            content.Controls.Add(titleLabel);
            panel.Controls.Add(content);
            panel.Controls.Add(accentBar);
            return panel;
        }

        public static Panel CreateSectionCard(DockStyle dock, Padding padding)
        {
            return new Panel
            {
                Dock = dock,
                BackColor = SurfaceColor,
                Padding = padding,
                BorderStyle = BorderStyle.FixedSingle
            };
        }

        public static Label CreateTitleLabel(string text, int size)
        {
            return new Label
            {
                Text = text,
                AutoSize = true,
                Font = new Font("Segoe UI", size, FontStyle.Bold),
                ForeColor = TextColor
            };
        }

        public static Label CreateMutedLabel(string text)
        {
            return new Label
            {
                Text = text,
                AutoSize = true,
                Font = new Font("Segoe UI", 9),
                ForeColor = MutedTextColor
            };
        }

        public static Label CreateFieldLabel(string text)
        {
            return new Label
            {
                Text = text,
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = TextColor,
                Margin = new Padding(0, 0, 0, 6)
            };
        }

        public static TextBox CreateTextBox()
        {
            return new TextBox
            {
                Font = new Font("Segoe UI", 10),
                Width = 260,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                ForeColor = TextColor
            };
        }

        public static ComboBox CreateComboBox()
        {
            return new ComboBox
            {
                Font = new Font("Segoe UI", 10),
                Width = 260,
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat
            };
        }

        public static DateTimePicker CreateDateTimePicker()
        {
            return new DateTimePicker
            {
                Font = new Font("Segoe UI", 10),
                Width = 260,
                Format = DateTimePickerFormat.Short
            };
        }

        public static Button CreatePrimaryButton(string text)
        {
            var button = new Button
            {
                Text = text,
                Width = 120,
                Height = 40,
                BackColor = PrimaryColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            button.FlatAppearance.BorderSize = 0;
            return button;
        }

        public static Button CreateSecondaryButton(string text)
        {
            var button = new Button
            {
                Text = text,
                Width = 120,
                Height = 40,
                BackColor = Color.White,
                ForeColor = PrimaryColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            button.FlatAppearance.BorderColor = BorderColor;
            button.FlatAppearance.BorderSize = 1;
            return button;
        }

        public static Button CreateDangerButton(string text)
        {
            var button = new Button
            {
                Text = text,
                Width = 120,
                Height = 40,
                BackColor = Color.White,
                ForeColor = DangerColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            button.FlatAppearance.BorderColor = Color.FromArgb(254, 202, 202);
            button.FlatAppearance.BorderSize = 1;
            return button;
        }

        public static Button CreateSidebarButton(string text)
        {
            var button = new Button
            {
                Text = text,
                Width = 188,
                Height = 42,
                BackColor = Color.FromArgb(30, 41, 59),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(14, 0, 0, 0)
            };
            button.FlatAppearance.BorderSize = 0;
            return button;
        }

        public static Panel CreateInputGroup(string labelText, Control input)
        {
            var panel = new Panel
            {
                Width = 300,
                Height = 74,
                Margin = new Padding(0, 0, 0, 10),
                BackColor = Color.Transparent
            };

            var label = CreateFieldLabel(labelText);
            label.Location = new Point(0, 0);
            input.Location = new Point(0, 28);
            panel.Controls.Add(label);
            panel.Controls.Add(input);
            return panel;
        }
    }
}
