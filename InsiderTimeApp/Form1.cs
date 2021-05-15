using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsiderTimeApp
{
    public partial class Form1 : Form
    {
        // 経過時間(回答)
        int timeLeftForAnswer;
        // 議論時間
        int discussTime;
        // 経過時間(議論)
        int timeLeftForDiscuss;
        // スタートフラグ(回答)
        bool startFlgForAnswer;
        // スタートフラグ(議論)
        bool startFlgForDiscuss;

        // 回答時間(初期値)
        const int DEFAULT_ANS_TIME = 300;
        // 回答時間設定値
        int ansTime;
        // 議論タイム
        const int DEFULT_DESICUSS_TIME = 0;
        // 秒フォーマット
        const string TIME_FORMAT = @"hh\:mm\:ss";

        public Form1()
        {
            InitializeComponent();

            ansTime = DEFAULT_ANS_TIME;

            initializeValue();
        }

        private void odaiStart_Click(object sender, EventArgs e)
        {
            startFlgForAnswer = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (startFlgForAnswer)
            {
                timeLeftForAnswer += 1;
                label1.Text = new TimeSpan(0, 0, ansTime - timeLeftForAnswer).ToString(TIME_FORMAT);
                if (ansTime - timeLeftForAnswer == 0)
                {
                    startFlgForAnswer = false;
                    // 0秒になったらアラート表示
                    MessageBox.Show("お題あて終了！", "答えにたどり着きましたか？");
                }
            }

            if (startFlgForDiscuss)
            {
                timeLeftForDiscuss += 1;
                label2.Text = new TimeSpan(0, 0, discussTime - timeLeftForDiscuss).ToString(TIME_FORMAT);

                if (discussTime - timeLeftForDiscuss == 0)
                {
                    startFlgForDiscuss = false;
                    // 0秒になったらアラート表示
                    MessageBox.Show("議論時間終了！", "インサイダーはだれ？");
                }

            }
        }

        // rest
        private void reset_Click(object sender, EventArgs e)
        {
            initializeValue();
        }

        private void odaiStop_Click(object sender, EventArgs e)
        {
            startFlgForAnswer = false;
        }

        private void transfer_Click(object sender, EventArgs e)
        {
            // 議論時間を格納
            discussTime = timeLeftForAnswer;
            // ラベル更新
            label2.Text = new TimeSpan(0, 0, discussTime).ToString(TIME_FORMAT);
        }

        private void initializeValue()
        {
            // 変数初期化
            timeLeftForAnswer = 0;
            timeLeftForDiscuss = 0;
            discussTime = 0;
            startFlgForAnswer = false;
            startFlgForDiscuss = false;

            // コンポーネントの値を初期化
            label1.Text = new TimeSpan(0, 0, ansTime).ToString(TIME_FORMAT);
            label2.Text = new TimeSpan(0, 0, DEFULT_DESICUSS_TIME).ToString(TIME_FORMAT);
        }

        private void gironStart_Click(object sender, EventArgs e)
        {
            startFlgForDiscuss = true;
        }

        private void gironStop_Click(object sender, EventArgs e)
        {
            startFlgForDiscuss = false;
        }

        private void aply_Click(object sender, EventArgs e)
        {

            // int型に変換
            int i;
            if (int.TryParse(odaiByou.Text, out i))
            {
                ansTime = i;
                initializeValue();
            }
            else
            {
                Console.WriteLine("数値に変換できません");
            }

        }
    }
}
