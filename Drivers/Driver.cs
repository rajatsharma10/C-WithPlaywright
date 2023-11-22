using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowOctopusPMI.Drivers
{
    public class Driver
    {
        private readonly Task<IPage> _page; 
        private IBrowser? _browser;
        public Driver() 
        { 
         _page=InitializePlaywright();
        
        }

        public IPage Page => _page.Result;


        private async Task<IPage> InitializePlaywright()
        {

             var playwright = await Playwright.CreateAsync();
             _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });
            var context = await _browser.NewContextAsync();

            return await context.NewPageAsync();
        }
/*
        public void Dispose()
        {
            _browser.CloseAsync();
        }*/
    }
}
