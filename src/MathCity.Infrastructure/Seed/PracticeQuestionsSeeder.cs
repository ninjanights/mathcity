using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Seed;

public static class PracticeQuestionSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (await context.PracticeQuestions.AnyAsync())
            return;

        var lessonList = await context.Lessons
            .Include(l => l.Topic)
            .ToListAsync();


        Console.WriteLine("------------------- LESSON SLUGS -------------------");

        foreach (var lesson in lessonList.OrderBy(l => l.Slug))
        {
            Console.WriteLine($"{lesson.Slug} -> {lesson.Title}");
        }

        Console.WriteLine("-------------------");

        var duplicateSlugs = lessonList
            .GroupBy(l => l.Slug)
            .Where(g => g.Count() > 1)
            .ToList();

        if (duplicateSlugs.Any())
        {
            Console.WriteLine("------------------- DUPLICATE LESSON SLUGS -------------------");

            foreach (var group in duplicateSlugs)
            {
                Console.WriteLine($"\nLesson: {group.Key}");

                foreach (var l in group)
                {
                    Console.WriteLine($"  Topic: {l.Topic.Title}");
                }
            }

            Console.WriteLine("-------------------");
        }
        else
        {
            Console.WriteLine("------------------- No duplicate lesson slugs found.");
        }

        var questions = new List<PracticeQuestion>();

        void AddQuestion(
            string lessonSlug,
            string question,
            string optionA,
            string optionB,
            string optionC,
            string optionD,
            QuestionOption correctAnswer,
            string explanation,
            DifficultyLevel difficulty,
            int displayOrder)
        {
            var lesson = lessonList.SingleOrDefault(l => l.Slug == lessonSlug);

            if (lesson == null)
            {
                Console.WriteLine($"------------------- Lesson not found: {lessonSlug}");
                throw new Exception($"------------------- Lesson not found: {lessonSlug}");
            }

            questions.Add(new PracticeQuestion
            {
                LessonId = lesson.Id,
                Question = question,
                OptionA = optionA,
                OptionB = optionB,
                OptionC = optionC,
                OptionD = optionD,
                CorrectAnswer = correctAnswer,
                Explanation = explanation,
                Difficulty = difficulty,
                DisplayOrder = displayOrder
            });

            Console.WriteLine(
     $"ADD -> {lesson.Slug} | {lesson.Title} | {displayOrder} | {question}");
        }

        AddQuestion(
            "introduction-to-algebraic-expressions",
            "Which of the following is an algebraic expression?",
            "5 + 3 = 8", "2x + 7", "10 > 6", "x = 5",
            QuestionOption.B,
            "An algebraic expression contains numbers, variables, and operations without an equality or inequality sign.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "simplifying-and-evaluating-algebraic-expressions",
            "Simplify: 3x + 5x - 2",
            "8x - 2", "8x + 2", "6x - 2", "15x - 2",
            QuestionOption.A,
            "Combine like terms: 3x + 5x = 8x, so the expression simplifies to 8x - 2.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "applications-and-practice-of-algebraic-expressions",
            "A phone plan costs $20 plus $0.10 per minute. Which expression gives the cost for m minutes?",
            "20 + 0.10m", "20m + 0.10", "0.10 - 20m", "20 - 0.10m",
            QuestionOption.A,
            "The fixed fee 20 is added to the per-minute rate 0.10 times the number of minutes m.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "introduction-to-linear-equations",
            "Which equation is a linear equation in one variable?",
            "x^2 + 1 = 0", "2x + 3 = 7", "xy = 5", "1/x = 2",
            QuestionOption.B,
            "A linear equation has variables raised only to the first power, like 2x + 3 = 7.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "solving-linear-equations",
            "Solve for x: 3x - 4 = 11",
            "x = 3", "x = 5", "x = 15", "x = 7",
            QuestionOption.B,
            "Add 4 to both sides to get 3x = 15, then divide by 3 to get x = 5.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "applications-and-practice-of-linear-equations",
            "Twice a number plus 6 equals 20. What is the number?",
            "5", "6", "7", "8",
            QuestionOption.C,
            "2x + 6 = 20 gives 2x = 14, so x = 7.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "introduction-to-simultaneous-equations",
            "Simultaneous equations are a set of equations that must be solved:",
            "One at a time in any order", "Together, satisfying all equations at once", "By ignoring one variable", "Using only graphs",
            QuestionOption.B,
            "Simultaneous equations share variables whose values must satisfy every equation in the set at the same time.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "methods-for-solving-simultaneous-equations",
            "Which method eliminates a variable by adding or subtracting the equations?",
            "Substitution", "Elimination", "Graphing", "Factoring",
            QuestionOption.B,
            "The elimination method combines equations to cancel one variable, leaving a single-variable equation.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-simultaneous-equations",
            "Two numbers add to 10 and differ by 2. What are the numbers?",
            "4 and 6", "3 and 7", "5 and 5", "2 and 8",
            QuestionOption.A,
            "Solving x + y = 10 and x - y = 2 gives x = 6, y = 4.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "introduction-to-inequalities",
            "Which symbol represents 'greater than or equal to'?",
            "<", ">", "<=", ">=",
            QuestionOption.D,
            "The symbol >= means the left side is greater than or equal to the right side.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "solving-and-graphing-inequalities",
            "Solve: 2x + 3 < 11",
            "x < 4", "x < 5", "x > 4", "x > 5",
            QuestionOption.A,
            "Subtract 3 from both sides to get 2x < 8, then divide by 2 to get x < 4.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "applications-and-practice-of-inequalities",
            "A lift can carry at most 500 kg. If each person weighs 70 kg, which inequality models the maximum number of people n?",
            "70n <= 500", "70n >= 500", "70 + n <= 500", "n <= 70",
            QuestionOption.A,
            "The total weight, 70 times the number of people, must not exceed the 500 kg limit.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "introduction-to-quadratic-equations",
            "Which of the following is the standard form of a quadratic equation?",
            "ax + b = 0", "ax^2 + bx + c = 0", "ax^3 + b = 0", "a/x + b = 0",
            QuestionOption.B,
            "A quadratic equation has the standard form ax^2 + bx + c = 0, with a not equal to 0.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "methods-for-solving-quadratic-equations",
            "Which formula gives the roots of ax^2 + bx + c = 0 directly?",
            "x = -b/a", "x = (-b +/- sqrt(b^2 - 4ac)) / 2a", "x = b^2 - 4ac", "x = c/a",
            QuestionOption.B,
            "The quadratic formula solves any quadratic equation for x using its coefficients a, b, and c.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-quadratic-equations",
            "A ball's height is h = -5t^2 + 20t. At what time does it return to the ground (h = 0, t > 0)?",
            "t = 2", "t = 4", "t = 5", "t = 10",
            QuestionOption.B,
            "Setting -5t^2 + 20t = 0 gives t(-5t + 20) = 0, so t = 0 or t = 4; the ball lands at t = 4.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-polynomials",
            "What is the degree of the polynomial 4x^3 - 2x + 7?",
            "1", "2", "3", "4",
            QuestionOption.C,
            "The degree of a polynomial is the highest power of the variable, which here is 3.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "polynomial-operations-and-factorization",
            "Factor: x^2 - 9",
            "(x-3)(x+3)", "(x-9)(x+1)", "(x-3)^2", "(x+9)(x-1)",
            QuestionOption.A,
            "This is a difference of squares: x^2 - 9 = x^2 - 3^2 = (x-3)(x+3).",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-polynomials",
            "The volume of a box is x^3 + 3x^2. Which factorization shows a common dimension?",
            "x^2(x + 3)", "x(x^2 + 3)", "3x^2(x + 1)", "x^2(x - 3)",
            QuestionOption.A,
            "Factoring out the common term x^2 gives x^2(x + 3), the largest common factor of both terms.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-factorization",
            "Factorization means rewriting an expression as a:",
            "Sum of terms", "Product of simpler factors", "Single variable", "Fraction",
            QuestionOption.B,
            "Factorization expresses an algebraic expression as a product of two or more simpler factors.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "methods-of-factorization",
            "Which method factors ax + ay + bx + by by pairing terms?",
            "Grouping", "Completing the square", "Long division", "Substitution",
            QuestionOption.A,
            "Grouping pairs terms with common factors, e.g. a(x+y) + b(x+y) = (a+b)(x+y).",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-factorization",
            "Solve x^2 - 5x + 6 = 0 by factorization.",
            "x = 1, 6", "x = 2, 3", "x = -2, -3", "x = 5, 6",
            QuestionOption.B,
            "Factoring gives (x-2)(x-3) = 0, so x = 2 or x = 3.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-rational-expressions",
            "A rational expression is a fraction where the numerator and denominator are:",
            "Both constants", "Polynomials", "Both radicals", "Both exponents",
            QuestionOption.B,
            "A rational expression is a ratio of two polynomials, such as (x+1)/(x-2).",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "simplifying-and-operating-on-rational-expressions",
            "Simplify: (x^2 - 4)/(x - 2)",
            "x + 2", "x - 2", "x^2", "x + 4",
            QuestionOption.A,
            "Factor the numerator as (x-2)(x+2), then cancel the common factor (x-2) to get x+2.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-rational-expressions",
            "For what value of x is the expression 3/(x - 5) undefined?",
            "x = 0", "x = 3", "x = 5", "x = -5",
            QuestionOption.C,
            "A rational expression is undefined when its denominator equals zero, so x - 5 = 0 gives x = 5.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-exponents",
            "In the expression 2^5, what does the number 5 represent?",
            "The base", "The exponent", "The product", "The coefficient",
            QuestionOption.B,
            "The exponent (5) tells how many times the base (2) is multiplied by itself.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "laws-and-operations-of-exponents",
            "Simplify: x^5 / x^2",
            "x^3", "x^7", "x^2.5", "x^10",
            QuestionOption.A,
            "When dividing powers with the same base, subtract exponents: x^(5-2) = x^3.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-exponents",
            "A population doubles every year starting at 100. Which expression gives the population after t years?",
            "100t", "100 + 2t", "100 * 2^t", "100^t",
            QuestionOption.C,
            "Doubling repeatedly is exponential growth, modeled by initial value times the growth factor raised to t.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-radicals-and-surds",
            "Which of the following is an example of a surd?",
            "sqrt(4)", "sqrt(9)", "sqrt(2)", "sqrt(16)",
            QuestionOption.C,
            "A surd is an irrational root that cannot be simplified to a whole number, like sqrt(2).",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "simplifying-and-operating-on-radicals",
            "Simplify: sqrt(50)",
            "5*sqrt(2)", "2*sqrt(5)", "10*sqrt(5)", "25*sqrt(2)",
            QuestionOption.A,
            "sqrt(50) = sqrt(25*2) = sqrt(25)*sqrt(2) = 5*sqrt(2).",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-radicals-and-surds",
            "Rationalize the denominator of 1/sqrt(3).",
            "sqrt(3)/3", "1/3", "3/sqrt(3)", "sqrt(3)",
            QuestionOption.A,
            "Multiplying numerator and denominator by sqrt(3) gives sqrt(3)/3, removing the radical from the denominator.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-logarithms",
            "log base b of x equals y means:",
            "b = x^y", "x = b^y", "y = x^b", "x = y^b",
            QuestionOption.B,
            "A logarithm answers the exponent question: log_b(x) = y means b raised to y equals x.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "laws-and-properties-of-logarithms",
            "Simplify using log laws: log(a) + log(b)",
            "log(a - b)", "log(ab)", "log(a/b)", "log(a) * log(b)",
            QuestionOption.B,
            "The product rule of logarithms states log(a) + log(b) = log(ab).",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-logarithms",
            "The Richter scale uses logarithms because earthquake intensity varies:",
            "Linearly", "Over an extremely wide range", "Only between 1 and 10", "Randomly with no pattern",
            QuestionOption.B,
            "Logarithms compress an enormous range of intensity values into a manageable scale, as with the Richter scale.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-absolute-value",
            "What is the absolute value of -7?",
            "-7", "0", "7", "1/7",
            QuestionOption.C,
            "Absolute value measures distance from zero, so |-7| = 7.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "operations-and-equations-with-absolute-value",
            "Solve: |x - 3| = 5",
            "x = 8 only", "x = -2 only", "x = 8 or x = -2", "x = 2 or x = -8",
            QuestionOption.C,
            "Absolute value equations split into two cases: x - 3 = 5 or x - 3 = -5, giving x = 8 or x = -2.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-absolute-value",
            "A machine part must be 10 cm long with an error of at most 0.5 cm. Which inequality models this?",
            "|x - 10| <= 0.5", "|x + 10| <= 0.5", "|x - 0.5| <= 10", "|x| <= 10.5",
            QuestionOption.A,
            "The allowed deviation from the target length 10 is captured by |x - 10| <= 0.5.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-algebraic-identities",
            "Which of these is a standard algebraic identity?",
            "(a+b)^2 = a^2 + 2ab + b^2", "(a+b)^2 = a^2 + b^2", "(a+b)^2 = 2a + 2b", "(a+b)^2 = ab",
            QuestionOption.A,
            "This is the well-known identity for the square of a binomial sum.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "applying-algebraic-identities",
            "Use an identity to expand (x - 4)(x + 4).",
            "x^2 - 16", "x^2 + 16", "x^2 - 8x - 16", "x^2 + 8x - 16",
            QuestionOption.A,
            "This matches the difference of squares identity (a-b)(a+b) = a^2 - b^2, giving x^2 - 16.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-algebraic-identities",
            "Use identities to quickly compute 102^2.",
            "10404", "10204", "10402", "10004",
            QuestionOption.A,
            "102^2 = (100+2)^2 = 100^2 + 2(100)(2) + 2^2 = 10000 + 400 + 4 = 10404.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-limits",
            "The limit of a function as x approaches a value describes:",
            "The function's value only at that point", "The value the function approaches near that point", "The derivative at that point", "The total area under the curve",
            QuestionOption.B,
            "A limit describes the value a function gets close to as the input approaches a given point, whether or not it equals it there.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "calculating-and-evaluating-limits",
            "Evaluate: lim(x->2) (x^2 - 4)/(x - 2)",
            "0", "2", "4", "Undefined",
            QuestionOption.C,
            "Factor the numerator: (x-2)(x+2)/(x-2) = x+2, which approaches 4 as x approaches 2.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-limits",
            "Limits are foundational to calculus because they define both:",
            "Derivatives and integrals", "Only polynomials", "Only trigonometric functions", "Only matrices",
            QuestionOption.A,
            "Both the derivative and the definite integral are formally defined using limits.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-continuity",
            "A function is continuous at a point if there is no:",
            "Slope", "Break, jump, or hole in its graph there", "Positive value", "Derivative",
            QuestionOption.B,
            "Continuity at a point means the graph can be drawn through that point without lifting the pen.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "properties-and-types-of-continuity",
            "Which condition is NOT required for continuity at x = a?",
            "f(a) is defined", "lim(x->a) f(x) exists", "lim(x->a) f(x) equals f(a)", "f'(a) is defined",
            QuestionOption.D,
            "Continuity requires the function value and limit to exist and match; differentiability is a separate, stronger condition.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-continuity",
            "Continuity assumptions are important in engineering because they guarantee:",
            "Predictable, gradual changes in a system without sudden jumps", "Exact numerical answers always", "That derivatives never exist", "That functions are always linear",
            QuestionOption.A,
            "Continuous models ensure physical quantities like temperature or stress change gradually rather than jumping unpredictably.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-differentiation",
            "The derivative of a function at a point represents its:",
            "Average value", "Instantaneous rate of change", "Maximum value", "Total area",
            QuestionOption.B,
            "The derivative gives the instantaneous rate of change, i.e., the slope of the tangent line at that point.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "rules-and-techniques-of-differentiation",
            "Differentiate: f(x) = x^3",
            "3x^2", "x^2", "3x", "x^4/4",
            QuestionOption.A,
            "Using the power rule, d/dx[x^n] = n*x^(n-1), so the derivative of x^3 is 3x^2.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-differentiation",
            "Derivatives are used in economics to find the:",
            "Marginal cost of production", "Total cost only", "Fixed cost only", "Break-even quantity only",
            QuestionOption.A,
            "The derivative of a cost function gives the marginal cost, the rate cost changes per additional unit.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-applications-of-derivatives",
            "Derivatives are commonly used to find where a function is:",
            "Increasing, decreasing, or has extrema", "Always zero", "Undefined everywhere", "Symmetric",
            QuestionOption.A,
            "The sign of the derivative reveals whether a function is increasing or decreasing, and where it has maxima or minima.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "optimization-and-related-rates",
            "To find a maximum or minimum of a differentiable function, you typically set:",
            "f(x) = 0", "f'(x) = 0", "f''(x) = x", "f(x) = f'(x)",
            QuestionOption.B,
            "Critical points, candidates for extrema, occur where the derivative is zero (or undefined).",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-derivatives",
            "A company wants to minimize packaging material for a fixed volume. This is an example of:",
            "A related rates problem", "An optimization problem", "A continuity problem", "A limit-only problem",
            QuestionOption.B,
            "Minimizing material for a fixed volume is a classic optimization problem solved using derivatives.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-indefinite-integration",
            "An indefinite integral of a function represents:",
            "A single number", "A family of antiderivatives plus a constant C", "The area under one specific interval", "The derivative of the function",
            QuestionOption.B,
            "Indefinite integration reverses differentiation, producing a general antiderivative plus an arbitrary constant C.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "methods-and-techniques-of-indefinite-integration",
            "Evaluate: integral of x^2 dx",
            "x^3 + C", "x^3/3 + C", "2x + C", "x^2/2 + C",
            QuestionOption.B,
            "Using the power rule for integration, integral of x^n dx = x^(n+1)/(n+1) + C, giving x^3/3 + C.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-indefinite-integration",
            "Given velocity v(t), integrating v(t) with respect to t gives:",
            "Acceleration", "Position (plus a constant)", "Jerk", "Force",
            QuestionOption.B,
            "Since velocity is the derivative of position, integrating velocity recovers position up to a constant.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-definite-integration",
            "A definite integral of f(x) from a to b represents:",
            "The slope of f at x = a", "The accumulated area between f and the x-axis from a to b", "The derivative of f at b", "A single point on the graph",
            QuestionOption.B,
            "A definite integral computes the net signed area under the curve between the two bounds a and b.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "fundamental-theorem-and-evaluation-of-definite-integrals",
            "Evaluate: integral from 0 to 2 of x dx",
            "1", "2", "4", "8",
            QuestionOption.B,
            "The antiderivative is x^2/2; evaluating from 0 to 2 gives 4/2 - 0 = 2.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-definite-integration",
            "Definite integrals are used to compute the total distance travelled given a:",
            "Position function only", "Speed function over an interval", "Constant only", "Second derivative only",
            QuestionOption.B,
            "Integrating a speed (or velocity magnitude) function over time gives the total distance travelled.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-applications-of-integration",
            "Integration lets us calculate accumulated quantities such as:",
            "Instantaneous slope", "Total area or accumulated change over an interval", "A single derivative value", "Discontinuities",
            QuestionOption.B,
            "Integration accumulates infinitesimal contributions to find totals like area, volume, or total change.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "area-volume-and-real-world-applications-of-integration",
            "To find the area between two curves f(x) and g(x) on [a,b] where f(x) >= g(x), you compute:",
            "Integral of f(x) + g(x) dx", "Integral of (f(x) - g(x)) dx", "Integral of f(x) * g(x) dx", "f(b) - g(a)",
            QuestionOption.B,
            "The area between two curves is the integral of the difference between the upper and lower functions.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "advanced-applications-and-practice-of-integration",
            "The volume of a solid of revolution can be found using the:",
            "Disk or shell method", "Chain rule", "Product rule", "Limit comparison test",
            QuestionOption.A,
            "Rotating a region about an axis and integrating cross-sectional disks or shells gives the resulting volume.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-parametric-equations",
            "In parametric equations, x and y are both expressed in terms of a:",
            "Third variable, the parameter", "Constant only", "Single equation y = f(x)", "Matrix",
            QuestionOption.A,
            "Parametric equations describe x and y separately as functions of an independent parameter, often t.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "graphing-and-differentiating-parametric-equations",
            "For x = t^2 and y = 2t, what is dy/dx?",
            "1/t", "t", "2t", "1/(2t)",
            QuestionOption.A,
            "dy/dx = (dy/dt)/(dx/dt) = 2/(2t) = 1/t.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-parametric-equations",
            "Parametric equations are especially useful for describing:",
            "The motion of an object over time", "Only straight lines", "Only circles", "Constants",
            QuestionOption.A,
            "Because x and y are both functions of a shared parameter like time, parametric equations naturally model motion.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-polar-coordinates",
            "In polar coordinates, a point is described by:",
            "(x, y)", "(r, theta)", "(r, s)", "(a, b, c)",
            QuestionOption.B,
            "Polar coordinates locate a point using a radius r from the origin and an angle theta from the positive x-axis.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "graphs-and-transformations-in-polar-coordinates",
            "The Cartesian x-coordinate in terms of polar coordinates is:",
            "r * sin(theta)", "r * cos(theta)", "r + theta", "r / theta",
            QuestionOption.B,
            "The conversion formulas are x = r*cos(theta) and y = r*sin(theta).",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-polar-coordinates",
            "Polar coordinates are especially convenient for describing:",
            "Rectangular grids", "Circular and spiral motion", "Linear functions only", "Straight-line distances only",
            QuestionOption.B,
            "Curves with rotational symmetry, like circles and spirals, are often much simpler to express in polar form.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-multivariable-calculus",
            "Multivariable calculus extends calculus to functions of:",
            "One variable only", "Two or more variables", "No variables", "Only time",
            QuestionOption.B,
            "Multivariable calculus studies functions that depend on several independent variables at once, like f(x,y).",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "partial-derivatives-and-multiple-integrals",
            "A partial derivative of f(x,y) with respect to x is found by:",
            "Treating y as a constant and differentiating with respect to x", "Treating x as a constant", "Integrating with respect to y", "Setting x = y",
            QuestionOption.A,
            "Partial differentiation holds all other variables fixed while differentiating with respect to the chosen variable.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-multivariable-calculus",
            "The gradient of a multivariable function points in the direction of:",
            "Steepest descent", "Steepest ascent", "No change", "Zero slope always",
            QuestionOption.B,
            "The gradient vector points in the direction in which the function increases most rapidly.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-imaginary-numbers",
            "What is the value of i, the imaginary unit?",
            "sqrt(-1)", "sqrt(1)", "-1", "1",
            QuestionOption.A,
            "The imaginary unit i is defined as the square root of -1, so that i^2 = -1.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "operations-with-imaginary-numbers",
            "Simplify: i^3",
            "1", "-1", "i", "-i",
            QuestionOption.D,
            "i^2 = -1, so i^3 = i^2 * i = -1 * i = -i.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-imaginary-numbers",
            "Imaginary numbers are widely used in electrical engineering to represent:",
            "Resistance only", "AC circuit impedance with phase", "Physical mass", "Time only",
            QuestionOption.B,
            "In AC circuit analysis, imaginary numbers represent the phase relationship between voltage and current in impedance.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-the-complex-plane",
            "In the complex plane, the horizontal axis represents the:",
            "Imaginary part", "Real part", "Modulus", "Argument",
            QuestionOption.B,
            "The complex plane plots the real part on the horizontal axis and the imaginary part on the vertical axis.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "plotting-and-operations-on-the-complex-plane",
            "Where is the complex number 3 - 4i plotted on the complex plane?",
            "3 units right, 4 units up", "3 units right, 4 units down", "3 units left, 4 units up", "4 units right, 3 units down",
            QuestionOption.B,
            "The real part 3 gives the horizontal position and the imaginary part -4 gives 4 units downward.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-the-complex-plane",
            "Multiplying a complex number by i corresponds geometrically to a rotation of:",
            "0 degrees", "90 degrees", "180 degrees", "270 degrees",
            QuestionOption.B,
            "Multiplying by i rotates a point on the complex plane counterclockwise by 90 degrees.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-polar-form-of-complex-numbers",
            "The polar form of a complex number is written as:",
            "a + bi", "r(cos(theta) + i*sin(theta))", "r * theta", "a - bi",
            QuestionOption.B,
            "Polar form expresses a complex number using its modulus r and argument theta.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "converting-and-operating-with-polar-form",
            "In polar form, multiplying two complex numbers means their moduli are multiplied and their arguments are:",
            "Multiplied", "Subtracted", "Added", "Divided",
            QuestionOption.C,
            "When multiplying complex numbers in polar form, moduli multiply and arguments add.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-polar-form",
            "Polar form is especially convenient for complex number:",
            "Addition", "Subtraction", "Multiplication and division", "Only equality checks",
            QuestionOption.C,
            "Multiplication and division of complex numbers become simple modulus and argument operations in polar form.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-modulus-and-argument",
            "The modulus of a complex number a + bi is:",
            "a + b", "sqrt(a^2 + b^2)", "a - b", "a * b",
            QuestionOption.B,
            "The modulus is the distance from the origin, calculated as sqrt(a^2 + b^2).",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "calculating-modulus-and-argument",
            "Find the modulus of 3 + 4i.",
            "5", "7", "12", "25",
            QuestionOption.A,
            "sqrt(3^2 + 4^2) = sqrt(9+16) = sqrt(25) = 5.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-modulus-and-argument",
            "In signal processing, the modulus of a complex number often represents the signal's:",
            "Phase only", "Amplitude", "Frequency only", "Time delay only",
            QuestionOption.B,
            "The modulus of a complex representation typically corresponds to the amplitude, or magnitude, of the signal.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-de-moivres-theorem",
            "De Moivre's Theorem relates powers of complex numbers to:",
            "Their real part only", "Their modulus and argument in polar form", "Matrix multiplication", "Logarithms only",
            QuestionOption.B,
            "The theorem states (r(cos theta + i sin theta))^n = r^n(cos n*theta + i sin n*theta).",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "using-de-moivres-theorem",
            "Using De Moivre's Theorem, (cos 30 + i sin 30)^3 equals:",
            "cos 90 + i sin 90", "cos 30 + i sin 30", "cos 10 + i sin 10", "cos 3 + i sin 3",
            QuestionOption.A,
            "Raising to the power 3 multiplies the angle by 3, giving cos(3*30) + i sin(3*30) = cos 90 + i sin 90.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-de-moivres-theorem",
            "De Moivre's Theorem is especially useful for deriving formulas for:",
            "Multiple angle trigonometric identities", "Matrix determinants", "Set unions", "Linear regression",
            QuestionOption.A,
            "Expanding De Moivre's Theorem gives identities relating cos(n*theta) and sin(n*theta) to powers of sine and cosine.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-roots-of-complex-numbers",
            "A complex number has how many distinct nth roots?",
            "1", "n", "2n", "n^2",
            QuestionOption.B,
            "Every nonzero complex number has exactly n distinct nth roots, evenly spaced around a circle.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "finding-roots-using-polar-form",
            "To find the nth roots of a complex number in polar form, you take the nth root of r and:",
            "Divide the argument by n, adding multiples of 360/n degrees", "Multiply the argument by n", "Add n to the argument", "Ignore the argument",
            QuestionOption.A,
            "Each root's angle is (theta + 360k)/n for k = 0, 1, ..., n-1, spacing the roots evenly.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-complex-roots",
            "The nth roots of unity are evenly spaced points on:",
            "A straight line", "The unit circle in the complex plane", "The real number line only", "A parabola",
            QuestionOption.B,
            "The n solutions to z^n = 1 all have modulus 1 and are equally spaced around the unit circle.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-complex-functions",
            "A complex function maps:",
            "Real numbers to real numbers only", "Complex numbers to complex numbers", "Matrices to scalars", "Sets to sets",
            QuestionOption.B,
            "A complex function takes a complex input and produces a complex output, extending real functions into the complex domain.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "properties-and-transformations-of-complex-functions",
            "A complex function that is differentiable everywhere in its domain is called:",
            "Continuous", "Analytic (holomorphic)", "Rational", "Bounded",
            QuestionOption.B,
            "Functions that are complex-differentiable throughout an open region are called analytic or holomorphic.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-complex-functions",
            "Complex functions are used in fluid dynamics to model:",
            "Two-dimensional potential flow", "Only solid mechanics", "Discrete probability", "Set membership",
            QuestionOption.A,
            "Complex analytic functions elegantly describe two-dimensional, irrotational fluid flow patterns.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-cartesian-plane",
            "The Cartesian plane is divided into how many quadrants?",
            "2", "3", "4", "6",
            QuestionOption.C,
            "The two perpendicular axes divide the Cartesian plane into four quadrants.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "understanding-coordinates-and-quadrants",
            "In which quadrant does the point (-3, 4) lie?",
            "Quadrant I", "Quadrant II", "Quadrant III", "Quadrant IV",
            QuestionOption.B,
            "A negative x and positive y coordinate places the point in Quadrant II.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-cartesian-plane",
            "GPS mapping systems rely on coordinate systems similar to the Cartesian plane to:",
            "Pinpoint exact locations", "Measure temperature", "Store passwords", "Encrypt data",
            QuestionOption.A,
            "Coordinate systems let mapping technology represent locations as precise, plottable ordered pairs.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-distance-formula",
            "The distance formula is derived from which theorem?",
            "Pythagorean theorem", "Binomial theorem", "Fundamental theorem of calculus", "De Moivre's theorem",
            QuestionOption.A,
            "The distance formula comes directly from applying the Pythagorean theorem to the horizontal and vertical legs.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "solving-problems-using-distance-formula",
            "Find the distance between (0,0) and (3,4).",
            "5", "7", "12", "25",
            QuestionOption.A,
            "Distance = sqrt((3-0)^2 + (4-0)^2) = sqrt(9+16) = sqrt(25) = 5.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-distance-formula",
            "The distance formula can be used in navigation to calculate the:",
            "Straight-line distance between two points", "Speed of travel", "Fuel consumption", "Time zone difference",
            QuestionOption.A,
            "Given two coordinate locations, the distance formula computes the direct straight-line distance between them.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-midpoint-formula",
            "The midpoint formula finds the point that is:",
            "Closest to the origin", "Exactly halfway between two points", "Farthest from both points", "On the x-axis only",
            QuestionOption.B,
            "The midpoint formula averages the x-coordinates and y-coordinates to find the exact center of a segment.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "solving-problems-using-midpoint-formula",
            "Find the midpoint of (2, 4) and (6, 8).",
            "(4, 6)", "(3, 5)", "(8, 12)", "(2, 4)",
            QuestionOption.A,
            "Midpoint = ((2+6)/2, (4+8)/2) = (4, 6).",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-midpoint-formula",
            "The midpoint formula is useful in design for finding the:",
            "Center point of a structural element", "Total length of an element", "Slope of a beam", "Area of a shape",
            QuestionOption.A,
            "Designers use the midpoint formula to locate the exact center of a segment, such as a beam or wall.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-section-formula",
            "The section formula finds a point that divides a segment in a given:",
            "Angle", "Ratio", "Slope", "Area",
            QuestionOption.B,
            "The section formula locates the point that splits a line segment into a specified ratio.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "solving-problems-using-section-formula",
            "Find the point dividing the segment from (0,0) to (10,0) in the ratio 1:1.",
            "(5, 0)", "(10, 0)", "(0, 5)", "(2, 0)",
            QuestionOption.A,
            "A 1:1 ratio means the midpoint, which is ((0+10)/2, (0+0)/2) = (5, 0).",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-section-formula",
            "In construction, the section formula can help locate a support that divides a beam in a specific:",
            "Load ratio along its length", "Color scheme", "Material cost", "Time schedule",
            QuestionOption.A,
            "The section formula precisely places a point along a segment according to a required ratio, useful for supports.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-straight-line",
            "The slope-intercept form of a line is written as:",
            "y = mx + c", "ax + by = c", "y - y1 = m(x - x1)", "x/a + y/b = 1",
            QuestionOption.A,
            "Slope-intercept form, y = mx + c, directly shows the slope m and y-intercept c.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "equations-and-properties-of-straight-lines",
            "What is the slope of the line passing through (1,2) and (3,6)?",
            "1", "2", "3", "4",
            QuestionOption.B,
            "Slope = (6-2)/(3-1) = 4/2 = 2.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-straight-lines",
            "A company's cost model is linear: C = 50 + 5x. The slope 5 represents the:",
            "Fixed cost", "Cost per additional unit", "Total revenue", "Break-even point",
            QuestionOption.B,
            "In a linear cost model, the slope represents the marginal (per-unit) cost of production.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-pair-of-straight-lines",
            "A pair of straight lines through the origin can be represented by a general equation of degree:",
            "One", "Two", "Three", "Four",
            QuestionOption.B,
            "A homogeneous second-degree equation in x and y represents a pair of straight lines through the origin.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "equations-and-properties-of-pair-of-straight-lines",
            "Two lines represented together are said to be coincident if they:",
            "Are parallel but distinct", "Are the same line", "Intersect at one point", "Never touch",
            QuestionOption.B,
            "Coincident lines lie exactly on top of one another, representing the same line twice.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-pair-of-straight-lines",
            "The angle between a pair of straight lines can be used to analyze the:",
            "Intersection geometry of structural beams", "Color of an object", "Mass of an object", "Time of travel",
            QuestionOption.A,
            "Finding the angle between intersecting lines helps engineers analyze the geometry of crossing structural elements.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-circle-in-coordinate-geometry",
            "The standard equation of a circle with center (h,k) and radius r is:",
            "(x-h)^2 + (y-k)^2 = r^2", "x^2 + y^2 = r", "(x-h) + (y-k) = r", "x/h + y/k = r^2",
            QuestionOption.A,
            "This is the standard form of a circle's equation, derived from the distance formula.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "equations-and-properties-of-circle",
            "Find the radius of the circle x^2 + y^2 = 16.",
            "2", "4", "8", "16",
            QuestionOption.B,
            "Comparing to x^2 + y^2 = r^2, r^2 = 16 so r = 4.",
            DifficultyLevel.Intermediate,
            1);




        //  rest
        AddQuestion(
            "introduction-to-parabola-in-coordinate-geometry",
            "The graph of a parabola is symmetric about its:",
            "Directrix", "Axis", "Focus only", "Vertex only",
            QuestionOption.B,
            "A parabola is symmetric about its axis, the line passing through the vertex and focus.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "equations-and-properties-of-parabola",
            "For the parabola y^2 = 4ax, the coordinates of the focus are:",
            "(a, 0)", "(0, a)", "(-a, 0)", "(a, a)",
            QuestionOption.A,
            "For y^2 = 4ax, the focus lies at (a, 0) on the axis of symmetry.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-parabola",
            "Parabolic shapes are used in satellite dishes because they:",
            "Reflect all incoming parallel rays to a single focus point", "Absorb all signals equally", "Block signals", "Spread signals randomly",
            QuestionOption.A,
            "A parabola's reflective property focuses parallel incoming rays at a single point, ideal for satellite dishes.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-ellipse-in-coordinate-geometry",
            "An ellipse is defined as the set of points where the sum of distances to two foci is:",
            "Zero", "Constant", "Always increasing", "Equal to the radius",
            QuestionOption.B,
            "Every point on an ellipse has the same total distance to its two foci.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "equations-and-properties-of-ellipse",
            "In the ellipse x^2/25 + y^2/9 = 1, what is the length of the semi-major axis?",
            "3", "5", "9", "25",
            QuestionOption.B,
            "Since 25 > 9, a^2 = 25 so a = 5 is the semi-major axis.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-ellipse",
            "Planetary orbits are best modeled using which conic section?",
            "Circle", "Parabola", "Ellipse", "Hyperbola",
            QuestionOption.C,
            "Kepler's laws show that planets orbit the sun in elliptical paths, with the sun at one focus.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-hyperbola-in-coordinate-geometry",
            "A hyperbola has how many branches?",
            "1", "2", "3", "4",
            QuestionOption.B,
            "A hyperbola consists of two separate, mirror-image curves called branches.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "equations-and-properties-of-hyperbola",
            "For the hyperbola x^2/16 - y^2/9 = 1, the value of a is:",
            "3", "4", "9", "16",
            QuestionOption.B,
            "Comparing to x^2/a^2 - y^2/b^2 = 1, a^2 = 16 so a = 4.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-hyperbola",
            "Hyperbolic paths are used in navigation systems (like LORAN) because they represent points with a constant:",
            "Sum of distances to two points", "Difference of distances to two points", "Angle from the origin", "Ratio of coordinates",
            QuestionOption.B,
            "A hyperbola is the set of points where the difference of distances to two fixed foci is constant, used in triangulating position.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-conic-sections",
            "Conic sections are curves formed by intersecting a plane with a:",
            "Cube", "Double cone", "Sphere", "Cylinder only",
            QuestionOption.B,
            "Circles, ellipses, parabolas, and hyperbolas all arise from slicing a double cone with a plane at different angles.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "equations-and-properties-of-conic-sections",
            "Which conic section results when a plane cuts a cone parallel to its base?",
            "Parabola", "Circle", "Hyperbola", "Ellipse only",
            QuestionOption.B,
            "Slicing a cone parallel to its base produces a circle.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-conic-sections",
            "Architects use conic sections such as parabolic arches because they efficiently distribute:",
            "Structural load", "Electrical current", "Light color", "Sound frequency",
            QuestionOption.A,
            "Parabolic and other conic-shaped arches distribute structural forces efficiently, a property used in architecture.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-differential-equations",
            "A differential equation is an equation that involves:",
            "Only constants", "A function and its derivatives", "Only integrals", "Only matrices",
            QuestionOption.B,
            "A differential equation relates a function to one or more of its derivatives.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "types-and-classification-of-differential-equations",
            "The order of a differential equation is determined by the:",
            "Number of terms", "Highest derivative present", "Number of variables", "Value of constants",
            QuestionOption.B,
            "The order equals the highest-order derivative appearing in the equation.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-differential-equations",
            "Differential equations are used to model population growth because they describe how a quantity changes:",
            "Only at one instant", "Over time in relation to its current value", "Without any variables", "Only linearly",
            QuestionOption.B,
            "Differential equations naturally capture how a changing quantity's rate of change depends on its own current value.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-first-order-differential-equations",
            "A first order differential equation contains derivatives up to what order?",
            "Zero", "First", "Second", "Third",
            QuestionOption.B,
            "First order equations involve only the first derivative of the unknown function.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "methods-for-solving-first-order-differential-equations",
            "Which technique is commonly used to solve a linear first order differential equation?",
            "Integrating factor", "Matrix inversion", "Factorial expansion", "Cross product",
            QuestionOption.A,
            "An integrating factor transforms a linear first order equation into one that can be directly integrated.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-first-order-differential-equations",
            "Newton's law of cooling is modeled by a first order differential equation describing how temperature:",
            "Stays constant", "Changes proportionally to the difference from ambient temperature", "Increases linearly with time", "Is unrelated to time",
            QuestionOption.B,
            "Newton's law of cooling states the rate of temperature change is proportional to the difference between object and surroundings.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-separable-equations",
            "A separable differential equation can be rewritten so that all x terms and all y terms are:",
            "Multiplied together", "On opposite sides of the equation", "Set equal to zero", "Combined into one term",
            QuestionOption.B,
            "In a separable equation, you can rearrange it so x-terms and dx are on one side and y-terms and dy on the other.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "solving-separable-differential-equations",
            "Solve: dy/dx = y (separable). What is the general solution?",
            "y = Ce^x", "y = Cx", "y = x + C", "y = C/x",
            QuestionOption.A,
            "Separating gives dy/y = dx, and integrating both sides gives ln|y| = x + C, so y = Ce^x.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-separable-equations",
            "Radioactive decay is modeled by a separable equation because the decay rate is proportional to the:",
            "Time elapsed only", "Current amount of substance", "Temperature", "Volume of the container",
            QuestionOption.B,
            "Radioactive decay follows dN/dt = -kN, a separable equation where decay rate depends on the current quantity N.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-linear-differential-equations",
            "A first-order linear differential equation has the general form:",
            "dy/dx + P(x)y = Q(x)", "y'' + y = 0", "dy/dx = y^2", "y = mx + c",
            QuestionOption.A,
            "This is the standard form of a first order linear differential equation.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "solving-linear-differential-equations",
            "The integrating factor for dy/dx + P(x)y = Q(x) is:",
            "e^(integral of P(x) dx)", "P(x)", "1/P(x)", "e^x",
            QuestionOption.A,
            "Multiplying through by e^(integral P(x) dx) makes the left side an exact derivative, solving the equation.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-linear-differential-equations",
            "In an RL electrical circuit, the current over time is modeled using a:",
            "Linear first order differential equation", "Quadratic equation", "Matrix equation", "Static algebraic equation",
            QuestionOption.A,
            "Circuit analysis with resistors and inductors leads naturally to a linear first order differential equation for current.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-homogeneous-differential-equations",
            "A homogeneous differential equation can typically be solved using the substitution:",
            "y = vx", "y = x + C", "y = 1/x", "y = e^x",
            QuestionOption.A,
            "Substituting y = vx (where v is a function of x) transforms a homogeneous equation into a separable one.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "methods-for-solving-homogeneous-equations",
            "After substituting y = vx into a homogeneous equation, the resulting equation in v and x becomes:",
            "Nonlinear and unsolvable", "Separable", "A matrix equation", "A quadratic in x only",
            QuestionOption.B,
            "The substitution y = vx reduces a homogeneous equation to a separable equation in v and x.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-homogeneous-equations",
            "Homogeneous differential equations are often used to model systems where the rate of change depends only on the:",
            "Absolute time", "Ratio of the variables involved", "Color of the object", "External constant force only",
            QuestionOption.B,
            "Homogeneous equations describe systems whose behavior depends on the ratio y/x rather than absolute values.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-exact-equations",
            "A differential equation M dx + N dy = 0 is exact if:",
            "dM/dy = dN/dx", "M = N", "M + N = 0", "dM/dx = dN/dy",
            QuestionOption.A,
            "Exactness requires the partial derivative of M with respect to y to equal the partial derivative of N with respect to x.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "solving-exact-differential-equations",
            "To solve an exact equation, you find a function F(x,y) such that:",
            "dF/dx = M and dF/dy = N", "F = M + N", "F = MN", "F = M/N",
            QuestionOption.A,
            "The solution F(x,y) = C satisfies these partial derivative conditions matching M and N.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-exact-equations",
            "Exact differential equations often arise in thermodynamics when working with:",
            "State functions like energy or entropy", "Only kinetic energy", "Random variables", "Discrete data",
            QuestionOption.A,
            "Thermodynamic state functions satisfy exactness conditions, connecting exact equations to physical energy relationships.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-higher-order-differential-equations",
            "A second order differential equation involves derivatives up to the:",
            "First derivative", "Second derivative", "Third derivative", "Fourth derivative",
            QuestionOption.B,
            "A second order equation contains the second derivative as its highest-order term.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "methods-for-solving-higher-order-differential-equations",
            "For a linear homogeneous equation with constant coefficients, solutions are found using the:",
            "Characteristic equation", "Integrating factor only", "Separation of variables only", "Matrix inverse",
            QuestionOption.A,
            "Substituting y = e^(rx) leads to a characteristic (auxiliary) polynomial equation in r, whose roots determine the solution.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-higher-order-differential-equations",
            "A mass-spring system's oscillation is modeled by a:",
            "First order linear equation", "Second order differential equation", "Zeroth order equation", "Algebraic equation only",
            QuestionOption.B,
            "Newton's second law applied to a spring gives a second order differential equation relating acceleration to displacement.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-applications-of-differential-equations",
            "Differential equations model real-world systems by relating a quantity to its:",
            "Fixed constant value", "Rate of change", "Color", "Physical size only",
            QuestionOption.B,
            "Differential equations describe how a quantity's rate of change depends on the quantity itself or other variables.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "mathematical-modeling-with-differential-equations",
            "The logistic growth model differs from exponential growth by including a:",
            "Carrying capacity term", "Negative time variable", "Zero growth rate", "Random noise term",
            QuestionOption.A,
            "The logistic model adds a term that limits growth as the population approaches a carrying capacity.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "advanced-applications-and-practice-of-differential-equations",
            "Systems of differential equations are used in epidemiology to model the spread of disease across:",
            "Susceptible, infected, and recovered groups over time", "A single fixed population size", "Only historical data", "Static snapshots",
            QuestionOption.A,
            "Models like SIR use coupled differential equations to track how populations move between disease states over time.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-counting-principles",
            "The fundamental counting principle states that if there are m ways to do one task and n ways to do another, the total ways to do both is:",
            "m + n", "m * n", "m - n", "m / n",
            QuestionOption.B,
            "The multiplication principle says independent choices combine by multiplying the number of ways for each.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "permutations-and-combinations",
            "How many ways can 3 people be arranged in a line from a group of 3?",
            "3", "6", "9", "27",
            QuestionOption.B,
            "The number of arrangements (permutations) of 3 distinct items is 3! = 6.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-counting-principles",
            "Counting principles are used in cryptography to estimate the:",
            "Number of possible keys or passwords", "Speed of a processor", "Color of an encrypted file", "Physical size of data",
            QuestionOption.A,
            "Counting techniques determine how many possible combinations exist, which relates directly to password/key strength.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-permutations",
            "A permutation is an arrangement where:",
            "Order does not matter", "Order matters", "Only repetition is allowed", "Only one item is chosen",
            QuestionOption.B,
            "Unlike combinations, permutations count arrangements as different when the order of items differs.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "permutation-formulas-and-techniques",
            "The number of permutations of n items taken r at a time is given by:",
            "n! / (n-r)!", "n! / r!", "n! / (r!(n-r)!)", "n * r",
            QuestionOption.A,
            "The permutation formula is nPr = n! / (n-r)!.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-permutations",
            "Permutations are used in scheduling problems to count the number of ways to:",
            "Order a sequence of tasks", "Group items regardless of order", "Select a random sample", "Measure probability directly",
            QuestionOption.A,
            "Since task order matters in a schedule, permutations correctly count the possible sequences.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-combinations",
            "A combination differs from a permutation because in a combination:",
            "Order does not matter", "Order matters", "Repetition is required", "Items cannot repeat ever",
            QuestionOption.A,
            "Combinations count selections of items without regard to the order in which they are chosen.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "combination-formulas-and-techniques",
            "How many ways can you choose 2 items from a set of 4?",
            "4", "6", "8", "12",
            QuestionOption.B,
            "4C2 = 4! / (2!2!) = 6.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-combinations",
            "Combinations are used in lottery probability calculations because the order of numbers drawn:",
            "Matters greatly", "Does not matter", "Is always fixed", "Determines the prize amount directly",
            QuestionOption.B,
            "Lottery number selections are typically unordered, so combinations correctly count the possible outcomes.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-recurrence-relations",
            "A recurrence relation defines each term of a sequence using:",
            "A random number", "Previous term(s) in the sequence", "Only the first term", "An unrelated formula",
            QuestionOption.B,
            "A recurrence relation expresses a term as a function of one or more preceding terms.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "solving-recurrence-relations",
            "The Fibonacci sequence is defined by F(n) = F(n-1) + F(n-2). What type of recurrence is this?",
            "First order", "Second order linear recurrence", "Nonlinear", "Non-recursive",
            QuestionOption.B,
            "Because each term depends on the two previous terms, this is a second order linear recurrence relation.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-recurrence-relations",
            "Recurrence relations are used in computer science to analyze the running time of:",
            "Recursive algorithms", "Only static databases", "Only user interfaces", "Only hardware components",
            QuestionOption.A,
            "The time complexity of recursive algorithms is often expressed and solved as a recurrence relation.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-graph-theory",
            "In graph theory, a vertex connected to another vertex by a line is called an:",
            "Edge", "Node pair", "Angle", "Interval",
            QuestionOption.A,
            "The connecting line between two vertices in a graph is called an edge.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "graph-structures-and-algorithms",
            "Which algorithm is commonly used to find the shortest path in a weighted graph?",
            "Dijkstra's algorithm", "Bubble sort", "Binary search", "Linear regression",
            QuestionOption.A,
            "Dijkstra's algorithm efficiently finds the shortest path between nodes in a weighted graph.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-graph-theory",
            "Social networks are commonly modeled using graphs where users are vertices and friendships are:",
            "Edges", "Weights only", "Colors", "Degrees only",
            QuestionOption.A,
            "Each connection or friendship between two users is represented as an edge connecting their vertices.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-trees",
            "A tree in discrete mathematics is a connected graph with no:",
            "Vertices", "Edges", "Cycles", "Roots",
            QuestionOption.C,
            "A tree is defined as a connected, acyclic graph — it contains no cycles.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "tree-properties-and-algorithms",
            "A tree with n vertices has exactly how many edges?",
            "n", "n - 1", "n + 1", "2n",
            QuestionOption.B,
            "Any tree with n vertices has exactly n - 1 edges, one less than the number of vertices.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-trees",
            "File systems on computers are commonly organized using a:",
            "Tree structure of folders and files", "Flat list only", "Random graph", "Matrix only",
            QuestionOption.A,
            "Directories and their nested subdirectories naturally form a hierarchical tree structure.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-boolean-algebra",
            "In Boolean algebra, variables can only take which values?",
            "0 and 1", "Any real number", "Negative numbers only", "Fractions only",
            QuestionOption.A,
            "Boolean algebra operates on binary values, typically represented as 0 (false) and 1 (true).",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "boolean-laws-and-logic-circuits",
            "Which Boolean law states that A AND (A OR B) equals A?",
            "Absorption law", "Commutative law", "Distributive law", "Identity law",
            QuestionOption.A,
            "The absorption law simplifies A AND (A OR B) directly to A.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-boolean-algebra",
            "Boolean algebra is the mathematical foundation for designing:",
            "Digital logic circuits", "Analog signals only", "Musical scales", "Weather forecasts",
            QuestionOption.A,
            "Logic gates and digital circuits are designed and simplified using the rules of Boolean algebra.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-number-theory",
            "A prime number is a natural number greater than 1 with exactly how many positive divisors?",
            "1", "2", "3", "Infinitely many",
            QuestionOption.B,
            "A prime number has exactly two positive divisors: 1 and itself.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "prime-numbers-and-number-theory-techniques",
            "What is the greatest common divisor (GCD) of 12 and 18?",
            "2", "3", "6", "36",
            QuestionOption.C,
            "The largest number dividing both 12 and 18 evenly is 6.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-number-theory",
            "Number theory concepts like prime factorization are fundamental to modern:",
            "Cryptographic systems such as RSA", "Weather prediction", "Physical construction", "Musical composition",
            QuestionOption.A,
            "RSA and similar cryptosystems rely on the difficulty of factoring large numbers into primes.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-algorithms",
            "An algorithm is best described as a:",
            "Random guess", "Well-defined, step-by-step procedure to solve a problem", "Type of hardware", "Programming language",
            QuestionOption.B,
            "An algorithm is a precise sequence of steps designed to accomplish a specific task or solve a problem.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "algorithm-design-and-analysis",
            "Which notation is used to describe the worst-case time complexity of an algorithm?",
            "Big O notation", "Sigma notation", "Set notation", "Interval notation",
            QuestionOption.A,
            "Big O notation describes how an algorithm's running time grows relative to input size in the worst case.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "advanced-algorithms-and-applications",
            "Dynamic programming improves efficiency by:",
            "Storing and reusing solutions to overlapping subproblems", "Ignoring previous computations", "Using only brute force", "Randomizing all inputs",
            QuestionOption.A,
            "Dynamic programming avoids redundant work by caching solutions to subproblems that recur.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-relations",
            "A relation is a set of:",
            "Single numbers", "Ordered pairs connecting elements of two sets", "Only equations", "Only inequalities",
            QuestionOption.B,
            "A relation consists of ordered pairs that associate elements from one set with elements of another.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "types-and-properties-of-relations",
            "A relation is called reflexive if every element is related to:",
            "Nothing", "Itself", "Every other element", "Only one other element",
            QuestionOption.B,
            "A reflexive relation requires that every element be related to itself.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-relations",
            "Relations are used in database systems to represent connections between:",
            "Tables and their records", "Only numbers", "Only images", "Only colors",
            QuestionOption.A,
            "Relational databases use relations to link records across tables based on shared attributes.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-types-of-functions",
            "A function where every element of the range has exactly one pre-image is called:",
            "Many-one", "One-one (injective)", "Constant", "Undefined",
            QuestionOption.B,
            "A one-one, or injective, function maps distinct inputs to distinct outputs.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "understanding-and-classifying-types-of-functions",
            "A function that is both one-one and onto is called:",
            "Injective only", "Surjective only", "Bijective", "Constant",
            QuestionOption.C,
            "A bijective function is both injective (one-one) and surjective (onto).",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-types-of-functions",
            "Bijective functions are important in cryptography because they guarantee that encryption:",
            "Can always be perfectly reversed (decrypted)", "Loses information", "Maps multiple inputs to one output", "Has no inverse",
            QuestionOption.A,
            "Because a bijection has a unique inverse, it ensures encrypted data can always be uniquely decrypted.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-domain-and-range",
            "The domain of a function refers to the set of all possible:",
            "Outputs", "Inputs", "Slopes", "Intercepts",
            QuestionOption.B,
            "The domain is the complete set of input values for which the function is defined.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "finding-domain-and-range-of-functions",
            "What is the domain of f(x) = 1/(x - 2)?",
            "All real numbers", "All real numbers except x = 2", "x > 2 only", "x < 2 only",
            QuestionOption.B,
            "The function is undefined when the denominator is zero, so x cannot equal 2.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-domain-and-range",
            "In a physical model where x represents time, the domain is often restricted to:",
            "Negative numbers only", "Non-negative real numbers", "Complex numbers", "Integers only",
            QuestionOption.B,
            "Since negative time typically has no physical meaning, the domain is restricted to values of time from zero onward.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-composite-functions",
            "The composite function (f o g)(x) means:",
            "f(x) * g(x)", "f(g(x))", "g(f(x))", "f(x) + g(x)",
            QuestionOption.B,
            "The notation (f o g)(x) means applying g first, then applying f to the result: f(g(x)).",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "evaluating-and-solving-composite-functions",
            "If f(x) = x + 1 and g(x) = 2x, find (f o g)(3).",
            "6", "7", "8", "9",
            QuestionOption.B,
            "g(3) = 6, then f(6) = 6 + 1 = 7.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-composite-functions",
            "Composite functions are used in computer graphics to combine multiple:",
            "Transformations applied one after another", "Colors only", "File formats", "Screen resolutions",
            QuestionOption.A,
            "Sequential transformations, like scaling then rotating, are represented and computed as composite functions.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-inverse-functions",
            "For a function to have an inverse, it must be:",
            "One-one (injective)", "Many-one", "Undefined", "Constant",
            QuestionOption.A,
            "Only a one-one function guarantees a unique inverse mapping, since each output must trace back to one input.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "finding-and-verifying-inverse-functions",
            "Find the inverse of f(x) = 2x + 3.",
            "f^-1(x) = (x - 3)/2", "f^-1(x) = 2x - 3", "f^-1(x) = (x + 3)/2", "f^-1(x) = x/2 - 3",
            QuestionOption.A,
            "Swap x and y then solve for y: x = 2y + 3 gives y = (x-3)/2.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-inverse-functions",
            "Inverse functions are used in cryptography to represent the process of:",
            "Encrypting a message", "Decrypting a message back to its original form", "Compressing data", "Generating random noise",
            QuestionOption.B,
            "Decryption reverses encryption, which mathematically corresponds to applying the inverse function.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-graphing-functions",
            "The graph of a function must pass which test to confirm it is a valid function?",
            "Horizontal line test", "Vertical line test", "Diagonal line test", "Circle test",
            QuestionOption.B,
            "The vertical line test confirms that each x-value maps to only one y-value, as required for a function.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "analyzing-and-sketching-function-graphs",
            "The graph of y = x^2 is a:",
            "Straight line", "Parabola", "Circle", "Hyperbola",
            QuestionOption.B,
            "A quadratic function y = x^2 produces a U-shaped curve called a parabola.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-graphing-functions",
            "Graphing functions helps economists visualize the relationship between:",
            "Price and demand", "Only historical dates", "Random events", "Physical distances only",
            QuestionOption.A,
            "Economic models like supply and demand curves are visualized by graphing the relevant functions.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-piecewise-functions",
            "A piecewise function is defined by:",
            "A single formula for all inputs", "Different formulas over different intervals of the domain", "No formula at all", "Only constants",
            QuestionOption.B,
            "Piecewise functions use different expressions depending on which interval the input falls into.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "evaluating-and-graphing-piecewise-functions",
            "For f(x) = x if x >= 0, and f(x) = -x if x < 0, find f(-3).",
            "-3", "3", "0", "Undefined",
            QuestionOption.B,
            "Since -3 < 0, use f(x) = -x, so f(-3) = -(-3) = 3.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-piecewise-functions",
            "Tax brackets are a real-world example of a:",
            "Linear function", "Piecewise function", "Constant function", "Exponential function only",
            QuestionOption.B,
            "Tax rates change at different income thresholds, making the total tax a piecewise function of income.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-transformations-of-functions",
            "Replacing f(x) with f(x) + k shifts the graph:",
            "Left by k units", "Right by k units", "Up by k units (if k > 0)", "Down by k units (if k > 0)",
            QuestionOption.C,
            "Adding a constant k outside the function shifts the entire graph vertically by k units.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "graphing-and-analyzing-function-transformations",
            "Replacing f(x) with f(-x) reflects the graph across the:",
            "x-axis", "y-axis", "Origin", "Line y = x",
            QuestionOption.B,
            "Negating the input reflects the graph horizontally, across the y-axis.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-function-transformations",
            "In animation software, translating and scaling an object's shape uses the same principles as:",
            "Function transformations", "Random sampling", "Set theory only", "Probability distributions",
            QuestionOption.A,
            "Shifting, scaling, and reflecting objects in animation directly mirrors mathematical function transformations.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-points-lines-and-angles",
            "A line segment differs from a line because a line segment:",
            "Has two endpoints", "Extends infinitely in both directions", "Has no length", "Has no direction",
            QuestionOption.A,
            "Unlike a line, which extends infinitely, a line segment has two definite endpoints.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "types-of-points-lines-and-angles",
            "An angle measuring exactly 90 degrees is called a:",
            "Acute angle", "Right angle", "Obtuse angle", "Straight angle",
            QuestionOption.B,
            "A right angle measures exactly 90 degrees.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-of-points-lines-and-angles",
            "Architects use angle measurements to ensure that walls meet at precisely:",
            "Random angles", "The required design angles, often 90 degrees", "Zero degrees", "180 degrees always",
            QuestionOption.B,
            "Precise angle measurement ensures structural elements like walls meet the exact design specifications.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-triangles",
            "The sum of the interior angles of a triangle is always:",
            "90 degrees", "180 degrees", "270 degrees", "360 degrees",
            QuestionOption.B,
            "In Euclidean geometry, the three interior angles of any triangle always sum to 180 degrees.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "types-of-triangles",
            "A triangle with all three sides of different lengths is called:",
            "Equilateral", "Isosceles", "Scalene", "Right",
            QuestionOption.C,
            "A scalene triangle has three sides of different lengths and three different angles.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-of-triangles",
            "Triangulation, used in surveying and GPS, relies on the geometry of triangles to determine:",
            "Color of a location", "Unknown distances or positions", "Time of day", "Temperature",
            QuestionOption.B,
            "By measuring angles and known distances within triangles, surveyors can calculate unknown distances and positions.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-congruence",
            "Two geometric figures are congruent if they have the same:",
            "Color", "Shape and size", "Position only", "Orientation only",
            QuestionOption.B,
            "Congruent figures are identical in both shape and size, though their position or orientation may differ.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "congruence-criteria",
            "Which criterion proves triangle congruence using two sides and the included angle?",
            "SSS", "SAS", "ASA", "AAA",
            QuestionOption.B,
            "The SAS (Side-Angle-Side) criterion proves congruence using two sides and the angle between them.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-of-congruence",
            "Manufacturers rely on congruence to ensure that mass-produced parts are:",
            "All identical in shape and size", "All different sizes", "Randomly shaped", "Only similar, not identical",
            QuestionOption.A,
            "Congruent parts guarantee that manufactured components are interchangeable, matching exactly in shape and size.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-similarity",
            "Similar figures have the same shape but may differ in:",
            "Angle measures", "Size", "Number of sides", "Type of polygon",
            QuestionOption.B,
            "Similar figures are proportional in size but maintain the same shape and equal corresponding angles.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "similarity-criteria",
            "Which criterion proves triangle similarity using two equal angles?",
            "SSS similarity", "SAS similarity", "AA similarity", "ASA congruence",
            QuestionOption.C,
            "The AA (Angle-Angle) criterion proves triangle similarity because equal angles force proportional sides.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-of-similarity",
            "Map scaling uses the concept of similarity to represent real-world distances:",
            "Exactly life-size", "Proportionally smaller while preserving shape", "Randomly distorted", "Without any consistent ratio",
            QuestionOption.B,
            "A map is a similar (scaled-down) figure of the real terrain, preserving shape through a consistent scale ratio.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-quadrilaterals",
            "A quadrilateral is a polygon with how many sides?",
            "3", "4", "5", "6",
            QuestionOption.B,
            "A quadrilateral is defined as any polygon having exactly four sides.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "types-of-quadrilaterals",
            "A quadrilateral with both pairs of opposite sides parallel is called a:",
            "Trapezium", "Kite", "Parallelogram", "Irregular quadrilateral",
            QuestionOption.C,
            "A parallelogram is defined by having two pairs of parallel opposite sides.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-of-quadrilaterals",
            "Rectangular quadrilateral shapes are commonly used in construction because they:",
            "Are difficult to measure", "Tile and stack efficiently with right angles", "Cannot support weight", "Have no practical use",
            QuestionOption.B,
            "Rectangles with right angles fit together efficiently, making them ideal for floor plans and building layouts.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-polygons",
            "A polygon is a closed figure made up of:",
            "Curved lines only", "Straight line segments", "A single point", "Circles",
            QuestionOption.B,
            "A polygon is a closed, two-dimensional shape formed entirely by straight line segments.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "types-of-polygons",
            "A polygon where all sides and angles are equal is called:",
            "Irregular", "Regular", "Concave", "Convex only",
            QuestionOption.B,
            "A regular polygon has all sides of equal length and all interior angles of equal measure.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-of-polygons",
            "Honeycomb structures use hexagonal polygons because hexagons:",
            "Tile a plane efficiently with minimal material", "Are the only closed shape possible", "Cannot be tiled", "Have no interior angles",
            QuestionOption.A,
            "Hexagons tile perfectly with no gaps while using less perimeter material than other efficient tiling shapes, ideal for honeycombs.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-circles",
            "The distance from the center of a circle to any point on the circle is called the:",
            "Diameter", "Radius", "Circumference", "Chord",
            QuestionOption.B,
            "The radius is the fixed distance from a circle's center to any point on its boundary.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "parts-and-properties-of-circles",
            "A line segment joining two points on a circle is called a:",
            "Radius", "Diameter", "Chord", "Tangent",
            QuestionOption.C,
            "A chord connects any two points on a circle's circumference.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-of-circles",
            "Wheels are designed as circles because a circular shape allows:",
            "Smooth, constant-height rolling motion", "Sharp cornered movement", "No motion at all", "Random bouncing",
            QuestionOption.A,
            "A circle's constant radius keeps its center at a fixed height while rolling, enabling smooth motion.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-geometric-constructions",
            "Classical geometric constructions are traditionally performed using only a:",
            "Ruler and protractor", "Compass and straightedge", "Calculator", "Computer",
            QuestionOption.B,
            "Classical constructions rely solely on an unmarked straightedge and a compass.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "common-geometric-constructions",
            "Which construction divides an angle into two equal parts?",
            "Angle bisector", "Perpendicular bisector", "Parallel line construction", "Circle inscribing",
            QuestionOption.A,
            "An angle bisector is a ray that splits an angle into two congruent halves.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-of-geometric-constructions",
            "Technical drawing and CAD software rely on principles of geometric construction to ensure:",
            "Random shapes", "Precise, reproducible designs", "Approximate sketches only", "Color accuracy",
            QuestionOption.B,
            "Geometric construction techniques ensure that technical drawings are precise and can be exactly reproduced.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-area",
            "Area measures the amount of:",
            "Boundary length around a shape", "Two-dimensional space enclosed by a shape", "Three-dimensional space", "Angle measure",
            QuestionOption.B,
            "Area quantifies the flat, two-dimensional space enclosed within a shape's boundary.",
            DifficultyLevel.Begineer,
            1);

        // rest 1
        AddQuestion(
            "area-of-common-shapes",
            "What is the area of a rectangle with length 8 and width 5?",
            "13", "26", "40", "45",
            QuestionOption.C,
            "Area of a rectangle = length * width = 8 * 5 = 40.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-of-area",
            "Farmers calculate the area of a field to determine the amount of:",
            "Seed or fertilizer needed", "Rainfall expected", "Distance to market", "Number of workers required",
            QuestionOption.A,
            "Knowing the field's area lets farmers accurately calculate how much seed or fertilizer is needed to cover it.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-perimeter",
            "Perimeter measures the:",
            "Enclosed area of a shape", "Total distance around the boundary of a shape", "Volume of a shape", "Number of sides only",
            QuestionOption.B,
            "Perimeter is the total length of the boundary enclosing a two-dimensional shape.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "calculating-the-perimeter-of-shapes",
            "What is the perimeter of a square with side length 6?",
            "12", "18", "24", "36",
            QuestionOption.C,
            "Perimeter of a square = 4 * side = 4 * 6 = 24.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-of-perimeter",
            "Fencing a garden requires calculating its perimeter to determine the:",
            "Amount of fencing material needed", "Amount of soil needed", "Number of plants that fit", "Sunlight exposure",
            QuestionOption.A,
            "The length of fencing material needed corresponds directly to the perimeter of the garden.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-transformations",
            "A transformation that slides a shape without rotating or resizing it is called a:",
            "Reflection", "Rotation", "Translation", "Dilation",
            QuestionOption.C,
            "A translation moves every point of a shape the same distance in the same direction, without turning or resizing it.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "types-of-transformations",
            "Which transformation changes the size of a shape while preserving its proportions?",
            "Translation", "Reflection", "Rotation", "Dilation",
            QuestionOption.D,
            "A dilation enlarges or shrinks a shape by a scale factor while keeping its proportions the same.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-of-transformations",
            "Video game engines use geometric transformations to control an object's:",
            "Position, rotation, and scale on screen", "Sound volume", "Storage size", "Frame rate only",
            QuestionOption.A,
            "Translations, rotations, and scalings (dilations) are the core transformations used to move and resize game objects.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-coordinate-proofs",
            "A coordinate proof uses algebra and coordinates to prove:",
            "Geometric properties or relationships", "Only numerical equations", "Statistical claims", "Probability outcomes",
            QuestionOption.A,
            "Coordinate proofs place figures on the coordinate plane and use algebraic tools to establish geometric facts.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "methods-of-coordinate-proofs",
            "Which tool is commonly used in a coordinate proof to show that two segments are equal in length?",
            "The distance formula", "The quadratic formula", "Sigma notation", "The chain rule",
            QuestionOption.A,
            "The distance formula lets you compute and compare segment lengths directly from coordinates.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-of-coordinate-proofs",
            "Coordinate proofs are useful in robotics for verifying that a robot's planned path maintains required:",
            "Geometric relationships, such as fixed distances or angles", "Battery levels", "Processing speed", "Wireless signal strength",
            QuestionOption.A,
            "By representing paths with coordinates, engineers can algebraically verify required geometric properties like spacing.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-sets",
            "A set is best described as a:",
            "Well-defined collection of distinct objects", "Random group of numbers only", "Single number", "Type of equation",
            QuestionOption.A,
            "A set is a well-defined collection of distinct objects, called elements or members.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "set-operations-and-relationships",
            "If A = {1,2,3} and B = {2,3,4}, what is A intersect B?",
            "{1,2,3,4}", "{2,3}", "{1,4}", "{}",
            QuestionOption.B,
            "The intersection contains only elements common to both sets, which are 2 and 3.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-sets",
            "Set theory underlies database queries such as finding records that belong to two different:",
            "Categories at once, using intersection", "Physical locations", "Colors", "Time zones only",
            QuestionOption.A,
            "Database operations like intersection and union directly mirror set theory operations on data categories.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-set-operations",
            "The union of two sets combines:",
            "Only their common elements", "All elements from both sets, without duplication", "Only elements unique to one set", "Nothing",
            QuestionOption.B,
            "The union operation collects every distinct element that appears in either set.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "advanced-set-operations-and-laws",
            "De Morgan's law states that the complement of (A union B) equals:",
            "A complement union B complement", "A complement intersect B complement", "A intersect B", "A union B",
            QuestionOption.B,
            "De Morgan's law: (A union B)' = A' intersect B'.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-set-operations",
            "In search engines, combining search terms with 'AND' behaves like a set:",
            "Union", "Intersection", "Complement", "Difference",
            QuestionOption.B,
            "Requiring all search terms to match corresponds to finding the intersection of matching document sets.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-venn-diagrams",
            "A Venn diagram visually represents relationships between:",
            "Sets, using overlapping circles", "Numbers on a line", "Angles in a triangle", "Points on a graph",
            QuestionOption.A,
            "Venn diagrams use overlapping circles to show how sets share or differ in their elements.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "solving-problems-using-venn-diagrams",
            "In a Venn diagram, the overlapping region between two circles represents the:",
            "Union of the sets", "Intersection of the sets", "Complement of the sets", "Empty set always",
            QuestionOption.B,
            "The overlapping area shows elements that belong to both sets simultaneously, i.e., their intersection.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-venn-diagrams",
            "Venn diagrams are used in market research to visualize customers who:",
            "Use multiple overlapping products or services", "Never buy anything", "Are randomly selected", "Have no preferences",
            QuestionOption.A,
            "Overlapping circles help visualize customer segments that share interest in more than one product or service.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-cartesian-product",
            "The Cartesian product of sets A and B consists of all possible:",
            "Sums of elements", "Ordered pairs (a, b) with a in A and b in B", "Unordered subsets", "Common elements",
            QuestionOption.B,
            "The Cartesian product A x B pairs every element of A with every element of B.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "properties-and-applications-of-cartesian-products",
            "If A has 3 elements and B has 4 elements, how many elements are in A x B?",
            "7", "12", "3", "4",
            QuestionOption.B,
            "The size of a Cartesian product equals the product of the sizes of the two sets: 3 * 4 = 12.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "advanced-problems-and-practice-of-cartesian-products",
            "Cartesian products form the mathematical basis for constructing:",
            "Relational database tables via joins", "Random graphs only", "Sound waves", "Physical materials",
            QuestionOption.A,
            "Database join operations conceptually build on the Cartesian product of rows from different tables.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-set-relations",
            "A relation from set A to set B is a subset of:",
            "A only", "B only", "The Cartesian product A x B", "The empty set",
            QuestionOption.C,
            "A relation is formally defined as any subset of ordered pairs from the Cartesian product A x B.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "properties-and-types-of-relations",
            "A relation that is reflexive, symmetric, and transitive is called an:",
            "Equivalence relation", "Order relation", "Empty relation", "Injective relation",
            QuestionOption.A,
            "A relation satisfying all three properties (reflexive, symmetric, transitive) is called an equivalence relation.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "relations-in-set-theory-introduction",
            "Equivalence relations are used in computer science to group data into:",
            "Equivalence classes with shared properties", "Random unrelated groups", "A single unordered list", "No groups at all",
            QuestionOption.A,
            "Data sharing a common property under an equivalence relation can be partitioned into equivalence classes.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-functions",
            "A function from set A to set B assigns to each element of A:",
            "No elements of B", "Exactly one element of B", "Two or more elements of B", "All elements of B",
            QuestionOption.B,
            "A function must map each input in the domain to exactly one output in the codomain.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "types-and-properties-of-functions",
            "A function that maps every element of the codomain to at least one element of the domain is called:",
            "Injective", "Surjective (onto)", "Not a function", "Constant",
            QuestionOption.B,
            "A surjective, or onto, function ensures every element of the codomain is covered by the mapping.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-functions",
            "In programming, a function that always produces the same output for the same input models the mathematical property of being:",
            "Well-defined (a true function)", "Undefined", "Random", "Multi-valued",
            QuestionOption.A,
            "A deterministic programming function mirrors the mathematical requirement that each input maps to one output.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-propositional-logic",
            "A proposition is a statement that is:",
            "Either true or false, but not both", "Always a question", "Always undefined", "Always an equation",
            QuestionOption.A,
            "A proposition is a declarative statement that has a definite truth value: true or false.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "logical-operators-and-truth-tables",
            "The logical AND (conjunction) of two true statements is:",
            "True", "False", "Undefined", "Both true and false",
            QuestionOption.A,
            "A conjunction (AND) is true only when both statements it connects are true.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-propositional-logic",
            "Propositional logic forms the basis for designing digital circuits using:",
            "Logic gates such as AND, OR, and NOT", "Random number generators", "Color displays", "Sound cards",
            QuestionOption.A,
            "Digital logic gates directly implement the operations of propositional logic like AND, OR, and NOT.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-predicate-logic",
            "Predicate logic extends propositional logic by introducing:",
            "Variables and quantifiers", "Only numbers", "Only true statements", "Random symbols",
            QuestionOption.A,
            "Predicate logic adds variables, predicates, and quantifiers to express statements about objects in general.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "quantifiers-and-logical-reasoning",
            "The symbol that means 'for all' is called the:",
            "Existential quantifier", "Universal quantifier", "Negation symbol", "Implication symbol",
            QuestionOption.B,
            "The universal quantifier (symbol: for all) asserts a statement holds for every element in a domain.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-predicate-logic",
            "Predicate logic is used in databases to formally express queries such as:",
            "Find all records where a condition holds for every row", "Draw a picture", "Play a sound", "Change screen color",
            QuestionOption.A,
            "Quantified logical statements let databases express conditions that must hold across all or some records.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-truth-tables",
            "A truth table lists all possible combinations of truth values for a statement's:",
            "Variables", "Colors", "Numbers only", "Physical properties",
            QuestionOption.A,
            "A truth table systematically shows every possible combination of true/false values for the involved variables.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "constructing-and-simplifying-truth-tables",
            "A statement that is always true, regardless of its variables' truth values, is called a:",
            "Contradiction", "Tautology", "Contingency", "Negation",
            QuestionOption.B,
            "A tautology is a statement that is true under every possible assignment of truth values.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-truth-tables",
            "Truth tables are used to verify the correctness of a proposed:",
            "Digital circuit's logic", "Building's height", "Painting's color scheme", "Musical rhythm",
            QuestionOption.A,
            "Engineers use truth tables to confirm that a digital circuit's output matches the intended logical behavior.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-logical-equivalence",
            "Two statements are logically equivalent if they always have the:",
            "Same truth value", "Same number of variables", "Same length", "Different truth value",
            QuestionOption.A,
            "Logically equivalent statements produce identical truth values under every possible interpretation.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "laws-and-methods-of-logical-equivalence",
            "Which law states that NOT(NOT A) is equivalent to A?",
            "Double negation law", "Commutative law", "Identity law", "Associative law",
            QuestionOption.A,
            "The double negation law states that negating a negation returns the original statement.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-logical-equivalence",
            "Simplifying logical expressions using equivalence laws helps engineers reduce the number of:",
            "Logic gates needed in a circuit", "Colors in a display", "Wires in a power line", "Users of a system",
            QuestionOption.A,
            "Simplified equivalent expressions often require fewer logic gates, reducing circuit cost and complexity.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-mathematical-proofs",
            "The purpose of a mathematical proof is to:",
            "Guess an answer", "Establish that a statement is true using logical reasoning", "Draw a diagram only", "Collect data",
            QuestionOption.B,
            "A proof provides a rigorous logical argument establishing the truth of a mathematical statement.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "common-proof-methods-and-strategies",
            "A proof by contradiction begins by assuming:",
            "The statement is true", "The opposite of what you want to prove", "Nothing at all", "A random unrelated fact",
            QuestionOption.B,
            "Proof by contradiction assumes the negation of the target statement, then derives a logical contradiction.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "advanced-proof-applications-and-practice",
            "Mathematical induction is especially useful for proving statements about:",
            "All real numbers", "All natural numbers", "Only negative numbers", "Only irrational numbers",
            QuestionOption.B,
            "Induction proves a base case and an inductive step, making it ideal for statements indexed by natural numbers.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-matrix-basics",
            "A matrix is a rectangular array of numbers arranged in:",
            "Rows and columns", "A single row only", "A single column only", "Random order",
            QuestionOption.A,
            "A matrix organizes numbers into rows and columns to form a rectangular array.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "elements-and-representation-of-matrices",
            "A matrix with dimensions 3x2 has how many elements?",
            "5", "6", "9", "2",
            QuestionOption.B,
            "The number of elements equals rows times columns: 3 * 2 = 6.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-matrix-basics",
            "Matrices are used in computer graphics to represent and apply:",
            "Geometric transformations to 3D objects", "Only text data", "Sound frequencies", "File compression",
            QuestionOption.A,
            "Transformations like rotation, scaling, and translation of 3D objects are represented using matrices.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-types-of-matrices",
            "A matrix with the same number of rows and columns is called a:",
            "Rectangular matrix", "Square matrix", "Row matrix", "Zero matrix",
            QuestionOption.B,
            "A square matrix has an equal number of rows and columns.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "properties-and-classification-of-matrices",
            "A matrix where all elements outside the main diagonal are zero is called:",
            "A diagonal matrix", "An identity matrix only", "A zero matrix", "A row matrix",
            QuestionOption.A,
            "A diagonal matrix has nonzero entries only along its main diagonal.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-types-of-matrices",
            "Identity matrices are used in linear algebra similarly to how the number 1 is used in:",
            "Multiplication of ordinary numbers", "Addition of ordinary numbers", "Subtraction only", "Division by zero",
            QuestionOption.A,
            "Multiplying any matrix by the identity matrix leaves it unchanged, just as multiplying by 1 does for numbers.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-matrix-operations",
            "Two matrices can be added only if they have the:",
            "Same number of rows only", "Same number of columns only", "Same dimensions", "Same determinant",
            QuestionOption.C,
            "Matrix addition requires both matrices to have identical dimensions (same rows and columns).",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "performing-matrix-operations",
            "For matrix multiplication AB to be defined, the number of columns of A must equal the:",
            "Number of rows of B", "Number of columns of B", "Number of rows of A", "Determinant of B",
            QuestionOption.A,
            "Matrix multiplication requires the inner dimensions to match: columns of A equal rows of B.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-matrix-operations",
            "In machine learning, matrix multiplication is used to efficiently compute:",
            "Weighted sums across neural network layers", "Random noise", "File names", "Screen colors only",
            QuestionOption.A,
            "Neural networks rely heavily on matrix multiplication to compute weighted combinations of inputs across layers.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-determinants",
            "A determinant can only be calculated for a:",
            "Row matrix", "Square matrix", "Rectangular matrix", "Zero matrix only",
            QuestionOption.B,
            "Determinants are defined only for square matrices.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "properties-and-evaluation-of-determinants",
            "What is the determinant of the matrix [[2,0],[0,3]]?",
            "5", "6", "0", "1",
            QuestionOption.B,
            "For a 2x2 diagonal matrix, the determinant is the product of the diagonal entries: 2 * 3 = 6.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-determinants",
            "A determinant equal to zero indicates that a matrix is:",
            "Invertible", "Singular (non-invertible)", "Symmetric", "Diagonal",
            QuestionOption.B,
            "A zero determinant means the matrix has no inverse and is called singular.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-inverse-matrix",
            "The inverse of a matrix A, when multiplied by A, gives the:",
            "Zero matrix", "Identity matrix", "Transpose of A", "Determinant of A",
            QuestionOption.B,
            "By definition, A multiplied by its inverse A^-1 produces the identity matrix.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "finding-and-verifying-inverse-matrices",
            "A square matrix has an inverse if and only if its determinant is:",
            "Zero", "Negative", "Not equal to zero", "Equal to 1",
            QuestionOption.C,
            "A matrix is invertible precisely when its determinant is nonzero.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-inverse-matrices",
            "Inverse matrices are used to solve systems of linear equations written as AX = B, by computing:",
            "X = A^-1 * B", "X = A * B", "X = B - A", "X = A + B",
            QuestionOption.A,
            "Multiplying both sides by the inverse of A isolates X, giving X = A^-1 * B.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-rank-of-matrix",
            "The rank of a matrix represents the number of:",
            "Rows only", "Columns only", "Linearly independent rows or columns", "Zero entries",
            QuestionOption.C,
            "Rank measures the maximum number of linearly independent rows (or equivalently, columns) in the matrix.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "finding-the-rank-of-a-matrix",
            "The rank of a matrix can be found by reducing it to:",
            "Row echelon form", "A single number", "A determinant", "A vector",
            QuestionOption.A,
            "Counting the nonzero rows after reducing a matrix to row echelon form gives its rank.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-matrix-rank",
            "In data science, the rank of a data matrix can indicate the number of:",
            "Independent features or dimensions in the data", "Rows only", "Missing values", "Colors used",
            QuestionOption.A,
            "A lower-than-expected rank can reveal redundancy, showing fewer truly independent dimensions than variables.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-systems-of-linear-equations",
            "A system of linear equations can be represented compactly using:",
            "Matrix notation, AX = B", "A single number", "A probability distribution", "A graph coloring",
            QuestionOption.A,
            "Systems of linear equations are conveniently expressed and solved using matrix notation.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "solving-systems-of-linear-equations",
            "Cramer's Rule solves a system of linear equations using:",
            "Ratios of determinants", "Random substitution", "Graphing only", "Trial and error",
            QuestionOption.A,
            "Cramer's Rule expresses each variable's solution as a ratio of determinants of modified coefficient matrices.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-systems-of-linear-equations",
            "Systems of linear equations are used in economics to model relationships between multiple:",
            "Interdependent quantities, such as supply and demand across markets", "Random unrelated events", "Colors", "Physical distances only",
            QuestionOption.A,
            "Economic models with several interacting variables are naturally expressed as systems of linear equations.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-eigenvalues",
            "An eigenvalue of a matrix A is a scalar lambda such that for some nonzero vector v:",
            "Av = lambda*v", "A + v = lambda", "Av = 0", "A = lambda*I only",
            QuestionOption.A,
            "The defining equation for an eigenvalue and its corresponding eigenvector is Av = lambda*v.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "finding-eigenvalues-and-eigenvectors",
            "Eigenvalues of a matrix are found by solving:",
            "det(A - lambda*I) = 0", "det(A) = 0", "A * I = 0", "trace(A) = lambda",
            QuestionOption.A,
            "Setting the determinant of (A - lambda*I) to zero gives the characteristic equation whose roots are the eigenvalues.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-eigenvalues",
            "In Google's PageRank algorithm, the ranking of web pages is derived from the:",
            "Dominant eigenvector of a link matrix", "Physical size of the server", "Number of colors used", "Random ordering",
            QuestionOption.A,
            "PageRank computes page importance as the dominant eigenvector of a matrix representing web link structure.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-eigenvectors",
            "An eigenvector of a matrix is a nonzero vector whose direction is:",
            "Unchanged (only scaled) when the matrix is applied to it", "Always reversed", "Randomized", "Always rotated 90 degrees",
            QuestionOption.A,
            "When a matrix is applied to its eigenvector, the result is a scalar multiple of the original vector, preserving direction.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "finding-and-analyzing-eigenvectors",
            "To find the eigenvector corresponding to an eigenvalue lambda, you solve the equation:",
            "(A - lambda*I)v = 0", "Av = I", "A * lambda = v", "v = A + lambda",
            QuestionOption.A,
            "Substituting the eigenvalue back into (A - lambda*I)v = 0 and solving for v gives the eigenvector.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-eigenvectors",
            "In facial recognition (eigenfaces), eigenvectors help identify the most significant:",
            "Directions of variation among face images", "Colors in an image", "File sizes", "Camera settings",
            QuestionOption.A,
            "Principal component analysis uses eigenvectors to capture the directions of greatest variation across face data.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-basic-probability",
            "The probability of an event is calculated as:",
            "Favorable outcomes minus total outcomes", "Favorable outcomes divided by total outcomes", "Total outcomes divided by favorable outcomes", "Favorable outcomes times total outcomes",
            QuestionOption.B,
            "Probability equals the number of favorable outcomes divided by the total number of possible outcomes.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "calculating-basic-probability",
            "What is the probability of rolling a 4 on a fair six-sided die?",
            "1/6", "1/4", "1/2", "4/6",
            QuestionOption.A,
            "There is exactly one favorable outcome (rolling a 4) out of six equally likely outcomes, giving 1/6.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-basic-probability",
            "Insurance companies use probability to calculate the likelihood of a claim in order to set:",
            "Appropriate premiums", "Random prices", "Office locations", "Employee schedules",
            QuestionOption.A,
            "Estimating the probability of claims allows insurers to price premiums that reflect the underlying risk.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-conditional-probability",
            "Conditional probability measures the probability of an event given that:",
            "No other information is known", "Another event has already occurred", "All events are impossible", "The sample space is empty",
            QuestionOption.B,
            "Conditional probability updates the likelihood of an event based on the knowledge that another event has occurred.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "calculating-conditional-probability",
            "The formula for conditional probability P(A|B) is:",
            "P(A and B) / P(B)", "P(A) * P(B)", "P(A) + P(B)", "P(B) / P(A)",
            QuestionOption.A,
            "P(A|B) is defined as the probability of both A and B occurring, divided by the probability of B.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-conditional-probability",
            "Medical diagnostic tests use conditional probability to determine the likelihood of a disease given a:",
            "Positive test result", "Random guess", "Patient's age only", "Doctor's opinion only",
            QuestionOption.A,
            "Conditional probability quantifies how likely a disease is, given the evidence of a specific test result.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-bayes-theorem",
            "Bayes' Theorem allows you to update a probability based on:",
            "New evidence", "Random chance only", "A fixed constant", "Ignoring prior information",
            QuestionOption.A,
            "Bayes' Theorem revises an initial (prior) probability estimate when new evidence becomes available.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "applying-bayes-theorem",
            "In Bayes' Theorem, P(A) before considering new evidence is called the:",
            "Posterior probability", "Prior probability", "Likelihood", "Conditional probability",
            QuestionOption.B,
            "The prior probability represents the initial belief in an event before incorporating new evidence.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-bayes-theorem",
            "Spam filters commonly use Bayes' Theorem to estimate the probability that an email is spam based on its:",
            "File size only", "Words and content", "Sender's time zone", "Font style",
            QuestionOption.B,
            "Bayesian spam filters use word frequency patterns as evidence to update the probability an email is spam.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-random-variables",
            "A random variable assigns a numerical value to each outcome of a:",
            "Deterministic process", "Random experiment", "Fixed equation", "Geometric shape",
            QuestionOption.B,
            "A random variable maps the outcomes of a random experiment to numerical values.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "types-and-probability-distributions-of-random-variables",
            "A random variable that can take any value within a continuous range is called:",
            "Discrete", "Continuous", "Constant", "Undefined",
            QuestionOption.B,
            "Continuous random variables can take any value within an interval, unlike discrete variables which take countable values.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-random-variables",
            "In finance, stock returns are often modeled as random variables to assess:",
            "Investment risk and expected return", "Company logos", "Office locations", "Employee headcount",
            QuestionOption.A,
            "Treating returns as random variables allows analysts to quantify risk and expected performance of an investment.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-probability-distributions",
            "A probability distribution describes how probabilities are:",
            "Assigned to all possible values of a random variable", "Removed from a sample space", "Fixed at zero", "Ignored entirely",
            QuestionOption.A,
            "A probability distribution shows how likely each possible outcome of a random variable is.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "types-and-properties-of-probability-distributions",
            "The total area under a continuous probability density function must equal:",
            "0", "1", "100", "Infinity",
            QuestionOption.B,
            "Since the total probability of all outcomes must be 1, the area under a valid PDF sums to exactly 1.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-probability-distributions",
            "Quality control engineers use probability distributions to model the likelihood of a product:",
            "Being defective", "Being a certain color", "Costing a certain amount", "Being manufactured on time only",
            QuestionOption.A,
            "Probability distributions help estimate defect rates and manage quality control processes.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-expected-value",
            "The expected value of a random variable represents its:",
            "Maximum possible value", "Long-run average value", "Minimum possible value", "Most frequent single outcome",
            QuestionOption.B,
            "Expected value is the long-run average outcome you would observe if an experiment were repeated many times.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "calculating-expected-value",
            "A game pays $10 with probability 0.5 and $0 with probability 0.5. What is the expected value?",
            "$0", "$5", "$10", "$20",
            QuestionOption.B,
            "Expected value = (10 * 0.5) + (0 * 0.5) = 5.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-expected-value",
            "Casinos design games so that the expected value for the player is typically:",
            "Positive", "Negative (in the casino's favor)", "Exactly zero always", "Undefined",
            QuestionOption.B,
            "Games are designed with a built-in house edge, making the expected value negative for the player over time.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-binomial-distribution",
            "The binomial distribution models the number of successes in a fixed number of:",
            "Continuous measurements", "Independent trials with two possible outcomes", "Random unrelated events", "Non-repeatable experiments",
            QuestionOption.B,
            "The binomial distribution applies to a fixed number of independent Bernoulli trials, each with success/failure outcomes.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "calculating-binomial-probabilities",
            "In a binomial distribution, what does the parameter p represent?",
            "The number of trials", "The probability of success on each trial", "The expected value", "The variance",
            QuestionOption.B,
            "The parameter p is the fixed probability of success on any single trial.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-binomial-distribution",
            "Quality inspectors use the binomial distribution to estimate the probability of finding a certain number of defective items in a:",
            "Fixed-size sample", "Single infinite population", "Random unrelated dataset", "Continuous measurement",
            QuestionOption.A,
            "Sampling a fixed number of items where each is defective or not fits the binomial distribution model.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-normal-distribution",
            "The normal distribution is characterized by its distinctive:",
            "Bell-shaped, symmetric curve", "Sharp rectangular shape", "Random scattered pattern", "Straight line",
            QuestionOption.A,
            "The normal distribution's probability density forms a symmetric, bell-shaped curve centered at the mean.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "properties-and-calculations-of-normal-distribution",
            "A z-score measures how many standard deviations a value is from the:",
            "Median", "Mean", "Mode", "Range",
            QuestionOption.B,
            "The z-score standardizes a value by expressing its distance from the mean in units of standard deviation.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-normal-distribution",
            "Standardized test scores are often modeled using the normal distribution to compare a student's performance to the:",
            "Overall population's performance", "Number of questions only", "Test duration", "Exam location",
            QuestionOption.A,
            "Because many test score distributions approximate normal curves, they allow comparison of an individual's score to the group.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-arithmetic-progression",
            "In an arithmetic progression, each term is obtained from the previous one by:",
            "Multiplying by a constant ratio", "Adding a constant common difference", "Squaring the previous term", "Taking the reciprocal",
            QuestionOption.B,
            "An arithmetic progression increases or decreases by the same fixed amount, the common difference, each step.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "finding-terms-and-sum-of-arithmetic-progression",
            "Find the 5th term of the AP: 2, 5, 8, 11, ...",
            "11", "14", "17", "20",
            QuestionOption.B,
            "The common difference is 3, so the 5th term is 2 + 4*3 = 14.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-arithmetic-progression",
            "A stadium's seating rows increase by 2 seats each row. This scenario is best modeled by an:",
            "Arithmetic progression", "Geometric progression", "Harmonic progression", "Random sequence",
            QuestionOption.A,
            "A constant increase of 2 seats per row matches the definition of an arithmetic progression.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-geometric-progression",
            "In a geometric progression, each term is obtained from the previous one by:",
            "Adding a constant", "Multiplying by a constant ratio", "Subtracting a constant", "Taking a square root",
            QuestionOption.B,
            "A geometric progression multiplies each term by the same fixed common ratio to get the next term.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "finding-terms-and-sum-of-geometric-progression",
            "Find the 4th term of the GP: 3, 6, 12, ...",
            "18", "20", "24", "36",
            QuestionOption.C,
            "The common ratio is 2, so the 4th term is 3 * 2^3 = 24.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-geometric-progression",
            "Compound interest calculations are based on the mathematics of:",
            "Arithmetic progression", "Geometric progression", "Harmonic progression", "Linear equations only",
            QuestionOption.B,
            "Since each year's balance is multiplied by a fixed growth factor, compound interest follows a geometric progression.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-harmonic-progression",
            "A sequence is a harmonic progression if the reciprocals of its terms form a(n):",
            "Geometric progression", "Arithmetic progression", "Random sequence", "Constant sequence",
            QuestionOption.B,
            "A harmonic progression is defined as a sequence whose reciprocals form an arithmetic progression.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "solving-problems-using-harmonic-progression",
            "If the reciprocals 1, 1/3, 1/5 form an AP, the original sequence 1, 3, 5 is a(n):",
            "Arithmetic progression", "Harmonic progression", "Geometric progression", "None of these",
            QuestionOption.B,
            "Since the reciprocals form an AP, the original sequence 1, 3, 5 is by definition a harmonic progression.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-harmonic-progression",
            "In physics, the harmonic mean is used to average quantities like speed when the distances travelled are:",
            "Equal", "Random", "Always zero", "Undefined",
            QuestionOption.A,
            "When equal distances are covered at different speeds, the harmonic mean correctly gives the average speed.",
            DifficultyLevel.Advance,
            1);

        // rest 2
        AddQuestion(
            "introduction-to-sigma-notation",
            "The sigma symbol in mathematics represents:",
            "A product", "A summation", "A derivative", "An integral",
            QuestionOption.B,
            "The Greek letter sigma is the standard notation for representing a sum of terms.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "evaluating-expressions-using-sigma-notation",
            "Evaluate: sum from i=1 to 4 of i",
            "6", "8", "10", "12",
            QuestionOption.C,
            "Sum = 1 + 2 + 3 + 4 = 10.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-sigma-notation",
            "Sigma notation is used in statistics to compactly express formulas such as the:",
            "Sum used to calculate the mean of a dataset", "Color of a graph", "Shape of a histogram bar", "Sample size only",
            QuestionOption.A,
            "Formulas for statistical measures like the mean rely on sigma notation to represent a sum over all data points.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-finite-series",
            "A finite series is the sum of:",
            "Infinitely many terms", "A fixed, limited number of terms", "Zero terms", "Only two terms",
            QuestionOption.B,
            "A finite series adds together a specific, countable number of terms from a sequence.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "evaluating-and-solving-finite-series",
            "Find the sum of the first 5 terms of the arithmetic sequence 1, 3, 5, 7, 9.",
            "15", "20", "25", "30",
            QuestionOption.C,
            "Sum = 1+3+5+7+9 = 25.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-finite-series",
            "Loan repayment schedules use finite series to calculate the total amount paid over a:",
            "Fixed number of payment periods", "Random number of years", "Single instant", "Infinite time span",
            QuestionOption.A,
            "Summing a fixed number of periodic payments is a direct application of finite series.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-infinite-series",
            "An infinite series is said to converge if its partial sums approach a:",
            "Random value", "Finite limit", "Value of infinity", "Value of zero always",
            QuestionOption.B,
            "A convergent infinite series has partial sums that approach a specific finite number as more terms are added.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "convergence-and-evaluation-of-infinite-series",
            "For which values of r does the infinite geometric series with ratio r converge?",
            "|r| > 1", "|r| < 1", "r = 1", "r = -1",
            QuestionOption.B,
            "An infinite geometric series converges only when the absolute value of the common ratio is less than 1.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-infinite-series",
            "Infinite series are used in physics to approximate functions like sine and cosine using:",
            "Taylor series expansions", "Only integer arithmetic", "Random sampling", "Matrix inversion",
            QuestionOption.A,
            "Taylor series represent functions as infinite sums, enabling accurate polynomial approximations in physics.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-binomial-expansion",
            "The Binomial Theorem provides a formula for expanding expressions of the form:",
            "(a + b)^n", "a^n + b^n", "a * b^n", "log(a + b)",
            QuestionOption.A,
            "The Binomial Theorem gives a systematic formula for expanding powers of a binomial, (a + b)^n.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "applying-the-binomial-theorem",
            "In the expansion of (a+b)^n, the coefficients follow the pattern found in:",
            "Pascal's Triangle", "The Fibonacci sequence", "A geometric progression", "A logarithmic scale",
            QuestionOption.A,
            "The binomial coefficients in the expansion match the entries of Pascal's Triangle.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-binomial-expansion",
            "The binomial theorem is used in probability to derive the formula for the:",
            "Binomial probability distribution", "Normal distribution only", "Mean of any dataset", "Standard deviation formula only",
            QuestionOption.A,
            "The binomial probability formula for successes in independent trials directly comes from the binomial expansion.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-mathematical-induction",
            "Mathematical induction proves a statement is true for all natural numbers using a base case and a(n):",
            "Random case", "Inductive step", "Contradiction only", "Graph",
            QuestionOption.B,
            "Induction requires proving a base case and an inductive step that shows truth for n implies truth for n+1.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "proving-statements-using-mathematical-induction",
            "In an inductive proof, the inductive step assumes the statement is true for n = k and then proves it true for:",
            "n = k - 1", "n = k + 1", "n = 1 only", "All n simultaneously",
            QuestionOption.B,
            "The inductive step shows that if the statement holds for k, it must also hold for the next value, k + 1.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-mathematical-induction",
            "Mathematical induction is often used in computer science to prove the correctness of:",
            "Recursive algorithms", "Random data", "Hardware color schemes", "Screen resolution settings",
            QuestionOption.A,
            "Because recursive algorithms build on smaller cases, induction is a natural tool for proving their correctness.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-data-collection",
            "Data collection refers to the process of:",
            "Gathering information for analysis", "Deleting unnecessary records", "Guessing outcomes", "Ignoring inconsistent values",
            QuestionOption.A,
            "Data collection is the systematic gathering of information to be used in statistical analysis.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "methods-and-techniques-of-data-collection",
            "Data collected directly from an original source is called:",
            "Secondary data", "Primary data", "Random data", "Historical data only",
            QuestionOption.B,
            "Primary data is collected firsthand by the researcher directly from its original source.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-data-collection",
            "Businesses collect customer feedback data to improve their:",
            "Products and services", "Office decor only", "Building location", "Stock certificates",
            QuestionOption.A,
            "Analyzing collected customer feedback helps businesses identify areas to improve their offerings.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-measures-of-central-tendency",
            "Which of the following is NOT a measure of central tendency?",
            "Mean", "Median", "Mode", "Range",
            QuestionOption.D,
            "Range measures spread (dispersion), not the center of a dataset, unlike mean, median, and mode.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "calculating-mean-median-and-mode",
            "Find the mean of the dataset: 2, 4, 6, 8, 10.",
            "5", "6", "7", "8",
            QuestionOption.B,
            "Mean = (2+4+6+8+10)/5 = 30/5 = 6.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-central-tendency",
            "Governments use average income (mean) figures to help design:",
            "Tax and welfare policies", "Building blueprints", "Weather forecasts", "Traffic light patterns",
            QuestionOption.A,
            "Central tendency measures like mean income inform policy decisions related to taxation and social welfare.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-measures-of-dispersion",
            "Dispersion measures describe how:",
            "Centered data is", "Spread out data values are", "Many data points exist", "Data is labeled",
            QuestionOption.B,
            "Measures of dispersion, like range and standard deviation, quantify how spread out data values are.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "calculating-variance-and-standard-deviation",
            "Standard deviation is calculated as the:",
            "Square root of the variance", "Square of the variance", "Sum of all deviations", "Mean of the dataset",
            QuestionOption.A,
            "Standard deviation is defined as the square root of the variance, returning the spread to original units.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-measures-of-dispersion",
            "Investors use standard deviation of returns as a measure of an investment's:",
            "Risk or volatility", "Guaranteed profit", "Tax rate", "Company name",
            QuestionOption.A,
            "A higher standard deviation of returns indicates greater volatility, which investors interpret as higher risk.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-frequency-distribution",
            "A frequency distribution organizes data by showing how often each:",
            "Value or range of values occurs", "Person is surveyed", "Variable is undefined", "Chart is drawn",
            QuestionOption.A,
            "A frequency distribution summarizes data by counting how often each value or interval occurs.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "creating-and-analyzing-frequency-distributions",
            "In a frequency distribution table, the class interval refers to the:",
            "Range of values grouped together", "Total number of observations", "Mean of the data", "Mode of the data",
            QuestionOption.A,
            "A class interval defines a range of values that are grouped together in the frequency table.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-frequency-distribution",
            "Businesses use frequency distributions of sales data to identify:",
            "Which products sell most often", "Employee birthdays", "Office square footage", "Currency exchange rates",
            QuestionOption.A,
            "Analyzing how often products are sold reveals patterns in customer purchasing behavior.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-histograms",
            "A histogram displays data using:",
            "Adjacent bars representing frequency over intervals", "Circles of varying size", "A single line", "Colored dots only",
            QuestionOption.A,
            "Histograms use bars with no gaps to show the frequency of data within continuous intervals.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "creating-and-interpreting-histograms",
            "A histogram that is symmetric and bell-shaped suggests the data may follow a:",
            "Uniform distribution", "Normal distribution", "Skewed distribution", "Bimodal distribution",
            QuestionOption.B,
            "A symmetric bell-shaped histogram is a visual indicator that data may be approximately normally distributed.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-histograms",
            "Quality control teams use histograms to visualize the distribution of a:",
            "Measured product dimension", "Company logo", "Employee names", "Marketing slogan",
            QuestionOption.A,
            "Histograms help quality teams see how a measured product characteristic varies around its target value.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-box-plots",
            "A box plot visually displays the five-number summary, which includes the median and the:",
            "Minimum, maximum, and quartiles", "Mean and standard deviation only", "Mode only", "Range and variance only",
            QuestionOption.A,
            "A box plot's five-number summary consists of the minimum, first quartile, median, third quartile, and maximum.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "creating-and-interpreting-box-plots",
            "In a box plot, points plotted separately beyond the whiskers represent:",
            "The median", "Outliers", "The mean", "The mode",
            QuestionOption.B,
            "Points shown outside the whiskers of a box plot are considered outliers, unusually far from the rest of the data.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-box-plots",
            "Box plots are useful for comparing the distribution of test scores across:",
            "Multiple different classes side by side", "A single data point", "Only one student", "Random colors",
            QuestionOption.A,
            "Placing multiple box plots side by side allows quick visual comparison of distributions across groups.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-correlation",
            "Correlation measures the strength and direction of a relationship between:",
            "Two variables", "A single variable", "Three or more unrelated items", "Categorical labels only",
            QuestionOption.A,
            "Correlation quantifies how strongly and in what direction two variables tend to move together.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "calculating-and-interpreting-correlation",
            "A correlation coefficient close to +1 indicates:",
            "A strong negative relationship", "No relationship", "A strong positive relationship", "An undefined relationship",
            QuestionOption.C,
            "Values near +1 indicate that as one variable increases, the other tends to increase strongly and consistently.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-correlation",
            "Marketers analyze correlation between advertising spend and sales to evaluate:",
            "Advertising effectiveness", "Employee satisfaction", "Office temperature", "Building size",
            QuestionOption.A,
            "A strong positive correlation between ad spend and sales can suggest that advertising is effective.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-regression",
            "Regression analysis is used to model the relationship between a dependent variable and one or more:",
            "Independent variables", "Random constants", "Colors", "Unrelated categories",
            QuestionOption.A,
            "Regression estimates how a dependent variable changes in response to one or more independent variables.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "linear-regression-and-prediction-models",
            "In simple linear regression, the line of best fit minimizes the sum of the:",
            "Squared residuals", "X values", "Y values only", "Correlation coefficients",
            QuestionOption.A,
            "The least-squares method finds the line that minimizes the sum of squared differences between observed and predicted values.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-regression",
            "Businesses use regression models to forecast future:",
            "Sales based on historical trends", "Employee names", "Office locations", "Logo designs",
            QuestionOption.A,
            "Regression models let businesses predict future outcomes, like sales, based on patterns in historical data.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-sampling",
            "Sampling involves studying a subset of a population in order to:",
            "Draw conclusions about the whole population", "Ignore the population entirely", "Replace the population permanently", "Eliminate all variability",
            QuestionOption.A,
            "A well-chosen sample allows researchers to make inferences about a larger population without studying everyone.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "sampling-methods-and-techniques",
            "In simple random sampling, every member of the population has:",
            "No chance of selection", "An equal chance of being selected", "A guaranteed selection", "A chance based on wealth",
            QuestionOption.B,
            "Simple random sampling gives every individual in the population an equal probability of being chosen.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-sampling",
            "Political polls use sampling to estimate public opinion because surveying the:",
            "Entire population is often impractical", "Sample is illegal", "Population is always small", "Results are guaranteed exact",
            QuestionOption.A,
            "Since surveying an entire population is usually costly or impossible, pollsters rely on representative samples.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-hypothesis-testing",
            "The null hypothesis in hypothesis testing typically represents:",
            "The claim being tested, assumed true until evidence suggests otherwise", "A random guess with no meaning", "Always the researcher's desired outcome", "An impossible outcome",
            QuestionOption.A,
            "The null hypothesis is the default assumption that is tested against the collected evidence.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "statistical-tests-and-significance-levels",
            "A small p-value (below the significance level) typically leads to:",
            "Accepting the null hypothesis outright", "Rejecting the null hypothesis", "Ignoring the data", "Increasing the sample size automatically",
            QuestionOption.B,
            "A p-value below the chosen significance level provides evidence against the null hypothesis, leading to its rejection.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-hypothesis-testing",
            "Pharmaceutical companies use hypothesis testing in clinical trials to determine whether a new drug:",
            "Has a statistically significant effect compared to a placebo", "Is a certain color", "Costs a certain amount", "Was made in a certain country",
            QuestionOption.A,
            "Hypothesis testing helps determine whether observed differences in trial outcomes are statistically meaningful rather than due to chance.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-trigonometric-ratios",
            "In a right triangle, sine of an angle is defined as the ratio of the:",
            "Opposite side to the hypotenuse", "Adjacent side to the hypotenuse", "Opposite side to the adjacent side", "Hypotenuse to the opposite side",
            QuestionOption.A,
            "Sine of an angle equals the length of the side opposite the angle divided by the hypotenuse.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "understanding-and-solving-trigonometric-ratios",
            "If sin(theta) = 0.5, what is theta (in the range 0 to 90 degrees)?",
            "30 degrees", "45 degrees", "60 degrees", "90 degrees",
            QuestionOption.A,
            "sin(30 degrees) = 0.5, a standard trigonometric value.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-trigonometric-ratios",
            "Surveyors use trigonometric ratios to calculate the height of a building by measuring an angle and a known:",
            "Distance from the building", "Weight of the building", "Color of the building", "Number of floors only",
            QuestionOption.A,
            "Using the angle of elevation and a measured horizontal distance, trigonometric ratios yield the building's height.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-trigonometric-identities",
            "Which is the fundamental Pythagorean trigonometric identity?",
            "sin^2(x) + cos^2(x) = 1", "sin(x) + cos(x) = 1", "sin^2(x) - cos^2(x) = 1", "tan^2(x) = 1",
            QuestionOption.A,
            "This identity follows directly from the Pythagorean theorem applied to the unit circle.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "simplifying-expressions-using-trigonometric-identities",
            "Simplify: sin(x)/cos(x)",
            "sin(x)", "cos(x)", "tan(x)", "sec(x)",
            QuestionOption.C,
            "By definition, tan(x) = sin(x)/cos(x).",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-trigonometric-identities",
            "Trigonometric identities are used in physics to simplify equations describing:",
            "Wave interference and oscillations", "Static objects only", "Random noise", "Discrete counting problems",
            QuestionOption.A,
            "Simplifying trigonometric expressions is essential when analyzing periodic phenomena like waves and oscillations.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-compound-angles",
            "A compound angle formula expresses trig functions of a sum or difference of:",
            "Two angles", "Two lengths", "Two matrices", "Two probabilities",
            QuestionOption.A,
            "Compound angle formulas give sin, cos, or tan of (A + B) or (A - B) in terms of the individual angles A and B.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "solving-problems-using-compound-angle-formulas",
            "The compound angle formula for sin(A+B) is:",
            "sin(A)cos(B) + cos(A)sin(B)", "sin(A)cos(B) - cos(A)sin(B)", "cos(A)cos(B) - sin(A)sin(B)", "sin(A)sin(B) + cos(A)cos(B)",
            QuestionOption.A,
            "This is the standard angle addition formula for sine.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-compound-angles",
            "Compound angle formulas are used in engineering to analyze the combined effect of:",
            "Multiple rotations or phase shifts", "Static loads only", "Constant temperatures", "Fixed colors",
            QuestionOption.A,
            "When combining rotations or wave phase shifts, compound angle identities describe the resulting trigonometric relationships.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-double-and-half-angles",
            "The double angle formula for cos(2x) can be written as:",
            "2sin(x)cos(x)", "cos^2(x) - sin^2(x)", "sin^2(x) + cos^2(x)", "2cos(x)",
            QuestionOption.B,
            "One standard form of the double angle formula for cosine is cos(2x) = cos^2(x) - sin^2(x).",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "solving-problems-using-double-and-half-angle-formulas",
            "The double angle formula for sin(2x) is:",
            "2sin(x)cos(x)", "sin^2(x) - cos^2(x)", "2cos^2(x) - 1", "cos(x) - sin(x)",
            QuestionOption.A,
            "The double angle identity for sine is sin(2x) = 2sin(x)cos(x).",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-double-and-half-angles",
            "Double angle formulas are useful in physics for analyzing signals whose frequency has been:",
            "Doubled", "Halted", "Made negative", "Set to zero",
            QuestionOption.A,
            "Double angle identities directly relate a trigonometric function to one with twice the original frequency.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-inverse-trigonometric-functions",
            "The inverse sine function, arcsin(x), returns an:",
            "Angle whose sine is x", "Area under a curve", "Ratio of two sides only", "Complex number always",
            QuestionOption.A,
            "arcsin(x) gives the angle whose sine equals the input value x.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "solving-problems-using-inverse-trigonometric-functions",
            "What is arcsin(1) in degrees?",
            "0 degrees", "45 degrees", "90 degrees", "180 degrees",
            QuestionOption.C,
            "Since sin(90 degrees) = 1, arcsin(1) = 90 degrees.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-inverse-trigonometric-functions",
            "Inverse trigonometric functions are used in navigation to calculate an unknown:",
            "Angle from known side lengths", "Speed from time only", "Color from light", "Weight from mass",
            QuestionOption.A,
            "Given known distances (sides), inverse trig functions let navigators solve for the required angle.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-trigonometric-equations",
            "A trigonometric equation typically has how many solutions within one full period?",
            "Exactly one always", "Possibly more than one", "Zero always", "Infinitely many within one period",
            QuestionOption.B,
            "Because trigonometric functions are periodic and often not one-to-one, equations can have multiple solutions in one period.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "solving-trigonometric-equations",
            "Solve: sin(x) = 0 for x in [0, 360) degrees.",
            "x = 0 and 180", "x = 90 only", "x = 270 only", "x = 45 and 135",
            QuestionOption.A,
            "sin(x) = 0 at x = 0 degrees and x = 180 degrees within one full rotation.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-trigonometric-equations",
            "Trigonometric equations are used in engineering to find the times at which a periodic signal reaches a:",
            "Specific value", "Random location", "Fixed color", "Zero mass",
            QuestionOption.A,
            "Solving trig equations reveals the specific times a periodic (wave-like) signal crosses a target value.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-heights-and-distances",
            "The angle of elevation is measured from the horizontal upward to a line of sight toward an object that is:",
            "Below the observer", "Above the observer", "At the same level", "Behind the observer",
            QuestionOption.B,
            "The angle of elevation is the upward angle from horizontal to an object positioned higher than the observer.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "solving-problems-using-heights-and-distances",
            "From a point 50 m from a tower, the angle of elevation to its top is 45 degrees. What is the tower's height?",
            "25 m", "50 m", "70.7 m", "100 m",
            QuestionOption.B,
            "Since tan(45) = 1, the height equals the horizontal distance: height = 50 * tan(45) = 50 m.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-heights-and-distances",
            "Heights and distances problems are commonly used by pilots and air traffic controllers to determine:",
            "An aircraft's altitude and distance from a runway", "Passenger seating arrangements", "Fuel color", "Ticket prices",
            QuestionOption.A,
            "Angle-based height and distance calculations help determine an aircraft's altitude relative to a known ground distance.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-graphs-of-trigonometric-functions",
            "The graph of y = sin(x) has a period of:",
            "90 degrees", "180 degrees", "360 degrees", "45 degrees",
            QuestionOption.C,
            "The sine function completes one full cycle every 360 degrees (2*pi radians).",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "understanding-and-analyzing-trigonometric-graphs",
            "The amplitude of y = 3sin(x) is:",
            "1", "2", "3", "6",
            QuestionOption.C,
            "The amplitude is the coefficient in front of the sine function, here 3.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-trigonometric-graphs",
            "Trigonometric graphs are used to model periodic phenomena such as:",
            "Sound waves and tides", "Static structures only", "Discrete counting", "Random noise only",
            QuestionOption.A,
            "Since sound waves and tides repeat in regular cycles, sine and cosine graphs naturally model their behavior.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-vector-basics",
            "Unlike a scalar, a vector has both magnitude and:",
            "Color", "Direction", "Weight", "Temperature",
            QuestionOption.B,
            "A vector is defined by both its magnitude (size) and its direction, unlike a scalar which has magnitude only.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "representation-and-components-of-vectors",
            "A vector v = (3, 4) has a magnitude of:",
            "5", "7", "12", "25",
            QuestionOption.A,
            "Magnitude = sqrt(3^2 + 4^2) = sqrt(9+16) = sqrt(25) = 5.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-vector-basics",
            "Vectors are used in physics to represent quantities such as:",
            "Force and velocity", "Temperature only", "Mass only", "Time only",
            QuestionOption.A,
            "Force and velocity both have direction as well as magnitude, making vectors the natural way to represent them.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-vector-operations",
            "Vector addition combines two vectors to produce a:",
            "Scalar", "Resultant vector", "Matrix", "Angle only",
            QuestionOption.B,
            "Adding two vectors produces a new resultant vector that represents their combined effect.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "performing-vector-operations",
            "Add the vectors (2,3) and (1,4).",
            "(3,7)", "(1,1)", "(2,12)", "(3,1)",
            QuestionOption.A,
            "Vector addition is performed component-wise: (2+1, 3+4) = (3,7).",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-vector-operations",
            "Pilots use vector addition to calculate a plane's resultant path when combining its velocity with:",
            "Wind velocity", "Fuel level", "Cabin pressure", "Passenger count",
            QuestionOption.A,
            "Adding the plane's velocity vector to the wind velocity vector gives the actual resultant ground path.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-dot-product",
            "The dot product of two vectors results in a:",
            "Vector", "Scalar", "Matrix", "Complex number",
            QuestionOption.B,
            "Unlike the cross product, the dot product of two vectors produces a single scalar value.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "calculating-and-interpreting-dot-product",
            "Find the dot product of (1,2) and (3,4).",
            "7", "10", "11", "14",
            QuestionOption.C,
            "Dot product = (1*3) + (2*4) = 3 + 8 = 11.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-dot-product",
            "In physics, the dot product of force and displacement vectors is used to calculate:",
            "Work done", "Torque", "Angular velocity", "Momentum only",
            QuestionOption.A,
            "Work done by a force is calculated as the dot product of the force vector and the displacement vector.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-cross-product",
            "The cross product of two vectors produces a vector that is:",
            "Parallel to both original vectors", "Perpendicular to both original vectors", "Equal to zero always", "A scalar",
            QuestionOption.B,
            "The cross product yields a new vector perpendicular to the plane containing the two original vectors.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "calculating-and-interpreting-cross-product",
            "The direction of the cross product vector is determined using the:",
            "Right-hand rule", "Left-hand rule", "Pythagorean theorem", "Sine rule only",
            QuestionOption.A,
            "The right-hand rule conventionally determines the direction of the resulting cross product vector.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-cross-product",
            "In mechanics, the cross product of a force vector and a position vector is used to calculate:",
            "Torque", "Work done", "Kinetic energy", "Momentum only",
            QuestionOption.A,
            "Torque is calculated as the cross product of the position vector and the applied force vector.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-vector-projection",
            "Vector projection finds the component of one vector that lies along the direction of:",
            "Another vector", "The origin", "The x-axis only", "A random line",
            QuestionOption.A,
            "Projection decomposes one vector into the part that points in the same direction as a second reference vector.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "calculating-vector-projection",
            "The scalar projection of vector a onto vector b is calculated using:",
            "(a . b) / |b|", "a x b", "|a| + |b|", "a . b * |b|",
            QuestionOption.A,
            "The scalar projection formula divides the dot product of a and b by the magnitude of b.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-vector-projection",
            "Vector projection is used in physics to determine the component of a force acting:",
            "Along a specific direction, such as an incline", "Perpendicular to gravity only", "In no particular direction", "Only vertically",
            QuestionOption.A,
            "Projecting a force vector onto a chosen direction, like an inclined surface, gives the effective force along that direction.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-direction-cosines",
            "Direction cosines describe the angles a vector makes with the:",
            "Coordinate axes", "Origin only", "Other vectors only", "Plane of rotation only",
            QuestionOption.A,
            "Direction cosines are the cosines of the angles a vector makes with each of the coordinate axes.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "calculating-direction-cosines-and-ratios",
            "The sum of the squares of the direction cosines of any vector always equals:",
            "0", "1", "The vector's magnitude", "Infinity",
            QuestionOption.B,
            "For any vector, l^2 + m^2 + n^2 = 1, where l, m, n are its direction cosines.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-direction-cosines",
            "Aerospace engineers use direction cosines to describe the orientation of a spacecraft relative to:",
            "A fixed reference coordinate system", "Its fuel level", "Its color scheme", "Its passenger count",
            QuestionOption.A,
            "Direction cosines precisely describe a vector's (or spacecraft's) orientation relative to fixed reference axes.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-lines-in-space",
            "A line in three-dimensional space can be represented using a point and a:",
            "Direction vector", "Scalar value only", "Color", "Single number",
            QuestionOption.A,
            "A 3D line is defined by a known point on the line together with a vector indicating its direction.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "equations-and-relationships-of-lines-in-space",
            "Two lines in space that do not intersect and are not parallel are called:",
            "Coincident", "Skew", "Perpendicular", "Concurrent",
            QuestionOption.B,
            "Lines that neither intersect nor run parallel in three dimensions are called skew lines.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-lines-in-space",
            "Robotics engineers use 3D line equations to plan the straight-line path of a robotic arm's:",
            "End-effector movement", "Power supply", "Color sensors", "Internal clock",
            QuestionOption.A,
            "Representing motion paths as 3D lines helps engineers plan precise straight-line movements for a robotic arm.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "introduction-to-planes",
            "A plane in three-dimensional space can be defined using a point and a:",
            "Normal vector", "Single scalar", "Color", "Line segment only",
            QuestionOption.A,
            "A plane is uniquely determined by a point on it and a vector perpendicular (normal) to its surface.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "equations-and-properties-of-planes",
            "The general Cartesian equation of a plane is written as:",
            "ax + by + cz = d", "ax + by = c", "x + y + z = 0 always", "ax^2 + by^2 = c",
            QuestionOption.A,
            "This linear equation in three variables, ax + by + cz = d, represents a plane in three-dimensional space.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "applications-and-practice-of-planes",
            "In computer graphics, planes are used to model flat surfaces such as:",
            "Walls and floors in a 3D scene", "Sound effects", "File compression", "Network latency",
            QuestionOption.A,
            "Flat surfaces like walls and floors in 3D rendering are mathematically represented using planes.",
            DifficultyLevel.Advance,
            1);

        context.PracticeQuestions.AddRange(questions);
        await context.SaveChangesAsync();
    }
}

