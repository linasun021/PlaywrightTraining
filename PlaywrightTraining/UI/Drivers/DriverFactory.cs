﻿using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAutomationFramework.UI.Configuration;

namespace TrainingAutomationFramework.UI.Drivers
{
    public class DriverFactory
    {
        private static IPlaywright? _playwright;
        private static IBrowser? _browser;
        private static Settings? _settings;
        private static IPage? _page;

        static DriverFactory()
        {
            var configReader = new ConfigurationReader();
            _settings = configReader.GetSettings();
        }

        public static async Task<IPage> GetPageAsync()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = _settings.BrowserType switch
            {
                "Chromium" => await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = _settings?.Headless}),
                "Firefox" => await _playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = _settings?.Headless }),
                "WebKit" => await _playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions { Headless = _settings?.Headless }),
                _ => await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = _settings?.Headless })
            };

            var context = _settings.EnableVideo ? await _browser.NewContextAsync(
                new BrowserNewContextOptions
                {
                    RecordVideoDir = _settings.VideoDir,
                    RecordVideoSize = new RecordVideoSize
                    {
                        Width = 1280,
                        Height = 720
                    }

                }) : await _browser.NewContextAsync();

            _page = await context.NewPageAsync();

            if (_settings.EnableTracing)
            {
                _page.Context.Tracing.StartAsync(new TracingStartOptions
                {
                    Snapshots = true,
                    Screenshots = true,
                    Sources = true
                }).Wait();
            }
            _page.GotoAsync(_settings.BaseUrl).Wait();
            return _page;
        }

        public static async Task CloseAsync(string scenarioName)
        {
            
            if (_settings.EnableTracing)
            {
                _page.Context.Tracing.StopAsync(new TracingStopOptions
                {
                    Path = _settings.TraceFile + "_" + scenarioName.Replace(" ","") + ".zip"
                }).Wait();
            }

            if (_page != null)
            {
                await _page.CloseAsync();
                _page = null;
            }

            if (_browser != null)
            {
                await _browser.CloseAsync();
                _browser = null;
            }
            if (_playwright != null)
            {
                _playwright.Dispose();
                _playwright = null;
            }
        }

        public static Settings GetSettings()
        {
            return _settings;
        }
    }
}
