/* 
    Class: UrbanDictionary.cs
    Description: A simple class to interact with the Urban Dictionary API

    Created By: @Interframe 
    
        Copyright 2015 Suraj "Interframe" G.

       Licensed under the Apache License, Version 2.0 (the "License");
       you may not use this file except in compliance with the License.
       You may obtain a copy of the License at

           http://www.apache.org/licenses/LICENSE-2.0

       Unless required by applicable law or agreed to in writing, software
       distributed under the License is distributed on an "AS IS" BASIS,
       WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
       See the License for the specific language governing permissions and
       limitations under the License.

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
    public class UrbanDictionary
    {
        private const string SEARCH_URL = "http://api.urbandictionary.com/v0/define?term=";
        private string _urbanSound;
        
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
        /// returns the URL to the default audio transcription to the word.
        /// </summary>

        [Obsolete] //TODO: MAKE SURE THIS WORKS.
        public string GetDefaultAudio {
            get {
                return _urbanSound;
            }

        }




    }
}
