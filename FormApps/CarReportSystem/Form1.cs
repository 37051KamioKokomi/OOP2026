using System.ComponentModel;
using System.Drawing.Text;
using static CarReportSystem.CarReport;

namespace CarReportSystem {

    public partial class Form1 : Form {

        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        public Form1() {

            InitializeComponent();
            dgvRecords.DataSource = listCarReports;
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        //追加ボタンイベントハンドラ
        private void btAddRecord_Click(object sender, EventArgs e) {

            tsslbMessage.Text = string.Empty; //メッセージ領域のクリア

            /***************************************************/
            //記録者と社名が未入力だった場合は追加しない
            if (string.IsNullOrWhiteSpace(cbAuthor.Text) || string.IsNullOrWhiteSpace(cbCarName.Text)) {
                tsslbMessage.Text = "記録者、または車名が未入力です。";
                return;
            }

            var carReport = new CarReport {
                Date = dtpDate.Value,
                Author = cbAuthor.Text.Trim(),
                Maker = getRadioButtonMaker(),
                CarName = cbCarName.Text.Trim(),
                Report = tbReport.Text,
                Picture = pbPicture.Image
            };
            listCarReports.Add(carReport);
            /***************************************************/
            //入力履歴を登録
            setCbAuther(cbAuthor.Text.Trim()); //////////////////////
            setCbCarName(cbCarName.Text.Trim());

            dgvRecords.CurrentRow.Selected = false; //セルの選択を解除する
            dgvRecords.ClearSelection();
            InputItemsAllClear(); //入力項目の全クリア

        }

        private MakerGroup getRadioButtonMaker() {
            if (rbToyota.Checked)
                return MakerGroup.トヨタ;
            if (rbNissan.Checked)
                return MakerGroup.ニッサン;
            if (rbHonda.Checked)
                return MakerGroup.ホンダ;
            if (rbSubaru.Checked)
                return MakerGroup.スバル;
            if (rbImport.Checked)
                return MakerGroup.輸入車;
            return MakerGroup.その他;

        }

        private void btOpenPicture_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }

        private void btNewInput_Click(object sender, EventArgs e) {
            InputItemsAllClear();
        }

        private void InputItemsAllClear() {
            dtpDate.Value = DateTime.Now;
            cbAuthor.Text = string.Empty;
            cbCarName.Text = string.Empty;
            rbOther.Checked = true;
            tbReport.Text = string.Empty;
            pbPicture.Image = null;

            dgvRecords.CurrentRow.Selected = false; //セルの選択を解除する
            dgvRecords.ClearSelection();
        }

       

        private void SetRadioButtonMaker(MakerGroup targetMaker) {
            //targetMaker = getRadioButtonMaker();
            //targetMaker = dgvRecords.CurrentRow.Cells[CarReport.MakerGroup].Value;
            switch (targetMaker) {
                case MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case MakerGroup.ニッサン:
                    rbNissan.Checked = true;
                    break;
                case MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case MakerGroup.輸入車:
                    rbImport.Checked = true;
                    break;
                default:
                    rbOther.Checked = true;
                    break;
            }
        }

        //記録者の入力履歴をコンボボックスへ登録(重複なし)
        private void setCbAuther(string auther) {
            //使用するキーワード
            //Contains Add Items cbAuther

            //if (cbAuthor Contains Items) {
            //    cbAuthor Add Items
            //}
            //foreach(var Items in auther) {

            //}
            if (!cbAuthor.Items.Contains(auther))
                cbAuthor.Items.Add(auther);


        }

        //車名の入力履歴コンボボックスへ登録(重複なし)
        private void setCbCarName(string carname) {
            if (!cbCarName.Items.Contains(carname))
                cbCarName.Items.Add(carname);
        }

        private void btDeletePicture_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void btDeleteRecord_Click(object sender, EventArgs e) {

            if ((dgvRecords.CurrentRow is null) || (!dgvRecords.CurrentRow.Selected)) return;

            //選択されているインデックスを取得
            //削除したいインデックスを指定してリストから削除
            //RemoveAt(消したい場所の要素番号)
            listCarReports.RemoveAt(dgvRecords.CurrentRow.Index);

            InputItemsUpdate();//データグリッドビューを更新したら呼ぶメソッド
        }

        //データグリッドビューを更新したら呼ぶメソッド
        private void InputItemsUpdate() {
            if (!dgvRecords.CurrentRow.Selected)
                InputItemsAllClear();
        }

        private void btModifyRecord_Click(object sender, EventArgs e) {

            if(dgvRecords.SelectedRows.Count == 0) {
                tsslbMessage.Text = "修正するレポートを選択してください";
                return;
            }

            if (string.IsNullOrWhiteSpace(cbAuthor.Text) || string.IsNullOrWhiteSpace(cbCarName.Text)) {
                tsslbMessage.Text = "記録者、または車名が未入力です。";
                return;
            }

            //カーレポート管理用リストの該当する要素データを書き換える
            listCarReports[dgvRecords.CurrentRow.Index].Date = dtpDate.Value;
            listCarReports[dgvRecords.CurrentRow.Index].Author = cbAuthor.Text.Trim();
            listCarReports[dgvRecords.CurrentRow.Index].Maker = getRadioButtonMaker();
            listCarReports[dgvRecords.CurrentRow.Index].CarName = cbCarName.Text.Trim();
            listCarReports[dgvRecords.CurrentRow.Index].Report = tbReport.Text;
            listCarReports[dgvRecords.CurrentRow.Index].Picture = pbPicture.Image;

            setCbAuther(cbAuthor.Text.Trim());
            setCbCarName(cbCarName.Text.Trim());

            dgvRecords.Refresh(); //データグリッドビューの更新
            tsslbMessage.Text = "レポートを修正しました！";
        }

        private void dgvRecords_SelectionChanged(object sender, EventArgs e) {

            if ((dgvRecords.CurrentRow?.DataBoundItem is not CarReport carReport) || (!dgvRecords.CurrentRow.Selected)) return;


            dtpDate.Value = carReport.Date;
            cbAuthor.Text = carReport.Author;
            SetRadioButtonMaker(carReport.Maker);
            cbCarName.Text = carReport.CarName;
            tbReport.Text = carReport.Report;
            pbPicture.Image = carReport.Picture;

            InputItemsUpdate();
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {

            var previewPanel = new Panel() {
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Location = new Point(20, 70),
                Size = new Size(360, 80)

            };


            cbColor.AllowFullOpen = true;
            cbColor.FullOpen = true;
            cbColor.AnyColor = true;
            cbColor.SolidColorOnly = true;

            var result = cbColor.ShowDialog(this);
            if (result == DialogResult.OK) {
                BackColor = cbColor.Color;
            }
        }
    }
}
