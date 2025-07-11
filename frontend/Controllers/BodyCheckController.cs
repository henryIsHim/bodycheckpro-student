using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BodyCheckMVCWebAPIClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace BodyCheckMVCWebAPIClient.Controllers
{
    [Route("[controller]/{action=Index}/{Id=0}")]
    public class BodyCheckController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BodyCheckController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient CreateHttpClient()
        {
            return _httpClientFactory.CreateClient("BodyCheckApi");
        }

        // GET:BodyCheckController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                using (HttpClient httpClient = CreateHttpClient())
                {
                    List<BodyCheckViewModel>? bodyCheckList = null;
                    var response = await httpClient.GetAsync("");
                    if (response.IsSuccessStatusCode)
                    {
                        string strResponse = await response.Content.ReadAsStringAsync();
                        bodyCheckList = JsonSerializer.Deserialize<List<BodyCheckViewModel>>(strResponse, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                        if (bodyCheckList == null)
                        {
                            TempData["errorMessage"] = "No Data";
                            return View();
                        }
                        else
                        {
                            return View(bodyCheckList);
                        }
                    }
                    else
                    {
                        TempData["errorMessage"] = $"Response Status Code was not Success: {response.StatusCode}";
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = $"Error Message: {ex.Message}{Environment.NewLine}Stack Trace:{Environment.NewLine}{ex.StackTrace}";
                return View();
            }
        }

        // GET:BodyCheckController/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BodyCheckViewModel addBodyCheckViewModel)
        {
            try
            {
                using (HttpClient httpClient = CreateHttpClient())
                {
                    var response = await httpClient.PostAsJsonAsync("", addBodyCheckViewModel);
                    if (response.IsSuccessStatusCode)
                    {
                        TempData["successMessage"] = $"New Body Check Record was Created ({addBodyCheckViewModel.Firstname} {addBodyCheckViewModel.Lastname}).";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["errorMessage"] = $"Response Status Code was not Success: {response.StatusCode}";
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = $"Error Message: {ex.Message}{Environment.NewLine}Stack Trace:{Environment.NewLine}{ex.StackTrace}";
                return View();
            }
        }

        // GET:BodyCheckController/Edit/4
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                using (HttpClient httpClient = CreateHttpClient())
                {
                    var response = await httpClient.GetAsync($"{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        string strResponse = await response.Content.ReadAsStringAsync();
                        BodyCheckViewModel? bodyCheckViewModel = JsonSerializer.Deserialize<BodyCheckViewModel>(strResponse, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                        return View(bodyCheckViewModel);
                    }
                    else
                    {
                        TempData["errorMessage"] = $"Response Status Code was not Success: {response.StatusCode}";
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = $"Error Message: {ex.Message}{Environment.NewLine}Stack Trace:{Environment.NewLine}{ex.StackTrace}";
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BodyCheckViewModel editBodyCheckViewModel)
        {
            try
            {
                using (HttpClient httpClient = CreateHttpClient())
                {
                    var response = await httpClient.PutAsJsonAsync("", editBodyCheckViewModel);
                    if (response.IsSuccessStatusCode)
                    {
                        TempData["successMessage"] = $"Body Check Record was Edited ({editBodyCheckViewModel.Firstname} {editBodyCheckViewModel.Lastname}).";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["errorMessage"] = $"Response Status Code was not Success: {response.StatusCode}";
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = $"Error Message: {ex.Message}{Environment.NewLine}Stack Trace:{Environment.NewLine}{ex.StackTrace}";
                return View();
            }
        }

        // GET:BodyCheckController/Delete/4
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                using (HttpClient httpClient = CreateHttpClient())
                {
                    var response = await httpClient.GetAsync($"{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        string strResponse = await response.Content.ReadAsStringAsync();
                        BodyCheckViewModel? bodyCheckViewModel = JsonSerializer.Deserialize<BodyCheckViewModel>(strResponse, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                        return View(bodyCheckViewModel);
                    }
                    else
                    {
                        TempData["errorMessage"] = $"Response Status Code was not Success: {response.StatusCode}";
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = $"Error Message: {ex.Message}{Environment.NewLine}Stack Trace:{Environment.NewLine}{ex.StackTrace}";
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(BodyCheckViewModel deleteBodyCheckViewModel)
        {
            try
            {
                using (HttpClient httpClient = CreateHttpClient())
                {
                    var response = await httpClient.DeleteAsync($"{deleteBodyCheckViewModel.Id}");
                    if (response.IsSuccessStatusCode)
                    {
                        TempData["successMessage"] = $"Body Check Record was Deleted ({deleteBodyCheckViewModel.Firstname} {deleteBodyCheckViewModel.Lastname}).";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["errorMessage"] = $"Response Status Code was not Success: {response.StatusCode}";
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = $"Error Message: {ex.Message}{Environment.NewLine}Stack Trace:{Environment.NewLine}{ex.StackTrace}";
                return View();
            }
        }
    }
}