﻿using CIIP.Module.BusinessObjects.SYS.Logic;
using DevExpress.Data.Filtering;

namespace CIIP.Module.BusinessObjects.SYS
{
    public static class BusinessObjectQuickAddExtendesion
    {
        #region quick add
        public static Property AddProperty(this BusinessObject self,string name, BusinessObjectBase type, int? size = null)
        {
            var property = new Property(self.Session);
            property.PropertyType = type;
            property.名称 = name;
            if (size.HasValue)
                property.Size = size.Value;
            self.Properties.Add(property);
            return property;
        }

        public static Property AddProperty<T>(this BusinessObject self,string name, int? size = null)
        {
            return self.AddProperty(name,
                self.Session.FindObject<BusinessObjectBase>(new BinaryOperator("FullName", typeof(T).FullName))
                , size
                );
        }

        public static CollectionProperty AddAssociation(this BusinessObject self, string name, BusinessObject bo, bool isAggregated,Property relation)
        {
            var cp = new CollectionProperty(self.Session);
            self.CollectionProperties.Add(cp);
            cp.PropertyType = bo;
            cp.名称 = name;
            cp.Aggregated = isAggregated;
            cp.RelationProperty = relation;
            return cp;
        }

        public static ObjectAfterConstruction AddAfterConstruction(this BusinessObject self, string code)
        {
            var after = new ObjectAfterConstruction(self.Session);
            after.SetCode(code);
            self.Methods.Add(after);
            return after;
        }

        public static ObjectSavingEvent AddSavingEvent(this BusinessObject self, string code)
        {
            var after = new ObjectSavingEvent(self.Session);
            after.SetCode(code);
            self.Methods.Add(after);
            return after;
        }

        public static ObjectDeletingEvent AddDeletingEvent(this BusinessObject self, string code)
        {
            var after = new ObjectDeletingEvent(self.Session);
            after.SetCode(code);
            self.Methods.Add(after);
            return after;
        }

        public static ObjectPropertyChangedEvent AddPropertyChangedEvent(this BusinessObject self, string code)
        {
            var after = new ObjectPropertyChangedEvent(self.Session);
            after.SetCode(code);
            self.Methods.Add(after);
            return after;
        }
        public static ObjectSavedEvent AddObjectSavedEvent(this BusinessObject self, string code)
        {
            var after = new ObjectSavedEvent(self.Session);
            after.SetCode(code);
            self.Methods.Add(after);
            return after;
        }

        public static BusinessObjectPartialLogic AddPartialLogic(this BusinessObject self, string code,string usingBlock = null)
        {
            var logic = new BusinessObjectPartialLogic(self.Session);
            logic.BusinessObject = self;
            if (usingBlock == null)
            {
                code = BusinessObjectCodeGenerateExtendesion.CommonUsing() + code;
            }
            logic.Code = new CsharpCode(code, logic);
            return logic;
        }

        public static BusinessObjectLayout AddLayout(this BusinessObject self, string code, string usingBlock = null)
        {
            var logic = new BusinessObjectLayout(self.Session);
            logic.BusinessObject = self;
            if (usingBlock == null)
            {
                code = BusinessObjectCodeGenerateExtendesion.CommonUsing() + code;
            }
            logic.Code = new CsharpCode(code, logic);
            return logic;
        }

        #endregion
    }

#warning 需要验证属性名称不可以重名的情况.


#warning 此功能可以后续实现,当前可以使用复制功能直接copy已有布局
    // 业务类型上面,使用Attribute指定使用哪个布局模板
    // 系统起动时,检查所有使用了Attribute的类,遍历并进行更新

    //[LayoutTemplate(typeof(布局模板)] 
    //泛型参数类型应该是: 某单据,单据明细 两个类型.
    //这种情况,只支持两种类型,如果基类中有多个类型,就按顺序传入,反射取得,无需处理.
    //public class 某单据 :  ......
    //{
    //}
}