///////////////////////////////////////////////////////////
//  MapStyle.cs
//  Implementation of the Class MapStyle
//  Generated by Enterprise Architect
//  Created on:      13-2��-2017 0:22:34
//  Original author: Doku
///////////////////////////////////////////////////////////

using System.Collections.Generic;

namespace ECharts.Entities.bmap
{
    public class MapStyle
    {
        public IList<StyleJson> styleJson { get; set; }


        /// <param name="stylejson"></param>
        public MapStyle StyleJson(IList<StyleJson> styleJson)
        {
            this.styleJson = styleJson;
            return this;
        }
    } //end MapStyle
} //end namespace bmap