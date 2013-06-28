using System;
using System.Diagnostics;
using Common.Text;
using Machine.Specifications;

namespace Specifications.Text
{
    [Subject(typeof(StringExtensions), "CropWholeWords")]
    public class given_null
    {
        static Exception thrownException;

        Because of
            = () => thrownException = Catch.Exception(() => ((string)null).CropWholeWords(5));

        It should_thrown_an_ArgumentNullException
            = () => thrownException.ShouldBeOfType<ArgumentNullException>();
    }

    [Subject(typeof(StringExtensions), "CropWholeWords")]
    public class given_an_string_and_a_negative_length
    {
        static Exception thrownException;

        Because of
            = () => thrownException = Catch.Exception(() => ("yellow").CropWholeWords(-5));

        It should_thrown_an_ArgumentException
            = () => thrownException.ShouldBeOfType<ArgumentException>();
    }

    [Subject(typeof(StringExtensions), "CropWholeWords")]
    public class given_an_empty_string_and_a_positive_length
    {
        static string input = string.Empty;
        static string output;

        Because of
            = () => output = input.CropWholeWords(14);

        It should_return_an_empty_string
            = () => output.ShouldEqual(string.Empty);
    }

    [Subject(typeof(StringExtensions), "CropWholeWords")]
    public class given_the_string_yellow_bananas_and_length_14
    {
        static string input = "yellow bananas";
        static string output;

        Because of
            = () => output = input.CropWholeWords(14);

        It should_return_the_full_string
            = () => output.ShouldEqual(input);
    }

    [Subject(typeof(StringExtensions), "CropWholeWords")]
    public class given_the_string_yellow_bananas_and_length_15
    {
        static string input = "yellow bananas";
        static string output;

        Because of
            = () => output = input.CropWholeWords(15);

        It should_return_the_full_string
            = () => output.ShouldEqual(input);
    }

    [Subject(typeof(StringExtensions), "CropWholeWords")]
    public class given_the_string_yellow_bananas_and_length_6
    {
        static string input = "yellow bananas";
        static string output;

        Because of
            = () => output = input.CropWholeWords(6);

        It should_return_yellow
            = () => output.ShouldEqual("yellow");
    }

    [Subject(typeof(StringExtensions), "CropWholeWords")]
    public class given_the_string_yellow_bananas_and_length_7
    {
        static string input = "yellow bananas";
        static string output;

        Because of
            = () => output = input.CropWholeWords(7);

        It should_return_yellow
            = () => output.ShouldEqual("yellow");
    }

    [Subject(typeof(StringExtensions), "CropWholeWords")]
    public class given_the_string_yellow_bananas_and_length_8
    {
        static string input = "yellow bananas";
        static string output;

        Because of
            = () => output = input.CropWholeWords(8);

        It should_return_yellow
            = () => output.ShouldEqual("yellow");
    }

    [Subject(typeof(StringExtensions), "CropWholeWords")]
    public class given_the_string_yellow_bananas_and_length_5
    {
        static string input = "yellow bananas";
        static string output;

        Because of
            = () => output = input.CropWholeWords(5);

        It should_return_yello
            = () => output.ShouldEqual("yello");
    }

    [Subject(typeof(StringExtensions), "CropWholeWords")]
    public class given_the_string_I_am_a_cat__and_length_5
    {
        static string input = "I am a cat";
        static string output;

        Because of
            = () => output = input.CropWholeWords(5);

        It should_return_I_am
            = () => output.ShouldEqual("I am");
    }
    
    [Subject(typeof(StringExtensions), "CropWholeWords")]
    public class given_the_string_yellow_bananas_comma_and_length_14
    {
        static string input = "yellow bananas,";
        static string output;

        Because of
            = () => output = input.CropWholeWords(14);

        It should_return_yellow_bananas
            = () => output.ShouldEqual("yellow bananas");
    }

    [Subject(typeof(StringExtensions), "CropWholeWords")]
    public class given_the_string_yellow_bananas_period_and_length_14
    {
        static string input = "yellow bananas.";
        static string output;

        Because of
            = () => output = input.CropWholeWords(14);

        It should_return_yellow_bananas
            = () => output.ShouldEqual("yellow bananas");
    }

    [Subject(typeof(StringExtensions), "CropWholeWords")]
    public class given_the_string_yellow_bananas_colon_and_length_14
    {
        static string input = "yellow bananas:";
        static string output;

        Because of
            = () => output = input.CropWholeWords(14);

        It should_return_yellow_bananas
            = () => output.ShouldEqual("yellow bananas");
    }

    [Subject(typeof(StringExtensions), "CropWholeWords")]
    public class given_the_string_yellow_bananas_semicolon_and_length_14
    {
        static string input = "yellow bananas;";
        static string output;

        Because of
            = () => output = input.CropWholeWords(14);

        It should_return_yellow_bananas
            = () => output.ShouldEqual("yellow bananas");
    }

    [Subject(typeof(StringExtensions), "CropWholeWords")]
    public class given_the_string_yellow_comma_and_length_6
    {
        static string input = "yellow,";
        static string output;

        Because of
            = () => output = input.CropWholeWords(6);

        It should_return_yellow
            = () => output.ShouldEqual("yellow");
    }

    [Subject(typeof(StringExtensions), "CropWholeWords")]
    public class given_the_string_yellow_period_bananas_and_length_8
    {
        static string input = "yellow.bananas";
        static string output;

        Because of
            = () => output = input.CropWholeWords(8);

        It should_return_bananas_period_b
            = () => output.ShouldEqual("yellow.b");
    }

    [Subject(typeof(StringExtensions), "CropWholeWords")]
    public class when_invoked_with_a_fairly_long_string_ten_thousand_times
    {
        static string input = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum. It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like). There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.";
        static long elapsedMilliseconds;

        Because of
            = () =>
                {
                    var timer = new Stopwatch();
                    timer.Start();
                    for (int i = 0; i < 10000; i++)
                    {
                        input.CropWholeWords(input.Length - 10);
                    }
                    timer.Stop();
                    elapsedMilliseconds = timer.ElapsedMilliseconds;
                };

        It should_return_yellow = () =>
                {
                    throw new Exception(elapsedMilliseconds.ToString());
                };
    }
}
