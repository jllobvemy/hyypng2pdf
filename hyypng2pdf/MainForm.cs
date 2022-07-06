using System.Text.RegularExpressions;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;


namespace hyypng2pdf
{
    public static class MyExtensions
    {
        public static IEnumerable<string> CustomSort(this IEnumerable<string> list)
        {
            int maxLen = list.Select(s => s.Length).Max();

            return list.Select(s => new
            {
                OrgStr = s,
                SortStr = Regex.Replace(s, @"(\d+)|(\D+)", m => m.Value.PadLeft(maxLen, char.IsDigit(m.Value[0]) ? ' ' : '\xffff'))
            })
            .OrderBy(x => x.SortStr)
            .Select(x => x.OrgStr);
        }

    }

    public partial class MainForm : Form
    {
        Document? document;
        Stream documentStream;
        public MainForm()
        {
            InitializeComponent();
            documentStream = new MemoryStream();
        }
        private void selectFolderButton_Click(object sender, EventArgs e)
        {
            var selectFolederDialog = new FolderBrowserDialog();

            selectFolederDialog.RootFolder = Environment.SpecialFolder.Desktop;
            var result = selectFolederDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                selectedFolderPath.Text = selectFolederDialog.SelectedPath;
            }
        }
        delegate void SetTextCallback(string text);
        delegate void PerformStepCallback();

        private void SetText(string text)
        {
            if (statusLabel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                Invoke(d, new object[] { text });
            }
            else
            {
                statusLabel.Text = text;
            }
        }

        private void PerformStep()
        {
            if (progressBar.InvokeRequired)
            {
                PerformStepCallback d = new PerformStepCallback(PerformStep);
                Invoke(d, new object[] { });
            }
            else
            {
                progressBar.PerformStep();
            }

        }
        private void generateButton_Click(object sender, EventArgs e)
        {
            IEnumerable<string> files;
            int pageNum = 0;
            try
            {
                files = (from file in System.IO.Directory.EnumerateFiles(selectedFolderPath.Text)
                         where file.EndsWith(".png")
                         select file).CustomSort();
                pageNum = files.Count();
            }
            catch
            {
                MessageBox.Show("先选择文件夹哦。", "出错啦", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            progressBar.Minimum = 0;
            progressBar.Maximum = files.Count();
            document = Document.Create(container =>
            {
                foreach (var file in files)
                {
                    string filename = Path.GetFileName(file);
                    PerformStep();
                    SetText(filename);
                    Image currentImage = Image.FromFile(file);
                    ImageConverter converter = new();
                    var imageBytes = (byte[]?)converter.ConvertTo(currentImage, typeof(byte[]));
                    if (imageBytes == null)
                        continue;
                    pageNum++;
                    float ImageWidth = currentImage.Width;
                    float ImageHeight = currentImage.Height;
                    container.Page(page =>
                    {
                        page.Size(ImageWidth, ImageHeight, Unit.Point);
                        page.Content().Image(imageBytes, ImageScaling.FitArea);
                    });
                }
            });
            if (pageNum > 0)
            {
                var task = new Task(() => {
                    document.GeneratePdf(documentStream);
                });
                task.Start();
                task.ContinueWith(back => {
                    saveButton.Enabled = true;
                });
            }
            else
            {
                MessageBox.Show("没有PNG选中（没有可以转换的文件）", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "PDF Files|*.pdf";
            dialog.FileName = "笨蛋.pdf";
            var resault = dialog.ShowDialog();
            if (resault == DialogResult.OK)
            {
                var file = File.Create(dialog.FileName);
                documentStream.Seek(0, SeekOrigin.Begin);
                documentStream.CopyTo(file);
                documentStream.Close();
                file.Close();
            }
            else
            {
                MessageBox.Show("文件未成功保存", "通知", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //private void selectFolderButton_Click(object sender, EventArgs e)
        //{

        //}

        //private void generateButton_Click(object sender, EventArgs e)
        //{

        //}

        //private void saveButton_Click(object sender, EventArgs e)
        //{

        //}
    }
}