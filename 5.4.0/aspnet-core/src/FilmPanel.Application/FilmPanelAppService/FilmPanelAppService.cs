using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using FilmPanel.FilmPanelAppService.Dto;
using FilmPanel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FilmPanel.FilmPanelAppService
{
    public class FilmPanelAppService : ApplicationService, IFilmPanelAppService
    {
        private readonly IRepository<FilmAndSeries, long> _filmAndSeriesRepository;
        private readonly IRepository<Vote, long> _voteRepository;


        private static readonly HttpClient client = new HttpClient();

        public FilmPanelAppService(

            IRepository<FilmAndSeries, long> filmAndSeriesRepository,
            IRepository<Vote, long> voteRepository

            )
        {
            _filmAndSeriesRepository = filmAndSeriesRepository;
            _voteRepository = voteRepository;


        }


        #region FilmAndSeries
        [HttpGet]
        public async Task<FilmAndSeriesDtocs> HttpCaller(string link)
        {
            link = "https://raw.githubusercontent.com/StreamCo/react-coding-challenge/master/feed/sample.json";
            FilmAndSeries returner = new FilmAndSeries();
            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                client.BaseAddress = new Uri(link);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic");

                HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

                response.EnsureSuccessStatusCode();
                var returResult = await response.Content.ReadAsStringAsync();
                var returning = returResult.Split('[')[1];


                var rr = returning.Split('"');



                for (int i = 3; i < rr.Length; i++)
                {


              
                    returner.Title = rr[i];
                    i = i + 4;
                    returner.Description = rr[i];
                    i = i + 4;
                    returner.ProgramType = rr[i];
                    i = i + 8;
                    returner.Url = rr[i];
                    i = i + 7;
                    var a = rr[i].Split(":")[1];
                    //returner.ReleaseYear = rr[i];
                    i = i + 2;

                   await  _filmAndSeriesRepository.InsertAndGetIdAsync(returner);

                  returner = new FilmAndSeries();
                }

                return ObjectMapper.Map<FilmAndSeriesDtocs>(returner); ;
            }
        }

        [HttpPost]
        public async Task<PagedResultDto<FilmAndSeriesDtocs>> GetMovies(int skipCount, int maxResultCount, string keyword)
        {
            var result = _filmAndSeriesRepository.GetAll().Where(x => x.ProgramType == "movie" && x.ReleaseYear >= 2010).WhereIf(!keyword.IsNullOrWhiteSpace(), x => x.Title.ToLower().Contains(keyword.ToLower()))
               .Skip(skipCount).Take(8);
            var totalCount = _filmAndSeriesRepository.GetAll().Where(x => x.ProgramType == "movie" && x.ReleaseYear >=2010).WhereIf(!keyword.IsNullOrWhiteSpace(), x => x.Title.ToLower().Contains(keyword.ToLower())).Take(maxResultCount).Count();
            return new PagedResultDto<FilmAndSeriesDtocs>(totalCount, ObjectMapper.Map<List<FilmAndSeriesDtocs>>(result.Take(21)));
        }


        [HttpPost]
        public async Task<PagedResultDto<FilmAndSeriesDtocs>> GetSeries(int skipCount, int maxResultCount, string keyword)
        {
            var result = _filmAndSeriesRepository.GetAll().Where(x => x.ProgramType == "series" && x.ReleaseYear >= 2010).WhereIf(!keyword.IsNullOrWhiteSpace(), x => x.Title.ToLower().Contains(keyword.ToLower()))
               .Skip(skipCount).Take(8);
            var totalCount = _filmAndSeriesRepository.GetAll().Where(x => x.ProgramType == "series" && x.ReleaseYear >= 2010).WhereIf(!keyword.IsNullOrWhiteSpace(), x => x.Title.ToLower().Contains(keyword.ToLower())).Take(maxResultCount).Count();
            return new PagedResultDto<FilmAndSeriesDtocs>(totalCount, ObjectMapper.Map<List<FilmAndSeriesDtocs>>(result.Take(21)));
        }




        [HttpPost]
        public async Task<List<FilmAndSeriesDtocs>> GetMoviesAndSeries()
        {
            var result = _filmAndSeriesRepository.GetAll().ToList().Take(50);
               
            return new List<FilmAndSeriesDtocs>(ObjectMapper.Map<List<FilmAndSeriesDtocs>>(result));
        }

        #endregion


        #region Vote
        [HttpPost]
        public async Task<ListResultDto<VoteDto>> GetVoteList()
        {
            var result = _voteRepository.GetAllList();
            return new ListResultDto<VoteDto>(ObjectMapper.Map<List<VoteDto>>(result));
        }



        [HttpPost]
        public async Task<PagedResultDto<VoteDto>> GetVoteListForCont(int skipCount, int maxResultCount, string keyword, long id)
        {

            var result = _voteRepository.GetAllIncluding(x => x.FilmAndSeries).Where(x => x.FilmAndSeriesId == id).WhereIf(!keyword.IsNullOrWhiteSpace(), x => x.FilmAndSeries.Title.ToLower().Contains(keyword.ToLower()) || x.FilmAndSeries.Title.ToLower().Contains(x.FilmAndSeries.Title.ToLower()))
                .OrderByDescending(x => x.CreationTime).Skip(skipCount).Take(maxResultCount);

            var totalCount = _voteRepository.GetAllIncluding(x => x.FilmAndSeries).Where(x => x.FilmAndSeriesId == id)
                .WhereIf(!keyword.IsNullOrWhiteSpace(), x => x.FilmAndSeries.Title.ToLower().Contains(keyword.ToLower()) || x.FilmAndSeries.Title.ToLower().Contains(x.FilmAndSeries.Title.ToLower())).Count();

            return new PagedResultDto<VoteDto>(totalCount, ObjectMapper.Map<List<VoteDto>>(result));
        }

        [HttpGet]
        public async Task<VoteDto> FindVote(long id)
        {
            var result = await _voteRepository.FirstOrDefaultAsync(id);
            return ObjectMapper.Map<VoteDto>(result);
        }

        [HttpGet]   
        public async Task<VoteDto> FindVoteByFilmsAndSeriesId(long id)
        {
            var result =  _voteRepository.GetAllIncluding(x=>x.FilmAndSeries).Where(x=>x.FilmAndSeriesId==id).FirstOrDefault();
            return ObjectMapper.Map<VoteDto>(result);
        }


        public async Task<long> AddVote(VoteDto input)
        {
            Vote vote = new Vote();

            vote.FilmAndSeriesId = input.FilmAndSeriesId;
            vote.Point = input.Point;
            vote.Description = input.Description;
            vote.IsVoting = true;

            long id = await _voteRepository.InsertAndGetIdAsync(vote);
            return id;
        }


        [HttpPost]
        public async Task<long> UpdateVote(VoteDto input)
        {
            var result = _voteRepository.GetAll().Where(x => x.Id == input.Id).FirstOrDefault();

            result.FilmAndSeriesId = input.FilmAndSeriesId;
            result.IsVoting = input.IsVoting;
            result.Point = input.Point;
            result.Description = input.Description;
            await _voteRepository.UpdateAsync(result);
            return input.Id;
        }

        [HttpGet]
        public async Task DeleteVote(long id)
        {
            _voteRepository.Delete(id);
        }


        #endregion
    }
}
