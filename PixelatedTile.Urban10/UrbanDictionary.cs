/* 
    The MIT License (MIT)

	Copyright (c) 2015 Suraj "Interframe" G.

	Permission is hereby granted, free of charge, to any person obtaining a copy
	of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:

	The above copyright notice and this permission notice shall be included in all
	copies or substantial portions of the Software.

	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
	SOFTWARE.
 */

using Newtonsoft.Json;
using PixelatedTile.Urban10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PixelatedTile.Urban10
{
	/// <summary>
    /// A simple class to interact with the Urban Dictionary API
    /// </summary>
    public class UrbanDictionary
    {

        #region Const API Strings
        private const string SEARCH_URL = "http://api.urbandictionary.com/v0/define?term=";
        private const string RANDOM_URL = "http://api.urbandictionary.com/v0/random";
        private string _urbanSound;
        #endregion

        /// <summary>
        /// Find a word in Urban Dictionary
        /// </summary>
        /// <param name="Word">The word or phrase you'd like to search</param>
        /// <returns>LIST: Word, meaning, author etc...</returns>
        public async Task<List<ResultsList>> FindWord(string Word) {

            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(SEARCH_URL + Word);
            if (response.Contains("no_results"))
            {
                throw new Exception("No Results Found");
            }
            else
            {
                var urbanResults = JsonConvert.DeserializeObject<UrbanResults>(response);
                _urbanSound = urbanResults.sounds.FirstOrDefault().ToString();
                return urbanResults.list;
            }

        }

        /// <summary>
        /// Get random words/phrases
        /// </summary>
        /// <returns>List: ResultsList</returns>
        public async Task<List<ResultsList>> GetRandom(){

            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(RANDOM_URL);
            var urbanResults = JsonConvert.DeserializeObject<UrbanResults>(response);
            return urbanResults.list;
        }
    }
}
