using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium;
using System.Threading;
using OpenQA.Selenium;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723"; // Windows Application Driver��URL
        private const string WinFormAppId = @"C:\Users\taniz\source\repos\WinFormsAppMvvm\WinFormsApp1\bin\Debug\net8.0-windows\WinformAppMvvm.exe"; // WPF�A�v���P�[�V�����̎��s�\�t�@�C���̃t���p�X
        private static WindowsDriver _app; // Appium��Windows�h���C�o�C���X�^���X

        [ClassInitialize] // ���̃��\�b�h���e�X�g�N���X�̏��������\�b�h�ł��邱�Ƃ���������
        public static void Setup(TestContext context)
        {
            var appOptions = new AppiumOptions(); // AppiumOptions�I�u�W�F�N�g���쐬
            appOptions.App = WinFormAppId;
            appOptions.AutomationName = "windows";
            appOptions.PlatformName = "Windows";
            appOptions.DeviceName = "WindowsPC";
            _app = new WindowsDriver(new Uri(WindowsApplicationDriverUrl), appOptions);
            _app.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [ClassCleanup] // ���̃��\�b�h���e�X�g�N���X�̏I�����\�b�h�ł��邱�Ƃ���������
        public static void TearDown()
        {
            _app?.Quit(); // �h���C�o�C���X�^���X���I���i�A�v���P�[�V���������j
        }


        [TestMethod]
        public void TestMethod1()
        {
            Thread.Sleep(2000); //2�b�҂�

            var firstNameTextBox = _app.FindElement(MobileBy.AccessibilityId("textBoxFirstName"));
            firstNameTextBox.SendKeys("FirstName");
            Thread.Sleep(100);

            var lastNameTextBox = _app.FindElement(MobileBy.AccessibilityId("textBoxLastName"));
            lastNameTextBox.SendKeys("LastName");
            Thread.Sleep(100);

            firstNameTextBox.Click();   // UI�C�x���g�������I�ɋN�������ƂŃf�[�^�o�C���f�B���O�𔭓�������
            Thread.Sleep(10000);

            // UI�����Flabel����Text�v���p�e�B��labelFullName�ɂȂ�
            // read-only �ȃe�L�X�g�{�b�N�X�ɂ���ׂ�
//            var fullNameLabel = _app.FindElement(MobileBy.AccessibilityId("labelFullName"));
//            Assert.AreEqual("FirstName LastName", fullNameLabel.);
            Thread.Sleep(10000);
        }
    }
}