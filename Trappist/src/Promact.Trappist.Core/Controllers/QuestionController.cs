﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Promact.Trappist.DomainModel.ApplicationClasses.Question;
using Promact.Trappist.DomainModel.Enum;
using Promact.Trappist.Repository.Questions;
using Promact.Trappist.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Promact.Trappist.Core.Controllers
{
    [Route("api/question")]
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _questionsRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public QuestionController(IQuestionRepository questionsRepository, UserManager<ApplicationUser> userManager)
        {
            _questionsRepository = questionsRepository;
            _userManager = userManager;
        }

        #region Question API
        /// <summary>
        /// Post API to save the question
        /// </summary>
        /// <param name="questionAC">QuestionAC object</param>
        /// <returns>
        /// Returns added Question
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> AddQuestionAsync([FromBody]QuestionAC questionAC)
        {
            if (questionAC == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var applicationUser = await _userManager.FindByEmailAsync(User.Identity.Name);

            if (questionAC.Question.QuestionType == QuestionType.Programming)
            {
                await _questionsRepository.AddCodeSnippetQuestionAsync(questionAC, applicationUser.Id);
            }
            else
            {
                await _questionsRepository.AddSingleMultipleAnswerQuestionAsync(questionAC, applicationUser.Id);
            }
            return Ok(questionAC);
        }

        /// <summary>
        /// API to get all the Questions
        /// </summary>
        /// <returns>Questions List</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            return Ok(await _questionsRepository.GetAllQuestionsAsync());
        }

        /// <summary>
        /// Returns all the coding languages
        /// </summary>
        /// <returns>
        /// Coding language object of type CodingLanguageAC
        /// </returns>
        [HttpGet("codinglanguage")]
        public async Task<IActionResult> GetAllCodingLanguages()
        {
            var codinglanguages = await _questionsRepository.GetAllCodingLanguagesAsync();
            return Ok(codinglanguages);
        }

        /// <summary>
        /// Updates an existing Question in database.
        /// </summary>
        /// <param name="id">Id of Question to update</param>
        /// <param name="questionAC">Object of QuestionAC</param>
        /// <returns>Returns updated question</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestionAsync(int id, [FromBody] QuestionAC questionAC)
        {
            if (questionAC == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            if (!await _questionsRepository.QuestionExistAsync(id))
            {
                return NotFound();
            }
            try
            {
                var applicationUser = await _userManager.FindByEmailAsync(User.Identity.Name);
                if (questionAC.Question.QuestionType == QuestionType.Programming)
                {
                    //To-Do Add call to update method for code snippet type question 
                }
                else
                {
                    await _questionsRepository.UpdateSingleMultipleAnswerQuestionAsync(id, questionAC, applicationUser.Id);
                }
            }
            catch (KeyNotFoundException)
            {
                //Id did not match any entry  
                return NotFound();
            }
            return Ok(questionAC);
        }
        #endregion
    }
}