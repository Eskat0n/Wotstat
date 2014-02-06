namespace Wotstat.Application.Boilerplate.Extensions.Web
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using Domain.Model.Entities;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public static class HtmlHelperStatisticExtensions
    {
        public static HtmlString DynamicDataTableRow(this HtmlHelper htmlHelper, IEnumerable<DynamicData> data, IEnumerable<Period> periods, Func<DynamicData, object> property)
        {
            var builder = new StringBuilder();
            var dataDictionary = data.ToDictionary(el => el.Period.Id);
            periods.Each(period =>
            {
                DynamicData currentRowData;
                if (dataDictionary.TryGetValue(period.Id, out currentRowData))
                {
                    builder.AppendFormat("<td>{0}</td>", property(currentRowData).ToString());
                    return;
                }
                builder.AppendFormat("<td></td>");
            });
            return new HtmlString(builder.ToString());
        }
    }
}