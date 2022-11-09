﻿using RLPortalBackend.Repositories;

namespace RLPortalBackend.Services.Impl
{
    public class CourseService: ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
    }
}