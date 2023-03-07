using System;
using System.Windows.Forms;
using Markdig;

namespace winGPT;
public partial class Form1 : Form
{



    private TextBox textBoxDown;
    private Button buttonSend;



    public Form1()
    {
        {
            InitializeComponent();

            // Create buttons and set their proper·ties
            Button buttonUp = new Button();
            buttonUp.Location = new Point(this.ClientSize.Width / 2 - buttonUp.Size.Width / 2, 0);
            buttonUp.Text = "上";
            this.Controls.Add(buttonUp);

            textBoxDown = new TextBox();
            textBoxDown.Location = new Point(this.ClientSize.Width / 2 - textBoxDown.Size.Width / 2, this.ClientSize.Height - textBoxDown.Size.Height);
            this.Controls.Add(textBoxDown);



            buttonSend = new Button();
            buttonSend.Location = new Point(textBoxDown.Right + 10, textBoxDown.Top);
            buttonSend.Text = "发送";

            this.buttonSend.Click += new EventHandler(buttonSend_Click!);

        }

    }
    private void buttonSend_Click(object sender, EventArgs e)
    {
        Console.WriteLine(this.textBoxDown.Text);
        this.textBoxDown.Clear();
    }
}
//我想要在上方建一个很大的区域，用于显示我每一次点击send后发送的内容。


// public partial class Form1 : Form
// {
//     public enum BotType { Auto, Paragraph, Email, Blog, Ideas, Outline, QA };
//     public enum Tone { Friendly, Professional, Polite };
//     public enum BotLength { Auto, Short, Medium, Long };

//     private BotType selectedBotType = BotType.Auto;
//     private Tone selectedTone = Tone.Friendly;
//     private BotLength selectedBotLength = BotLength.Auto;

//     public Form1()
//     {

//         InitializeComponent();
//     }
//     private void Form1_Load(object sender, EventArgs e)
//     {
//         TextBox inputTextBox = new TextBox();
//         inputTextBox.Dock = DockStyle.Bottom;
//         inputTextBox.Height = this.Height / 2;
//         this.Controls.Add(inputTextBox);

//         Button sendButton = new Button();
//         sendButton.Text = "Send";
//         sendButton.Click += SendButton_Click;
//         this.Controls.Add(sendButton);
//     }

//     private void SendButton_Click(object sender, EventArgs e)
//     {
//         TextBox inputTextBox = this.Controls.OfType<TextBox>().SingleOrDefault(x => x.Dock == DockStyle.Bottom);
//         Console.WriteLine(inputTextBox.Text);
//         inputTextBox.Text = "";
//     }
//     private void UpdateSelectedBotType(BotType botType)
//     {
//         if (selectedBotType != botType)
//         {
//             if (MessageBox.Show("是否舍弃当前对话进度？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
//             {
//                 selectedBotType = botType;
//             }
//         }
//     }
//     private void MainForm_MouseClick(object sender, MouseEventArgs e)
//     {
//         //弹出消息框，并获取消息框的返回值
//         DialogResult dr = MessageBox.Show("是否打开新窗体？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
//         //如果消息框返回值是Yes，显示新窗体
//         if (dr == DialogResult.Yes)
//         {
//             MessageForm messageForm = new MessageForm();
//             messageForm.Show();
//         }
//         //如果消息框返回值是No，关闭当前窗体
//         else if (dr == DialogResult.No)
//         {
//             //关闭当前窗体
//             this.Close();
//         }
//     }

//     private void UpdateSelectedTone(Tone tone)
//     {
//         if (selectedTone != tone)
//         {
//             if (MessageBox.Show("是否舍弃当前对话进度？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
//             {
//                 selectedTone = tone;
//             }
//         }
//     }

//     private void UpdateSelectedBotLength(BotLength botLength)
//     {
//         if (selectedBotLength != botLength)
//         {
//             if (MessageBox.Show("是否舍弃当前对话进度？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
//             {
//                 selectedBotLength = botLength;
//             }
//         }
//     }

//     private void AutoBtn_Click(object sender, EventArgs e)
//     {
//         UpdateSelectedBotType(BotType.Auto);
//     }

//     private void ParagraphBtn_Click(object sender, EventArgs e)
//     {
//         UpdateSelectedBotType(BotType.Paragraph);
//     }

//     private void EmailBtn_Click(object sender, EventArgs e)
//     {
//         UpdateSelectedBotType(BotType.Email);
//     }

//     private void BlogBtn_Click(object sender, EventArgs e)
//     {
//         UpdateSelectedBotType(BotType.Blog);
//     }

//     private void IdeasBtn_Click(object sender, EventArgs e)
//     {
//         UpdateSelectedBotType(BotType.Ideas);
//     }

//     private void OutlineBtn_Click(object sender, EventArgs e)
//     {
//         UpdateSelectedBotType(BotType.Outline);
//     }

//     private void QABtn_Click(object sender, EventArgs e)
//     {
//         UpdateSelectedBotType(BotType.QA);
//     }

//     private void FriendlyBtn_Click(object sender, EventArgs e)
//     {
//         UpdateSelectedTone(Tone.Friendly);
//     }

//     private void ProfessionalBtn_Click(object sender, EventArgs e)
//     {
//         UpdateSelectedTone(Tone.Professional);
//     }

//     private void PoliteBtn_Click(object sender, EventArgs e)
//     {
//         UpdateSelectedTone(Tone.Polite);
//     }

//     private void ShortBtn_Click(object sender, EventArgs e)
//     {
//         UpdateSelectedBotLength(BotLength.Short);
//     }

//     private void MediumBtn_Click(object sender, EventArgs e)
//     {
//         UpdateSelectedBotLength(BotLength.Medium);
//     }

//     private void LongBtn_Click(object sender, EventArgs e)
//     {
//         UpdateSelectedBotLength(BotLength.Long);
//     }
// }
