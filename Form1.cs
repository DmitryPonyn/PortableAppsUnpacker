using SevenZip;
using System;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Compression;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace PortableAppsUnpacker
{
    public partial class Form1 : Form
    {
        #region Visual
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        internal static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        [DllImport("user32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        internal extern static bool PostMessage(IntPtr hWnd, uint Msg, uint WParam);
        [DllImport("user32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        internal extern static bool ReleaseCapture();
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var linGrBrush = new LinearGradientBrush(
               ClientRectangle,
               Color.Empty,
               Color.Empty,   // Opaque red
               65);  // Opaque blue
            var cblend = new ColorBlend { Colors = new[] { Color.FromArgb(70, 101, 240), Color.FromArgb(146, 67, 242), Color.FromArgb(150, 43, 157) }, Positions = new[] { 0, 0.5f, 1 } };
            linGrBrush.InterpolationColors = cblend;
            Rectangle myRectangle = new Rectangle(0, 0, Width, Height);
            e.Graphics.FillRectangle(linGrBrush, myRectangle);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            PostMessage(Handle, 0x0112, 0xF012);
        }
        private void PathToUnpackPortable_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.InitialDirectory = "C:\\PortableSoft";
                dialog.ShowDialog();
                PathToUnpackPortable.Text = dialog.SelectedPath;
            }
        }
        public Form1()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
            Lang();
        }
        private void Lang()
        {
            PathToUnpackPortable.Text = Languages.Lang("SelectPath");
            StartUnpack.Text = Languages.Lang("Unpack");
            TotalProgress_Lb.Text = Languages.Lang("AllProgress");
            AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking");
        }
        private bool UnpackInProcess = false;
        private void Exit_B_Click(object sender, EventArgs e)
        {
            if (!UnpackInProcess) Application.Exit();
        }
        #endregion
        #region Paths To 7Z archives soft
        private readonly Dictionary<string, string> ProgramPath = new()
        {
            ["Z7"] = "Programs\\Archivers\\7-Zip.7z",
            ["WinRAR"] = "Programs\\Archivers\\WinRAR.7z",
            ["Convert_VMDK2VHD"] = "Programs\\VHD\\Convert_VMDK2VHD.7z",
            ["EmsisoftEmergencyKit"] = "Programs\\Security\\EmsisoftEmergencyKit.7z",
            ["Far"] = "Programs\\FileManager\\Far.7z",
            ["NotepadPlusPlus"] = "Programs\\TextEditor\\Notepad++.7z",
            ["LibreOffice"] = "Programs\\Office\\LibreOffice.7z",
            ["Pichon"] = "Programs\\Icons\\Pichon.7z",
            ["IcoFX"] = "Programs\\Icons\\IcoFX.7z",
            ["Monero"] = "Programs\\Crypto\\Monero.7z",
            ["Litecoin"] = "Programs\\Crypto\\Litecoin.7z",
            ["AIMP"] = "Programs\\Audio\\AIMP.7z",
            ["Adobe_Photoshop"] = "Programs\\PhotoEditor\\Adobe_Photoshop.7z",
            ["Adobe_Illustrator"] = "Programs\\Icons\\Adobe_Illustrator.7z",
            ["After_Effects"] = "Programs\\VideoEditor\\After_Effects.7z",
            ["AntRenamer"] = "Programs\\Utilities\\AntRenamer.7z",
            ["Everything"] = "Programs\\FileFind\\Everything.7z",
            ["VeraCrypt"] = "Programs\\Encryption\\VeraCrypt.7z",
            ["Eraser"] = "Programs\\Security\\Eraser.7z",
            ["VLC"] = "Programs\\Video\\VLC.7z",
            ["OBS"] = "Programs\\Video\\OBS.7z",
            ["Audacity"] = "Programs\\AudioEditor\\Audacity.7z",
            ["HandBrake"] = "Programs\\Converter\\HandBrake.7z",
            ["GoogleChrome"] = "Programs\\Browser\\GoogleChrome.7z",
            ["Firefox"] = "Programs\\Browser\\Firefox.7z",
            ["On_ScreenKeyboard"] = "Programs\\Special\\On-ScreenKeyboard.7z",
            ["Telegram"] = "Programs\\Communication\\Telegram.7z",
            ["WinSCP"] = "Programs\\Network\\WinSCP.7z",
            ["Bitcoin_Core"] = "Programs\\Crypto\\Bitcoin_Core.7z",
            ["SumatraPDF"] = "Programs\\Office\\SumatraPDF.7z",
            ["ProcessHacker"] = "Programs\\Utilities\\ProcessHacker.7z",
            ["Ventoy"] = "Programs\\Utilities\\Ventoy.7z",
            ["WinDirStat"] = "Programs\\FileFind\\WinDirStat.7z",
            ["XnView"] = "Programs\\Photo\\XnView.7z",
            ["CapFrameX"] = "Programs\\Test\\CapFrameX.7z",
            ["Microsoft_Office_2007"] = "Programs\\Office\\Microsoft_Office_2007.7z",
            ["Volume2"] = "Programs\\Visual\\Volume2.7z",
            ["K4VideoDownloader"] = "Programs\\Network\\4KVideoDownloader.7z",
            ["K4YouTubetoMP3"] = "Programs\\Converter\\4KYouTubetoMP3.7z",
            ["Bandicam"] = "Programs\\Video\\Bandicam.7z",
            ["Anime_Studio_Pro_11"] = "Programs\\Animate\\Anime_Studio_Pro_11.7z",
            ["Punto_Switcher"] = "Programs\\TextEditor\\Punto_Switcher.7z",
            ["Quick_Batch_File_Compiler"] = "Programs\\Converter\\Quick_Batch_File_Compiler.7z",
            ["Resources_Extract"] = "Programs\\Utilities\\Resources_Extract.7z",
            ["Rainmeter"] = "Programs\\Visual\\Rainmeter.7z",
            ["MyLanViewer"] = "Programs\\Network\\MyLanViewer.7z",
            ["Boilsoft_Video_Joiner"] = "Programs\\VideoEditor\\Boilsoft_Video_Joiner.7z",
            ["R_Drive_Image"] = "Programs\\VHD\\R_Drive_Image.7z",
            ["Stable_diffusion"] = "Programs\\Stable_diffusion.7z.001",
            ["ExtremeCopy"] = "Programs\\FileManager\\ExtremeCopy.7z",
            ["Adobe_Animate"] = "Programs\\Animate\\Adobe_Animate.7z",
            ["Spotify"] = "Programs\\Audio\\Spotify.7z",
            ["Discord"] = "Programs\\Communication\\Discord.7z",
            ["Tor_Browser"] = "Programs\\Browser\\Tor_Browser.7z",
            ["Movavi_Video_Editor_Plus"] = "Programs\\VideoEditor\\Movavi_Video_Editor_Plus.7z",
            ["Smart_Defrag"] = "Programs\\VHD\\Smart_Defrag.7z",
            ["Wallpaper_Engine"] = "Programs\\Visual\\Wallpaper_Engine.7z",
            ["EZ_CD_Audio_Converter"] = "Programs\\Converter\\EZ_CD_Audio_Converter.7z",
            ["VEGAS_Pro_17"] = "Programs\\VideoEditor\\VEGAS_Pro_17.7z",
            ["FormatFactory"] = "Programs\\Converter\\FormatFactory.7z",
            ["UltraISO"] = "Programs\\ISO\\UltraISO.7z",
            ["Watermark_Remover"] = "Programs\\Utilities\\Watermark_Remover.7z",
            ["Magnifyingglass"] = "Programs\\Special\\Magnifyingglass.7z",
            ["IObit_Unlocker"] = "Programs\\Utilities\\IObit_Unlocker.7z",
            ["winhex"] = "Programs\\Utilities\\winhex.7z",
            ["Psiphon"] = "Programs\\Network\\Psiphon.7z",
            ["ShareX"] = "Programs\\Photo\\ShareX.7z",
            ["qBittorrent"] = "Programs\\Network\\qBittorrent.7z",
            ["Air_Explorer_Pro"] = "Programs\\Network\\Air_Explorer_Pro.7z",
            ["Resource_Hacker"] = "Programs\\Utilities\\Resource_Hacker.7z",
            ["CentBrowser"] = "Programs\\Browser\\CentBrowser.7z",
            ["Maxthon"] = "Programs\\Browser\\Maxthon.7z",
            ["VHDManager"] = "Programs\\VHD\\VHDManager.7z",
            ["Regshot"] = "Programs\\Registry\\Regshot.7z",
            ["FreeArc"] = "Programs\\Archivers\\FreeArc.7z",
        };
        #endregion
        private void StartUnpack_Click(object sender, EventArgs e)
        {
            if (PathToUnpackPortable.Text == Languages.Lang("SelectPath"))
            {
                MessageBox.Show(Languages.Lang("SelectPathPojalusta"));
                return;
            }
            TotalProgress_Pb.Maximum = Controls.OfType<CheckBox>().Where(chk => chk.Checked).Count();
            PathToUnpackPortable.Enabled = false;
            UnpackInProcess = true;
            Controls.OfType<CheckBox>().Where((chk) => chk.Checked).ToList().ForEach(x => {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + x.Text;
                Task.Run(() => Tsk(ProgramPath[x.Name])).Wait();
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                x.Checked = false;
            });
            MessageBox.Show(Languages.Lang("Unpacked"));
            AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking");
            CurrentArchive.Value = 0;
            TotalProgress_Pb.Value = 0;
            UnpackInProcess = false;
            PathToUnpackPortable.Enabled = true;
        }
        #region Unpack Task
        private Task Tsk(string pthToArc)
        {
            SevenZipBase.SetLibraryPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "x64", "7z.dll"));
            using (SevenZipExtractor file = new SevenZipExtractor(pthToArc))
            {
                file.Extracting += (sender, args) => CurrentArchive.Value = args.PercentDone;
                file.ExtractArchive(PathToUnpackPortable.Text);
            }
            CurrentArchive.Value = 0;
            return Task.CompletedTask;
        }
        #endregion
    }
}