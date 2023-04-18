using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using MANTRA;

namespace MantraSampleWinFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private MFS100 _mfs100;
        private byte[] _isoTemplate;
        private byte[] _ansiTemplate;
        private readonly string _dataPath = Application.StartupPath + "\\FingerData";
        private int _quality = 60;
        private int _timeout = 10000;
        private DeviceInfo _deviceInfo;
        private const int MatchThreshold = 1400;

        private bool SetQuality
        {
            get
            {
                try
                {
                    _quality = Convert.ToInt32(txtQuality.Text.Trim());
                    return true;
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Invalid Quality Value");
                }
                finally
                {
                    GC.Collect();
                }

                return false;
            }
        }
        
        private bool SetTimeout
        {
            get
            {
                try
                {
                    _timeout = Convert.ToInt32(txtTimeout.Text.Trim());
                    return true;
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Invalid Timeout Value");
                }
                finally
                {
                    GC.Collect();
                }

                return false;
            }
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            lblSerial.Text = "";
            ResetControl();
            _mfs100 = new MFS100();
            _mfs100.OnMFS100Attached += MFS100_OnMFS100Attached;
            _mfs100.OnMFS100Detached += MFS100_OnMFS100Detached;
            _mfs100.OnPreview += MFS100_OnPreview;
            _mfs100.OnCaptureCompleted += MFS100_OnCaptureCompleted;
            try
            {
                if (!Directory.Exists(_dataPath))
                {
                    Directory.CreateDirectory(_dataPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MFS100_OnMFS100Attached()
        {
            MessageBox.Show(@"MFS100 Attached and ready to initialize");
        }

        private void MFS100_OnMFS100Detached()
        {
            MessageBox.Show(@"MFS100 Detached");
        }

        private void MFS100_OnPreview(FingerData fingerprintData)
        {
            new Thread(() =>
            {
                try
                {
                    if (fingerprintData == null) 
                        return;
                    picFinger.Image = fingerprintData.FingerImage;
                    picFinger.Refresh();
                    lblStatus.Text = @"Quality: " + fingerprintData.Quality.ToString();
                    lblStatus.Refresh();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }).Start();
        }

        private void MFS100_OnCaptureCompleted(bool status, int errorCode, string errorMessage, FingerData fingerprintData)
        {
            try
            {
                if (status)
                {
                    picFinger.Image = fingerprintData.FingerImage;
                    picFinger.Refresh();
                    File.WriteAllBytes(_dataPath + "//ISOTemplate.iso", fingerprintData.ISOTemplate);
                    File.WriteAllBytes(_dataPath + "//ISOImage.iso", fingerprintData.ISOImage);
                    File.WriteAllBytes(_dataPath + "//AnsiTemplate.ansi", fingerprintData.ANSITemplate);
                    File.WriteAllBytes(_dataPath + "//RawData.raw", fingerprintData.RawData);
                    fingerprintData.FingerImage.Save(_dataPath + "//FingerImage.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                    File.WriteAllBytes(_dataPath + "//WSQImage.wsq", fingerprintData.WSQImage);

                    _isoTemplate = new byte[fingerprintData.ISOTemplate.Length];
                    fingerprintData.ISOTemplate.CopyTo(_isoTemplate, 0);
                    _ansiTemplate = new byte[fingerprintData.ANSITemplate.Length];
                    fingerprintData.ANSITemplate.CopyTo(_ansiTemplate, 0);

                    var info = "Quality: " + fingerprintData.Quality + "     Nfiq: " + fingerprintData.Nfiq + "     Bpp: " + fingerprintData.Bpp.ToString() + "     GrayScale:" + fingerprintData.GrayScale.ToString() + "\nW(in):" + fingerprintData.InWidth.ToString() + "     H(in):" + fingerprintData.InHeight.ToString() + "     area(in):" + fingerprintData.InArea.ToString() + "     Dpi/Ppi:" + fingerprintData.Resolution.ToString() + "     Compress Ratio:" + fingerprintData.WSQCompressRatio.ToString() + "     WSQ Info:" + fingerprintData.WSQInfo.ToString(); 
                    lblStatus.Text = info;
                    MessageBox.Show(@"Capture Success. Finger Data saved at Application Path");
                }
                else
                {
                    lblStatus.Text = @"Capture Failed: " + errorCode + @" (" + errorMessage + @")";
                }
                lblStatus.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        }

        private void ResetControl()
        {
            picFinger.Image = null;
            lblStatus.Text = "";
        }

        private void btnVersion_Click(object sender, EventArgs e)
        {
            try
            {
                var version = _mfs100.GetSDKVersion();
                MessageBox.Show(@"SDK Version: " + version);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _mfs100.Dispose();
        }

        private void btnCheckDevice_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(_mfs100.IsConnected() ? @"Device Connected" : @"Device Not Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            try
            {
                var returnValue = _mfs100.Init();
                if (returnValue != 0)
                {
                    MessageBox.Show(@"Init failed: " + _mfs100.GetErrorMsg(returnValue));
                }
                else
                {
                    _deviceInfo = _mfs100.GetDeviceInfo();
                    if(_deviceInfo != null)
                    {
                        lblSerial.Text = @"SERIAL NO.: " + _deviceInfo.SerialNo + @"     MAKE: " + _deviceInfo.Make + @"     MODEL: " + _deviceInfo.Model + @"
WIDTH: " + _deviceInfo.Width.ToString() + @"     HEIGHT: " + _deviceInfo.Height.ToString() + @"     CERT: " + _mfs100.GetCertification();
                    }
                    else
                    {
                        lblSerial.Text = "";
                    }
                    MessageBox.Show(@"Init Success: " + _mfs100.GetErrorMsg(returnValue));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnStartCapture_Click(object sender, EventArgs e)
        {
            try
            {
                ResetControl();
                _isoTemplate = null;
                _ansiTemplate = null;
                if (!SetQuality)
                    return;
                if(!SetTimeout)
                    return;
                var returnValue = _mfs100.StartCapture(_quality, _timeout, chkShowPreview.Checked);
                if (returnValue != 0)
                {
                    MessageBox.Show(@"Start Capture failed: " + _mfs100.GetErrorMsg(returnValue));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnStopCapture_Click(object sender, EventArgs e)
        {
            //get return value from stop capture and say it msg if != 0
            try
            {
                var returnValue = _mfs100.StopCapture();
                if (returnValue != 0)
                {
                    MessageBox.Show(@"Stop Capture failed: " + _mfs100.GetErrorMsg(returnValue));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnAutoCapture_Click(object sender, EventArgs e)
        {
            ResetControl();
            new Thread(() =>
            {
                try
                {
                    FingerData fingerData = null;
                    _isoTemplate = null;
                    _ansiTemplate = null;
                    ResetControl();
                    if (!SetQuality)
                        return;
                    //start auto capture with return value
                    var returnValue = _mfs100.AutoCapture(ref fingerData, _timeout, chkShowPreview.Checked, chkIsDetectFinger.Checked);
                    if(returnValue != 0)
                    {
                        MessageBox.Show(@"Auto Capture failed: " + _mfs100.GetErrorMsg(returnValue));
                    }
                    else
                    {
                        File.WriteAllBytes(_dataPath + "//ISOTemplate.iso", fingerData.ISOTemplate);
                        File.WriteAllBytes(_dataPath + "//ISOImage.iso", fingerData.ISOImage);
                        File.WriteAllBytes(_dataPath + "//AnsiTemplate.ansi", fingerData.ANSITemplate);
                        File.WriteAllBytes(_dataPath + "//RawData.raw", fingerData.RawData);
                        fingerData.FingerImage.Save(_dataPath + "//FingerImage.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                        File.WriteAllBytes(_dataPath + "//WSQImage.wsq", fingerData.WSQImage);
                        _isoTemplate = new byte[fingerData.ISOTemplate.Length];
                        fingerData.ISOTemplate.CopyTo(_isoTemplate, 0);
                        _ansiTemplate = new byte[fingerData.ANSITemplate.Length];
                        fingerData.ANSITemplate.CopyTo(_ansiTemplate, 0);
                        var info = "Quality: " + fingerData.Quality.ToString() + "     Nfiq: " + fingerData.Nfiq.ToString() + "     Bpp: " + fingerData.Bpp.ToString() + "     GrayScale:" + fingerData.GrayScale.ToString() + "\nW(in):" + fingerData.InWidth.ToString() + "     H(in):" + fingerData.InHeight.ToString() + "     area(in):" + fingerData.InArea.ToString() + "     Dpi/Ppi:" + fingerData.Resolution.ToString() + "     Compress Ratio:" + fingerData.WSQCompressRatio.ToString() + "     WSQ Info:" + fingerData.WSQInfo.ToString(); 
                        lblStatus.Text = info;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }).Start();
        }

        private void btnMatchISOTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                if(_isoTemplate == null || _isoTemplate?.Length == 0)
                {
                    MessageBox.Show(@"Please capture finger first");
                }
                else
                {
                    var score = 0;
                    var returnValue = _mfs100.MatchISO(_isoTemplate, _isoTemplate, ref score);
                    if (returnValue != 0)
                    {
                        MessageBox.Show(@"Match ISO Template failed: " + _mfs100.GetErrorMsg(returnValue));
                    }
                    else
                    {
                        if (score >= MatchThreshold)
                        {
                            MessageBox.Show(@"Match ISO Template Success with Score: " + score);
                        }
                        else
                        {
                            MessageBox.Show(@"Match ISO Template failed with Score: " + score);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnMatchANSITemplate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ansiTemplate == null || _ansiTemplate?.Length == 0)
                {
                    MessageBox.Show(@"Please capture finger first");
                }
                else
                {
                    var score = 0;
                    var returnValue = _mfs100.MatchANSI(_ansiTemplate, _ansiTemplate, ref score);
                    if (returnValue != 0)
                    {
                        MessageBox.Show(@"Match ANSI Template failed: " + _mfs100.GetErrorMsg(returnValue));
                    }
                    else
                    {
                        if (score >= MatchThreshold)
                        {
                            MessageBox.Show(@"Match ANSI Template Success with Score: " + score);
                        }
                        else
                        {
                            MessageBox.Show(@"Match ANSI Template failed with Score: " + score);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnUninit_Click(object sender, EventArgs e)
        {
            //get return value from uninits and say it msg if != 0
            try
            {
                var returnValue = _mfs100.Uninit();
                if (returnValue != 0)
                {
                    MessageBox.Show(@"Uninit failed: " + _mfs100.GetErrorMsg(returnValue));
                }
                else
                {
                    MessageBox.Show(@"Uninit Success: " + _mfs100.GetErrorMsg(returnValue));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}