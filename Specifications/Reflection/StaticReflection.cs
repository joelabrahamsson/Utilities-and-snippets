using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Machine.Specifications;
using Reflection;

namespace Specifications.Reflection
{
    [Subject(typeof(StaticReflection), "GetMemberName")]
    public class given_a_Func_returning_a_value_type_property
    {
        static string ExpectedName = "Length";
        static string returnedName;

        Because of
            = () => returnedName = StaticReflection.GetMemberName<string>(s => s.Length);

        It should_return_the_name_of_the_property
            = () => returnedName.ShouldEqual(ExpectedName);
    }

    [Subject(typeof(StaticReflection), "GetMemberName")]
    public class given_a_Func_returning_a_reference_type_property
    {
        static string ExpectedName = "Data";
        static string returnedName;

        Because of
            = () => returnedName = StaticReflection.GetMemberName<Exception>(x => x.Data);

        It should_return_the_name_of_the_property
            = () => returnedName.ShouldEqual(ExpectedName);
    }

    [Subject(typeof(StaticReflection), "GetMemberName")]
    public class given_a_Func_invoking_a_reference_type_method
    {
        static string ExpectedName = "Clone";
        static string returnedName;

        Because of
            = () => returnedName = StaticReflection.GetMemberName<string>(s => s.Clone());

        It should_return_the_name_of_the_method
            = () => returnedName.ShouldEqual(ExpectedName);
    }

    [Subject(typeof(StaticReflection), "GetMemberName")]
    public class given_a_Func_invoking_a_value_type_method
    {
        static string ExpectedName = "GetHashCode";
        static string returnedName;

        Because of
            = () => returnedName = StaticReflection.GetMemberName<string>(s => s.GetHashCode());

        It should_return_the_name_of_the_method
            = () => returnedName.ShouldEqual(ExpectedName);
    }

    [Subject(typeof(StaticReflection), "GetMemberName")]
    public class given_a_Func_invoking_a_void_method
    {
        static string ExpectedName = "Reverse";
        static string returnedName;

        Because of
            = () => returnedName = StaticReflection.GetMemberName<List<string>>(s => s.Reverse());

        It should_return_the_name_of_the_method
            = () => returnedName.ShouldEqual(ExpectedName);
    }

    [Subject(typeof(StaticReflection), "GetMemberName")]
    public class given_a_Func_invoking_a_method_with_a_parameter
    {
        static string ExpectedName = "LastIndexOf";
        static string returnedName;

        Because of
            = () => returnedName = StaticReflection.GetMemberName<string>(s => s.LastIndexOf(','));

        It should_return_the_name_of_the_method
            = () => returnedName.ShouldEqual(ExpectedName);
    }

    [Subject(typeof(StaticReflection), "GetMemberName")]
    public class called_with_null_cast_to_Func
    {
        static Exception thrownException;

        Establish Context
            = () => thrownException = Catch.Exception(() => StaticReflection.GetMemberName((Expression<Func<string, object>>)null));

        It should_throw_an_exception
            = () => thrownException.ShouldNotBeNull();

        It should_throw_an_ArgumentException
            = () => thrownException.ShouldBeOfType<ArgumentException>();
    }

    [Subject(typeof(StaticReflection), "GetMemberName")]
    public class called_with_null_cast_to_Action
    {
        static Exception thrownException;

        Establish Context
            = () => thrownException = Catch.Exception(() => StaticReflection.GetMemberName((Expression<Action<string>>)null));

        It should_throw_an_exception
            = () => thrownException.ShouldNotBeNull();

        It should_throw_an_ArgumentException
            = () => thrownException.ShouldBeOfType<ArgumentException>();
    }

    [Subject(typeof(StaticReflection), "CreatePropertyLambda")]
    public class when_given_a_Func_returning_a_property_of_a_type2
    {
        static int expected = "Length".Length;
        static int actual;

        Establish Context
            = () =>
                {
                    LambdaExpression expression = StaticReflection.CreatePropertyLambda(typeof(string), "Length");
                    actual = (int) expression.Compile().DynamicInvoke("Length");
                };

        It should_return_the_name_of_the_property
            = () => actual.ShouldEqual(expected);
    }
}
