﻿using System;

namespace ALEXFW.Entity.CommonDictionary
{
    /// <summary>
    ///     用于约束列表条目属性的特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ListItemSpecification : Attribute
    {
        public ListItemSpecification(string listName, string orderSort, int width, bool useSortIndicatior)
        {
            ListName = listName;
            OrderSort = orderSort;
            Width = width;
            UseSortIndicator = useSortIndicatior;
        }

        public string ListName { get; set; } // 列表表头元素的名称
        public string OrderSort { get; set; } // 缺省排序
        public int Width { get; set; } // 列表列的宽度
        public bool UseSortIndicator { get; set; } // 是否使用升降序提示符
    }
}