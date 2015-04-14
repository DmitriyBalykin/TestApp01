using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TestApp01.Attribute.Validation;

namespace TestApp01.Model.ViewModels
{
    public class UserView
    {
        public int Id {get; set;}
        [Required(ErrorMessage = "Введите имя")]
        public string Name {get; set;}
        [Required(ErrorMessage = "Введите Email"), ValidEmailAttribute(ErrorMessage = "Введенное значени Email некорректно")]
        public string Email { get; set; }
        public string AvatarPath { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Пароли должны совпадать")]
        public string ConfirmPassword { get; set; }
        public string Captcha { get; set; }
        public int BirthdayDay { get; set; }
        public int BirthdayMonth { get; set; }
        public int BirthdayYear { get; set; }
        public IEnumerable<SelectListItem> BirthdayDaySelectList
        {
            get
            {
                for (int i = 1; i < 32; i++)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = i.ToString(),
                        Selected = BirthdayDay == i
                    };
                }
            }
        }
        public IEnumerable<SelectListItem> BirthdayMonthSelectList
        {
            get
            {
                for (int i = 1; i < 13; i++)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = new DateTime(2000, i, 1).ToString("MMMM"),
                        Selected = BirthdayMonth == i
                    };
                }
            }
        }
        public IEnumerable<SelectListItem> BirthdayYearSelectList
        {
            get
            {
                for (int i = DateTime.Now.Year; i >= DateTime.Now.Year - 100; i--)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = i.ToString(),
                        Selected = BirthdayYear == i
                    };
                }
            }
        }
    }
}