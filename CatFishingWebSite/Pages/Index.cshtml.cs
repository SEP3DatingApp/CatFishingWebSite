﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CatFishingWebSite.Model;
using CatFishingWebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CatFishingWebSite.Pages
{
    public class IndexModel : PageModel

    {
       private static readonly IWebService webService;
        private static readonly DummyServer dummy = new DummyServer();
         

        [BindProperty]
        public User user { get; set; }
        
        private readonly ILogger<IndexModel> _logger;

        private bool isLogin;
        public string errorMessage;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Console.WriteLine("onget for login");
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Debug.WriteLine("onpost for login"); 
            Console.WriteLine("user name: "+user.Username);
            Console.WriteLine(user.Password);
          
         
         
           isLogin = webService.IsLogin(user.Username, user.Password);
            if (isLogin)
            {
                
                return RedirectToPage("Match/" + user.Username);
                
            }else
           errorMessage = "User Name or Password is incorrect"; 
            return Page();
            
        }

        public  string getUserName()
        {

            return user.Username;
        }

    }
}
