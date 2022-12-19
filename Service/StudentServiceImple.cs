﻿using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Service
{
    public class StudentServiceImple : IStudentService
    {
        private readonly IStudentDAO dao;

        public StudentServiceImple(IStudentDAO dao) 
        {
            this.dao = dao; 
        }



        public Student? DeleteStudent(StudentDTO? dto)
        {
            if (dto is null) return null;

            try
            {
                Student? student = Convert(dto);
                dao.Delete(student);
                return student;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<Student> GetAllStudents()
        {
            try
            {
                return dao.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Student>();
            }
        }

        public Student? GetStudent(int id)
        {
            try
            {
                return dao.GetStudent(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void InsertStudent(StudentDTO? DTO)
        {
            if (DTO is null) return;

            try
            {
                Student? student = Convert(DTO);
                dao.Insert(student);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void UpdateStudent(StudentDTO? DTO)
        {
            if (DTO is null) return;

            try
            {
                Student? student = Convert(DTO);
                dao.Update(student);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private Student? Convert(StudentDTO dto)
        {
            if (dto == null) return null;

            return new Student()
            {
                Id = dto.Id,
                Firstname = dto.Firstname,
                Lastname = dto.Lastname
            };
        }

    }
}
