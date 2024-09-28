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
        bool UnpackInProcess = false;
        private async void StartUnpack_Click(object sender, EventArgs e)
        {
            if (PathToUnpackPortable.Text == Languages.Lang("SelectPath"))
            {
                MessageBox.Show(Languages.Lang("SelectPathPojalusta"));
                return;
            }
            TotalProgress_Pb.Maximum = Controls.OfType<CheckBox>().Where(chk => chk.Checked).Count();
            PathToUnpackPortable.Enabled = false;
            UnpackInProcess = true;
            if (Z7.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Z7.Text;
                await Task.Run(() => Tsk("Programs\\Archivers\\7-Zip.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Z7.Checked = false;
            }
            if (WinRAR.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + WinRAR.Text;
                await Task.Run(() => Tsk("Programs\\Archivers\\WinRAR.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                WinRAR.Checked = false;
            }
            if (Convert_VMDK2VHD.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Convert_VMDK2VHD.Text;
                await Task.Run(() => Tsk("Programs\\VHD\\Convert_VMDK2VHD.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Convert_VMDK2VHD.Checked = false;
            }
            if (Far.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Far.Text;
                await Task.Run(() => Tsk("Programs\\FileManager\\Far.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Far.Checked = false;
            }
            if (NotepadPlusPlus.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + NotepadPlusPlus.Text;
                await Task.Run(() => Tsk("Programs\\TextEditor\\Notepad++.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                NotepadPlusPlus.Checked = false;
            }
            if (LibreOffice.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + LibreOffice.Text;
                await Task.Run(() => Tsk("Programs\\Office\\LibreOffice.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                LibreOffice.Checked = false;
            }
            if (Pichon.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Pichon.Text;
                await Task.Run(() => Tsk("Programs\\Icons\\Pichon.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Pichon.Checked = false;
            }
            if (IcoFX.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + IcoFX.Text;
                await Task.Run(() => Tsk("Programs\\Icons\\IcoFX.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                IcoFX.Checked = false;
            }
            if (Monero.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Monero.Text;
                await Task.Run(() => Tsk("Programs\\Crypto\\Monero.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Monero.Checked = false;
            }
            if (Litecoin.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Litecoin.Text;
                await Task.Run(() => Tsk("Programs\\Crypto\\Litecoin.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Litecoin.Checked = false;
            }
            if (AIMP.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + AIMP.Text;
                await Task.Run(() => Tsk("Programs\\Audio\\AIMP.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                AIMP.Checked = false;
            }
            if (Adobe_Photoshop.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Adobe_Photoshop.Text;
                await Task.Run(() => Tsk("Programs\\PhotoEditor\\Adobe_Photoshop.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Adobe_Photoshop.Checked = false;
            }
            if (Adobe_Illustrator.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Adobe_Illustrator.Text;
                await Task.Run(() => Tsk("Programs\\Icons\\Adobe_Illustrator.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Adobe_Illustrator.Checked = false;
            }
            if (After_Effects.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + After_Effects.Text;
                await Task.Run(() => Tsk("Programs\\VideoEditor\\After_Effects.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                After_Effects.Checked = false;
            }
            if (AntRenamer.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + AntRenamer.Text;
                await Task.Run(() => Tsk("Programs\\Rename\\AntRenamer.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                AntRenamer.Checked = false;
            }
            if (Everything.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Everything.Text;
                await Task.Run(() => Tsk("Programs\\FileFind\\Everything.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Everything.Checked = false;
            }
            if (VeraCrypt.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + VeraCrypt.Text;
                await Task.Run(() => Tsk("Programs\\Encryption\\VeraCrypt.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                VeraCrypt.Checked = false;
            }
            if (Eraser.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Eraser.Text;
                await Task.Run(() => Tsk("Programs\\Security\\Eraser.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Eraser.Checked = false;
            }
            if (VLC.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + VLC.Text;
                await Task.Run(() => Tsk("Programs\\Video\\VLC.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                VLC.Checked = false;
            }
            if (OBS.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + OBS.Text;
                await Task.Run(() => Tsk("Programs\\Video\\OBS.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                OBS.Checked = false;
            }
            if (Audacity.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Audacity.Text;
                await Task.Run(() => Tsk("Programs\\AudioEditor\\Audacity.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Audacity.Checked = false;
            }
            if (HandBrake.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + HandBrake.Text;
                await Task.Run(() => Tsk("Programs\\Converter\\HandBrake.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                HandBrake.Checked = false;
            }
            if (GoogleChrome.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + GoogleChrome.Text;
                await Task.Run(() => Tsk("Programs\\Browser\\GoogleChrome.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                GoogleChrome.Checked = false;
            }
            if (Firefox.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Firefox.Text;
                await Task.Run(() => Tsk("Programs\\Browser\\Firefox.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Firefox.Checked = false;
            }
            if (On_ScreenKeyboard.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + On_ScreenKeyboard.Text;
                await Task.Run(() => Tsk("Programs\\Special\\On-ScreenKeyboard.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                On_ScreenKeyboard.Checked = false;
            }
            if (Telegram.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Telegram.Text;
                await Task.Run(() => Tsk("Programs\\Communication\\Telegram.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Telegram.Checked = false;
            }
            if (WinSCP.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + WinSCP.Text;
                await Task.Run(() => Tsk("Programs\\Network\\WinSCP.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                WinSCP.Checked = false;
            }
            if (Bitcoin_Core.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Bitcoin_Core.Text;
                await Task.Run(() => Tsk("Programs\\Crypto\\Bitcoin_Core.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Bitcoin_Core.Checked = false;
            }
            if (SumatraPDF.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + SumatraPDF.Text;
                await Task.Run(() => Tsk("Programs\\Office\\SumatraPDF.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                SumatraPDF.Checked = false;
            }
            if (EmsisoftEmergencyKit.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + EmsisoftEmergencyKit.Text;
                await Task.Run(() => Tsk("Programs\\Security\\EmsisoftEmergencyKit.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                EmsisoftEmergencyKit.Checked = false;
            }
            if (ProcessHacker.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + ProcessHacker.Text;
                await Task.Run(() => Tsk("Programs\\Utilities\\ProcessHacker.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                ProcessHacker.Checked = false;
            }
            if (Ventoy.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Ventoy.Text;
                await Task.Run(() => Tsk("Programs\\Utilities\\Ventoy.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Ventoy.Checked = false;
            }
            if (WinDirStat.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + WinDirStat.Text;
                await Task.Run(() => Tsk("Programs\\FileFind\\WinDirStat.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                WinDirStat.Checked = false;
            }
            if (XnView.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + XnView.Text;
                await Task.Run(() => Tsk("Programs\\Photo\\XnView.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                XnView.Checked = false;
            }
            if (CapFrameX.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + CapFrameX.Text;
                await Task.Run(() => Tsk("Programs\\Test\\CapFrameX.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                CapFrameX.Checked = false;
            }
            if (Microsoft_Office_2007.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Microsoft_Office_2007.Text;
                await Task.Run(() => Tsk("Programs\\Office\\Microsoft_Office_2007.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Microsoft_Office_2007.Checked = false;
            }
            if (Volume2.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Volume2.Text;
                await Task.Run(() => Tsk("Programs\\Visual\\Volume2.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Volume2.Checked = false;
            }
            if (K4VideoDownloader.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + K4VideoDownloader.Text;
                await Task.Run(() => Tsk("Programs\\Network\\4KVideoDownloader.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                K4VideoDownloader.Checked = false;
            }
            if (K4YouTubetoMP3.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + K4YouTubetoMP3.Text;
                await Task.Run(() => Tsk("Programs\\Converter\\4KYouTubetoMP3.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                K4YouTubetoMP3.Checked = false;
            }
            if (Bandicam.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Bandicam.Text;
                await Task.Run(() => Tsk("Programs\\Video\\Bandicam.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Bandicam.Checked = false;
            }
            if (Anime_Studio_Pro_11.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Anime_Studio_Pro_11.Text;
                await Task.Run(() => Tsk("Programs\\Animate\\Anime_Studio_Pro_11.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Anime_Studio_Pro_11.Checked = false;
            }
            if (Punto_Switcher.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Punto_Switcher.Text;
                await Task.Run(() => Tsk("Programs\\TextEditor\\Punto_Switcher.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Punto_Switcher.Checked = false;
            }
            if (Quick_Batch_File_Compiler.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Quick_Batch_File_Compiler.Text;
                await Task.Run(() => Tsk("Programs\\Converter\\Quick_Batch_File_Compiler.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Quick_Batch_File_Compiler.Checked = false;
            }
            if (Resources_Extract.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Resources_Extract.Text;
                await Task.Run(() => Tsk("Programs\\Utilities\\Resources_Extract.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Resources_Extract.Checked = false;
            }
            if (Rainmeter.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Rainmeter.Text;
                await Task.Run(() => Tsk("Programs\\Visual\\Rainmeter.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Rainmeter.Checked = false;
            }
            if (MyLanViewer.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + MyLanViewer.Text;
                await Task.Run(() => Tsk("Programs\\Network\\MyLanViewer.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                MyLanViewer.Checked = false;
            }
            if (Boilsoft_Video_Joiner.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Boilsoft_Video_Joiner.Text;
                await Task.Run(() => Tsk("Programs\\VideoEditor\\Boilsoft_Video_Joiner.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Boilsoft_Video_Joiner.Checked = false;
            }
            if (R_Drive_Image.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + R_Drive_Image.Text;
                await Task.Run(() => Tsk("Programs\\VHD\\R_Drive_Image.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                R_Drive_Image.Checked = false;
            }
            if (Stable_diffusion.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Stable_diffusion.Text;
                await Task.Run(() => Tsk("Programs\\stable_diffusion.7z.001"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Stable_diffusion.Checked = false;
            }
            if (ExtremeCopy.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + ExtremeCopy.Text;
                await Task.Run(() => Tsk("Programs\\FileManager\\ExtremeCopy.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                ExtremeCopy.Checked = false;
            }
            if (Adobe_Animate.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Adobe_Animate.Text;
                await Task.Run(() => Tsk("Programs\\Animate\\Adobe_Animate.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Adobe_Animate.Checked = false;
            }
            if (Spotify.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Spotify.Text;
                await Task.Run(() => Tsk("Programs\\Audio\\Spotify.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Spotify.Checked = false;
            }
            if (Discord.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Discord.Text;
                await Task.Run(() => Tsk("Programs\\Communication\\Discord.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Discord.Checked = false;
            }
            if (Tor_Browser.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Tor_Browser.Text;
                await Task.Run(() => Tsk("Programs\\Browser\\Tor_Browser.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Tor_Browser.Checked = false;
            }
            if (Movavi_Video_Editor_Plus.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Movavi_Video_Editor_Plus.Text;
                await Task.Run(() => Tsk("Programs\\VideoEditor\\Movavi_Video_Editor_Plus.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Movavi_Video_Editor_Plus.Checked = false;
            }
            if (Smart_Defrag.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Smart_Defrag.Text;
                await Task.Run(() => Tsk("Programs\\VHD\\Smart_Defrag.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Smart_Defrag.Checked = false;
            }
            if (Wallpaper_Engine.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Wallpaper_Engine.Text;
                await Task.Run(() => Tsk("Programs\\Visual\\Wallpaper_Engine.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Wallpaper_Engine.Checked = false;
            }
            if (EZ_CD_Audio_Converter.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + EZ_CD_Audio_Converter.Text;
                await Task.Run(() => Tsk("Programs\\Converter\\EZ_CD_Audio_Converter.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                EZ_CD_Audio_Converter.Checked = false;
            }
            if (VEGAS_Pro_17.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + VEGAS_Pro_17.Text;
                await Task.Run(() => Tsk("Programs\\VideoEditor\\VEGAS_Pro_17.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                VEGAS_Pro_17.Checked = false;
            }
            if (FormatFactory.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + FormatFactory.Text;
                await Task.Run(() => Tsk("Programs\\Converter\\FormatFactory.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                FormatFactory.Checked = false;
            }
            if (UltraISO.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + UltraISO.Text;
                await Task.Run(() => Tsk("Programs\\ISO\\UltraISO.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                UltraISO.Checked = false;
            }
            if (Watermark_Remover.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Watermark_Remover.Text;
                await Task.Run(() => Tsk("Programs\\Utilities\\Watermark_Remover.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Watermark_Remover.Checked = false;
            }
            if (Magnifyingglass.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Magnifyingglass.Text;
                await Task.Run(() => Tsk("Programs\\Special\\Magnifyingglass.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Magnifyingglass.Checked = false;
            }
            if (IObit_Unlocker.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + IObit_Unlocker.Text;
                await Task.Run(() => Tsk("Programs\\Utilities\\IObit_Unlocker.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                IObit_Unlocker.Checked = false;
            }
            if (winhex.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + winhex.Text;
                await Task.Run(() => Tsk("Programs\\Utilities\\winhex.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                winhex.Checked = false;
            }
            if (Psiphon.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Psiphon.Text;
                await Task.Run(() => Tsk("Programs\\Network\\Psiphon.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Psiphon.Checked = false;
            }
            if (ShareX.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + ShareX.Text;
                await Task.Run(() => Tsk("Programs\\Photo\\ShareX.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                ShareX.Checked = false;
            }
            if (qBittorrent.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + qBittorrent.Text;
                await Task.Run(() => Tsk("Programs\\Network\\qBittorrent.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                qBittorrent.Checked = false;
            }
            if (Air_Explorer_Pro.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Air_Explorer_Pro.Text;
                await Task.Run(() => Tsk("Programs\\Network\\Air_Explorer_Pro.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Air_Explorer_Pro.Checked = false;
            }
            if (Resource_Hacker.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Resource_Hacker.Text;
                await Task.Run(() => Tsk("Programs\\Utilities\\Resource_Hacker.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Resource_Hacker.Checked = false;
            }
            if (CentBrowser.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + CentBrowser.Text;
                await Task.Run(() => Tsk("Programs\\Browser\\CentBrowser.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                CentBrowser.Checked = false;
            }
            if (Maxthon.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Maxthon.Text;
                await Task.Run(() => Tsk("Programs\\Browser\\Maxthon.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Maxthon.Checked = false;
            }
            if (VHDManager.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + VHDManager.Text;
                await Task.Run(() => Tsk("Programs\\VHD\\VHDManager.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                VHDManager.Checked = false;
            }
            if (Regshot.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + Regshot.Text;
                await Task.Run(() => Tsk("Programs\\Registry\\Regshot.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                Regshot.Checked = false;
            }
            if (FreeArc.Checked)
            {
                AlreadyUnpacking.Text = Languages.Lang("AlreadyUnpacking") + FreeArc.Text;
                await Task.Run(() => Tsk("Programs\\Archivers\\FreeArc.7z"));
                TotalProgress_Pb.Value++;
                TotalProgress_Lb.Text = Languages.Lang("AllProgress") + Convert.ToString(TotalProgress_Pb.Value * 100 / TotalProgress_Pb.Maximum) + "%";
                FreeArc.Checked = false;
            }
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
                file.Extracting += (sender, args) =>
                {
                    CurrentArchive.Value = args.PercentDone;
                };
                file.ExtractArchive(PathToUnpackPortable.Text);
            }
            CurrentArchive.Value = 0;
            return Task.CompletedTask;
        }
        #endregion
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
        #endregion
        private void Exit_B_Click(object sender, EventArgs e)
        {
            if (!UnpackInProcess) Application.Exit();
        }
    }
}
