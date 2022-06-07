﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace L102Exercises1
{
    // lớp mô tả thông tin sinh viên
    class Student : IComparable<Student>
    {
        [JsonProperty("studentId")]
        public string StudentId { get; set; }
        [JsonProperty("fullName")]
        public FullName FullName { get; set; }
        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("major")]
        public string Major { get; set; }

        public Student() { }

        public Student(string id)
        {
            StudentId = id;
        }

        public Student(string id, string fullName, DateTime dob,
            string email, string phoneNumber, string major) : this(id)
        {
            FullName = new FullName(fullName);
            BirthDate = dob;
            Email = email;
            PhoneNumber = phoneNumber;
            Major = major;
        }

        public override bool Equals(object obj) // hai sinh viên là 1 nếu trùng mã sinh viên
        {
            return obj is Student student &&
                   StudentId == student.StudentId;
        }

        public override int GetHashCode()
        {
            return 610864741 + EqualityComparer<string>.Default.GetHashCode(StudentId);
        }

        public int CompareTo(Student other)
        {
            if(this == null && other == null)
            {
                return 0;
            } else if(other == null && this != null)
            {
                return -1;
            } else if(this == null && other != null)
            {
                return 1;
            }
            else
            {
                var nameCompare = FullName.FirstName.CompareTo(other.FullName.FirstName);
                if(nameCompare != 0)
                {
                    return nameCompare;
                } else
                {
                    return FullName.LastName.CompareTo(other.FullName.LastName);
                }
            }
        }
    }
}
