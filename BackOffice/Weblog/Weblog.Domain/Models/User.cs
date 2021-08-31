using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;

namespace Weblog.Domain.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string? Token { get; set; }
        public List<Article> Articles { get; }
        public List<Comment> Comments { get; }

        public User()
        {

        }

        public User(string name, string email, string password)
        {
            // Validations for Name
            if (name == null)
            {
                throw new Exception("نام کاربر را وارد کنید");
            }
            if (name.Length >= 50)
            {
                throw new Exception("نام کاربر نمی تواند بیشتر از 50 کاراکتر باشد");
            }

            // Validations for Email
            if (email == null)
            {
                throw new Exception("ایمیل کاربر را وارد کنید");
            }
            if (email.Length >= 200)
            {
                throw new Exception("ایمیل کاربر نمی تواند بیشتر از 200 کاراکتر باشد");
            }
            var validEmail = Regex.Match(email, @"(^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$)");
            if (!validEmail.Success)
            {
                throw new Exception("آدرس ایمیل وارد شده معتبر نمی باشد");
            }
            var _db = new DatabaseContext();
            var count = _db.Users.Count(x => x.Email == email);
            if (count > 0)
            {
                throw new Exception("آدرس ایمیل وارد شده تکراری می باشد");
            }

            if (password.Length <= 6)
            {
                throw new Exception("کلمه عبور باید بیشتر از 6 کاراکتر باشد");
            }

            // Validations for Password
            var validPassword = Regex.Match(password, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{6,}$");
            if (!validPassword.Success)
            {
                throw new Exception("رمز عبور باید شامل حروف، عدد و حداقل یک کاراکتر خاص باشد");
            }

            this.Name = name;
            this.Email = email;
            this.Password = GetHashString(password);
        }

        public void Update(string name, string email)
        {
            // Validations for Name
            if (name == null)
            {
                throw new Exception("نام کاربر را وارد کنید");
            }
            if (name.Length >= 50)
            {
                throw new Exception("نام کاربر نمی تواند بیشتر از 50 کاراکتر باشد");
            }

            // Validations for Email
            if (email == null)
            {
                throw new Exception("ایمیل کاربر را وارد کنید");
            }
            if (email.Length >= 200)
            {
                throw new Exception("ایمیل کاربر نمی تواند بیشتر از 200 کاراکتر باشد");
            }
            var validEmail = Regex.Match(email, @"(^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$)");
            if (!validEmail.Success)
            {
                throw new Exception("آدرس ایمیل وارد شده معتبر نمی باشد");
            }
            var _db = new DatabaseContext();
            var count = _db.Users.Count(x => x.Email == email && x.Id != this.Id);
            if (count > 0)
            {
                throw new Exception("آدرس ایمیل وارد شده تکراری می باشد");
            }

            this.Name = name;
            this.Email = email;
        }
    }
}
