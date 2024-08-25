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
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723"; // Windows Application DriverのURL
        private const string WinFormAppId = @"C:\Users\taniz\source\repos\WinFormsAppMvvm\WinFormsApp1\bin\Debug\net8.0-windows\WinformAppMvvm.exe"; // WPFアプリケーションの実行可能ファイルのフルパス
        private static WindowsDriver _app; // AppiumのWindowsドライバインスタンス

        [ClassInitialize] // このメソッドがテストクラスの初期化メソッドであることを示す属性
        public static void Setup(TestContext context)
        {
            var appOptions = new AppiumOptions(); // AppiumOptionsオブジェクトを作成
            appOptions.App = WinFormAppId;
            appOptions.AutomationName = "windows";
            appOptions.PlatformName = "Windows";
            appOptions.DeviceName = "WindowsPC";
            _app = new WindowsDriver(new Uri(WindowsApplicationDriverUrl), appOptions);
            _app.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [ClassCleanup] // このメソッドがテストクラスの終了メソッドであることを示す属性
        public static void TearDown()
        {
            _app?.Quit(); // ドライバインスタンスを終了（アプリケーションを閉じる）
        }


        [TestMethod]
        public void TestMethod1()
        {
            Thread.Sleep(2000); //2秒待つ

            var firstNameTextBox = _app.FindElement(MobileBy.AccessibilityId("textBoxFirstName"));
            firstNameTextBox.SendKeys("FirstName");
            Thread.Sleep(100);

            var lastNameTextBox = _app.FindElement(MobileBy.AccessibilityId("textBoxLastName"));
            lastNameTextBox.SendKeys("LastName");
            Thread.Sleep(100);

            firstNameTextBox.Click();   // UIイベントを強制的に起こすことでデータバインディングを発動させる
            Thread.Sleep(10000);

            // UIメモ：labelだとTextプロパティはlabelFullNameになる
            // read-only なテキストボックスにするべき
//            var fullNameLabel = _app.FindElement(MobileBy.AccessibilityId("labelFullName"));
//            Assert.AreEqual("FirstName LastName", fullNameLabel.);
            Thread.Sleep(10000);
        }
    }
}