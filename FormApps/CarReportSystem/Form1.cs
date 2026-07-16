using System.ComponentModel;
using static CarReportSystem.CarReport;

namespace CarReportSystem {

    public partial class Form1 : Form {

        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        public Form1() {

            InitializeComponent();
            dgvRecords.DataSource = listCarReports;
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
                Author = cbAuthor.Text,
                Maker = getRadioButtonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image
            };
            listCarReports.Add(carReport);

            /***************************************************/

            ImputItemsAllClear();

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
            ImputItemsAllClear();
        }

        private void ImputItemsAllClear() {
            dtpDate.Value = DateTime.Now;
            cbAuthor.Text = string.Empty;
            cbCarName.Text = string.Empty;
            rbOther.Checked = true;
            tbReport.Text = string.Empty;
            pbPicture.Image = null;
        }

        private void dgvRecords_Click(object sender, EventArgs e) {
            dtpDate.Value = (DateTime)dgvRecords.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvRecords.CurrentRow.Cells["Author"].Value;
            //groupBox1 = ;
            cbCarName.Text = (string)dgvRecords.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvRecords.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvRecords.CurrentRow.Cells["Picture"].Value;
                
        }
    }
}
