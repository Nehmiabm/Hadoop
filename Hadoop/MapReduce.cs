using Microsoft.Hadoop.MapReduce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hadoop
{
    //Mapper
    public class WordMapper : MapperBase
    {
        //Override the map method.
        public override void Map(string inputLine, MapperContext context)
        {
            //Extract the words from the text files

            var words = Regex.Split(inputLine, @"\W");

            foreach (string word in words)
            {
                //Just emit the words.
                context.EmitKeyValue(word, "1");
            }
        }
    }

    //Reducer
    public class WordReducer : ReducerCombinerBase
    {
        //Accepts each key and count the occurrances
        public override void Reduce(string key, IEnumerable<string> values,
            ReducerCombinerContext context)
        {
            //Write back  
            context.EmitKeyValue(key, values.Count().ToString());
        }
    }

    //Our Word counter job
    public class WordCounterJob : HadoopJob<WordMapper, WordReducer>
    {
        public override HadoopJobConfiguration Configure(ExecutorContext context)
        {
            var config = new HadoopJobConfiguration();
            config.InputPath = "/user/input/TextFiles";
            config.OutputFolder = "/user/output/TextFiles";
            return config;
        }
    }
}
