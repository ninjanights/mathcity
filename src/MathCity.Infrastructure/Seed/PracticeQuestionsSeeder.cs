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

        var lessons = await context.Lessons
            .ToDictionaryAsync(l => l.Title);

        var questions = new List<PracticeQuestion>();

        void AddQuestion(
            string lessonTitle,
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
            questions.Add(new PracticeQuestion
            {
                LessonId = lessons[lessonTitle].Id,
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
        }

       
        // Introduction to Algebraic Expressions
       
        AddQuestion(
            "Introduction to Algebraic Expressions",
            "Which of the following is an algebraic expression?",
            "5 + 3 = 8",
            "2x + 7",
            "10 > 6",
            "x = 5",
            QuestionOption.B,
            "An algebraic expression contains numbers, variables, and mathematical operations without an equality or inequality sign.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Algebraic Expressions",
            "In the expression 7x + 5, what is the coefficient of x?",
            "7",
            "5",
            "x",
            "12",
            QuestionOption.A,
            "The coefficient is the numerical factor multiplied by the variable. Here, 7 is multiplied by x.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Algebraic Expressions",
            "Which part of the expression 4y - 9 is the constant term?",
            "4",
            "y",
            "-9",
            "4y",
            QuestionOption.C,
            "A constant is a value without any variable attached. In 4y - 9, the constant is -9.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Algebraic Expressions",
            "How many terms are there in the expression 3a + 2b - 5?",
            "2",
            "3",
            "4",
            "5",
            QuestionOption.B,
            "The terms are 3a, 2b, and -5, making a total of three terms.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Algebraic Expressions",
            "Which statement best describes an algebraic expression?",
            "It always contains an equal sign.",
            "It is made up of variables, constants, and operations.",
            "It can only contain numbers.",
            "It always has exactly one variable.",
            QuestionOption.B,
            "An algebraic expression combines variables, constants, and mathematical operations without requiring an equality sign.",
            DifficultyLevel.Advance,
            5);

        
        // Introduction to Linear Equations
        

        AddQuestion(
            "Introduction to Linear Equations",
            "Which of the following is a linear equation?",
            "x² + 3 = 7",
            "2x + 5 = 11",
            "x³ - 1 = 0",
            "√x = 4",
            QuestionOption.B,
            "A linear equation has the highest power of the variable equal to 1. Therefore, 2x + 5 = 11 is a linear equation.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Linear Equations",
            "What is the highest exponent of the variable in a linear equation?",
            "0",
            "1",
            "2",
            "3",
            QuestionOption.B,
            "A linear equation is defined by having the highest exponent of every variable equal to 1.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Linear Equations",
            "Which equation is in the standard form of a linear equation in one variable?",
            "ax + b = 0",
            "ax² + bx + c = 0",
            "a/x = b",
            "x³ + 1 = 0",
            QuestionOption.A,
            "The standard form of a linear equation in one variable is ax + b = 0, where a ≠ 0.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Linear Equations",
            "What is the solution of a linear equation?",
            "The coefficient of the variable",
            "The value of the variable that satisfies the equation",
            "The constant term",
            "The highest exponent",
            QuestionOption.B,
            "A solution is the value of the variable that makes both sides of the equation equal.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Linear Equations",
            "Why are linear equations widely used in mathematics and real-life applications?",
            "They only work with whole numbers.",
            "They model relationships between variables and help solve practical problems.",
            "They always have more than one solution.",
            "They cannot be represented graphically.",
            QuestionOption.B,
            "Linear equations are used to represent relationships between quantities and are widely applied in science, engineering, economics, and everyday problem-solving.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Simultaneous Equations
        // ==========================================================

        AddQuestion(
            "Introduction to Simultaneous Equations",
            "What are simultaneous equations?",
            "Two or more equations solved together to find common unknown values",
            "Equations containing only one variable",
            "Equations with exponents greater than one",
            "Equations without variables",
            QuestionOption.A,
            "Simultaneous equations consist of two or more equations that share the same variables and are solved together.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Simultaneous Equations",
            "Why are simultaneous equations solved together?",
            "To simplify fractions",
            "To find values that satisfy all the equations at the same time",
            "To remove variables permanently",
            "To convert equations into inequalities",
            QuestionOption.B,
            "The solution must satisfy every equation in the system simultaneously.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Simultaneous Equations",
            "A pair of simultaneous equations with two variables usually has how many unknowns?",
            "One",
            "Two",
            "Three",
            "Four",
            QuestionOption.B,
            "A typical system contains two unknown variables, such as x and y.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Simultaneous Equations",
            "Which of the following is an example of simultaneous equations?",
            "x + 2 = 5",
            "x² + y² = 25",
            "2x + y = 7 and x - y = 1",
            "5 > 3",
            QuestionOption.C,
            "A system of simultaneous equations contains two or more equations involving the same variables.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Simultaneous Equations",
            "Where are simultaneous equations commonly used?",
            "Only in geometry",
            "Only in accounting",
            "To model and solve problems involving multiple unknown quantities",
            "Only for calculating percentages",
            QuestionOption.C,
            "Simultaneous equations are widely used in science, engineering, economics, and everyday situations where multiple unknowns must be determined.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Introduction to Inequalities
        // ==========================================================

        AddQuestion(
            "Introduction to Inequalities",
            "What is the primary purpose of an inequality?",
            "To show that two expressions are always equal",
            "To compare two quantities using inequality symbols",
            "To find the square root of a number",
            "To simplify algebraic expressions",
            QuestionOption.B,
            "An inequality compares two quantities and shows whether one is greater than, less than, greater than or equal to, or less than or equal to the other.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Inequalities",
            "Which symbol represents 'greater than'?",
            "<",
            ">",
            "=",
            "≠",
            QuestionOption.B,
            "The symbol '>' means that the value on the left is greater than the value on the right.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Inequalities",
            "Which of the following is an inequality?",
            "4x + 2 = 10",
            "5 + 3 = 8",
            "2x - 1 ≥ 7",
            "3 × 4 = 12",
            QuestionOption.C,
            "An inequality uses symbols such as <, >, ≤, or ≥ instead of the equality sign.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Inequalities",
            "Which symbol means 'less than or equal to'?",
            "<",
            "≤",
            "≥",
            ">",
            QuestionOption.B,
            "The symbol '≤' indicates that a value is either less than or equal to another value.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Inequalities",
            "Why are inequalities useful in mathematics and real-life situations?",
            "They are only used to solve geometry problems.",
            "They help compare quantities and describe limits or ranges of possible values.",
            "They can only compare whole numbers.",
            "They always have exactly one solution.",
            QuestionOption.B,
            "Inequalities are used to represent conditions, limits, and ranges in areas such as budgeting, science, engineering, and optimization problems.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Introduction to Polynomials
        // ==========================================================

        AddQuestion(
            "Introduction to Polynomials",
            "What is a polynomial?",
            "An algebraic expression made up of variables, constants, and non-negative integer exponents",
            "An equation that always contains an equal sign",
            "An expression containing variables only",
            "A mathematical expression with negative exponents only",
            QuestionOption.A,
            "A polynomial is an algebraic expression consisting of variables, constants, and non-negative integer exponents combined using addition, subtraction, and multiplication.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Polynomials",
            "Which of the following is a polynomial?",
            "3x² + 2x - 5",
            "5/x + 2",
            "√x + 4",
            "2x⁻¹ + 3",
            QuestionOption.A,
            "A polynomial cannot have variables in denominators, radicals, or negative exponents. Therefore, 3x² + 2x - 5 is a polynomial.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Polynomials",
            "What is the degree of the polynomial 4x³ + 2x - 7?",
            "1",
            "2",
            "3",
            "4",
            QuestionOption.C,
            "The degree of a polynomial is the highest exponent of its variable. Here, the highest exponent is 3.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Polynomials",
            "What is the standard form of a polynomial?",
            "Terms arranged from the lowest degree to the highest",
            "Terms arranged in any order",
            "Terms arranged from the highest degree to the lowest",
            "Only constant terms written together",
            QuestionOption.C,
            "The standard form of a polynomial arranges terms in descending order of their degrees.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Polynomials",
            "Why are polynomials important in mathematics and science?",
            "They are only used for school examinations.",
            "They are used to model relationships, solve equations, and represent real-world phenomena.",
            "They can only represent straight lines.",
            "They are only applicable in geometry.",
            QuestionOption.B,
            "Polynomials are widely used in algebra, calculus, physics, engineering, economics, computer graphics, and many other fields to model and solve real-world problems.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Introduction to Factorization
        // ==========================================================

        AddQuestion(
            "Introduction to Factorization",
            "What is factorization?",
            "The process of expanding an expression",
            "The process of writing an expression as a product of simpler factors",
            "The process of adding like terms",
            "The process of solving an equation",
            QuestionOption.B,
            "Factorization is the process of expressing an algebraic expression as the product of two or more simpler factors.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Factorization",
            "Why is factorization important in algebra?",
            "It makes expressions more complicated.",
            "It helps simplify expressions and solve equations more efficiently.",
            "It is only used in geometry.",
            "It replaces variables with constants.",
            QuestionOption.B,
            "Factorization simplifies algebraic expressions and is an essential technique for solving equations and understanding mathematical relationships.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Factorization",
            "Which of the following is a factor of the expression 6x?",
            "2x",
            "6x²",
            "x + 6",
            "6 + x",
            QuestionOption.A,
            "Since 6x = 2x × 3, 2x is a factor of 6x.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Factorization",
            "What is the opposite process of factorization?",
            "Division",
            "Expansion",
            "Substitution",
            "Simplification",
            QuestionOption.B,
            "Expansion multiplies factors together to produce an algebraic expression, making it the opposite of factorization.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Factorization",
            "In which area is factorization commonly applied?",
            "Only in arithmetic",
            "Only in statistics",
            "Solving equations, simplifying expressions, and higher mathematics",
            "Only in geometry",
            QuestionOption.C,
            "Factorization is a fundamental tool used throughout algebra, calculus, engineering, computer science, and many other mathematical disciplines.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Introduction to Rational Expressions
        // ==========================================================

        AddQuestion(
            "Introduction to Rational Expressions",
            "What is a rational expression?",
            "An algebraic expression written as the quotient of two polynomials",
            "An equation containing only fractions",
            "An expression containing square roots only",
            "A polynomial with no variables",
            QuestionOption.A,
            "A rational expression is a fraction in which both the numerator and denominator are polynomials, and the denominator is not zero.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Rational Expressions",
            "Which of the following is a rational expression?",
            "(x + 2)/(x - 1)",
            "√x + 5",
            "x² + √x",
            "2ˣ + 1",
            QuestionOption.A,
            "A rational expression is formed by dividing one polynomial by another polynomial.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Rational Expressions",
            "Why must the denominator of a rational expression never be zero?",
            "Because the numerator would become zero.",
            "Because division by zero is undefined.",
            "Because the expression becomes a polynomial.",
            "Because the variables disappear.",
            QuestionOption.B,
            "Division by zero is undefined in mathematics, so any value that makes the denominator zero is excluded from the domain.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Rational Expressions",
            "What is meant by the domain of a rational expression?",
            "The degree of the numerator",
            "The values for which the expression is defined",
            "The number of variables in the expression",
            "The coefficient of the highest-degree term",
            QuestionOption.B,
            "The domain consists of all values that do not make the denominator equal to zero.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Rational Expressions",
            "How are rational expressions related to numerical fractions?",
            "They follow similar rules, but use polynomials instead of numbers.",
            "They are exactly the same as whole numbers.",
            "They can never be simplified.",
            "They always have a denominator of one.",
            QuestionOption.A,
            "Rational expressions extend the idea of fractions by replacing numbers with polynomials while following many of the same mathematical rules.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Exponents
        // ==========================================================

        AddQuestion(
            "Introduction to Exponents",
            "What does an exponent represent?",
            "Repeated addition of a number",
            "Repeated multiplication of a base by itself",
            "Division of two numbers",
            "The square root of a number",
            QuestionOption.B,
            "An exponent indicates how many times the base is multiplied by itself. For example, 2³ = 2 × 2 × 2.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Exponents",
            "In the expression 5⁴, which number is the base?",
            "4",
            "5",
            "20",
            "9",
            QuestionOption.B,
            "The base is the number being repeatedly multiplied. In 5⁴, the base is 5 and the exponent is 4.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Exponents",
            "What is the exponent in the expression x⁶?",
            "x",
            "6",
            "x⁶",
            "1",
            QuestionOption.B,
            "The exponent tells how many times the base is multiplied by itself. In x⁶, the exponent is 6.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Exponents",
            "Which expression represents 3 × 3 × 3 × 3?",
            "3²",
            "3³",
            "3⁴",
            "4³",
            QuestionOption.C,
            "The base 3 is multiplied by itself four times, so the expression is written as 3⁴.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Exponents",
            "Why are exponents widely used in mathematics and science?",
            "They make repeated multiplication easier to write and calculate.",
            "They can only represent square numbers.",
            "They replace variables in equations.",
            "They are only used in geometry.",
            QuestionOption.A,
            "Exponents provide a compact way to represent repeated multiplication and are fundamental in algebra, physics, engineering, computer science, and finance.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Introduction to Radicals and Surds
        // ==========================================================

        AddQuestion(
            "Introduction to Radicals and Surds",
            "What is a radical in mathematics?",
            "A symbol used to represent a root of a number or expression",
            "A symbol used for multiplication",
            "A type of polynomial",
            "An equation with two variables",
            QuestionOption.A,
            "A radical is represented by the symbol √ and is used to indicate roots such as square roots and cube roots.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Radicals and Surds",
            "Which of the following is a surd?",
            "√16",
            "√25",
            "√2",
            "√81",
            QuestionOption.C,
            "A surd is an irrational root that cannot be simplified into a rational number. √2 is a surd, while √16, √25, and √81 simplify to whole numbers.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Radicals and Surds",
            "What is the value of √49?",
            "6",
            "7",
            "8",
            "9",
            QuestionOption.B,
            "Since 7 × 7 = 49, the principal square root of 49 is 7.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Radicals and Surds",
            "Which statement correctly describes a surd?",
            "It can always be written as a whole number.",
            "It represents an irrational root that cannot be simplified exactly.",
            "It is always equal to zero.",
            "It is another name for a fraction.",
            QuestionOption.B,
            "Surds represent irrational roots that cannot be expressed exactly as fractions or terminating decimals.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Radicals and Surds",
            "Why are radicals and surds important in mathematics?",
            "They are only used in arithmetic.",
            "They help represent and solve problems involving irrational roots in algebra, geometry, and science.",
            "They replace all fractions.",
            "They are only useful for calculating percentages.",
            QuestionOption.B,
            "Radicals and surds are widely used in algebra, geometry, engineering, physics, and many scientific calculations involving irrational numbers.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Introduction to Logarithms
        // ==========================================================

        AddQuestion(
            "Introduction to Logarithms",
            "What is a logarithm?",
            "A way of expressing repeated addition",
            "The exponent to which a base must be raised to produce a given number",
            "The square root of a number",
            "A type of polynomial",
            QuestionOption.B,
            "A logarithm answers the question: 'To what exponent must the base be raised to obtain a given value?'",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Logarithms",
            "Logarithms are the inverse operation of which mathematical concept?",
            "Addition",
            "Subtraction",
            "Multiplication",
            "Exponentiation",
            QuestionOption.D,
            "Logarithms reverse exponentiation. For example, if 2³ = 8, then log₂(8) = 3.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Logarithms",
            "In the expression log₁₀(100) = 2, what is the base?",
            "2",
            "10",
            "100",
            "1",
            QuestionOption.B,
            "The small number written below the logarithm symbol is the base. Here, the base is 10.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Logarithms",
            "What does log₂(8) = 3 mean?",
            "2 + 3 = 8",
            "2 × 3 = 8",
            "2³ = 8",
            "8³ = 2",
            QuestionOption.C,
            "The logarithm states that raising the base 2 to the exponent 3 produces 8.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Logarithms",
            "Why are logarithms important in mathematics and science?",
            "They are only used in geometry.",
            "They help solve exponential problems and model real-world phenomena such as population growth, earthquakes, and sound intensity.",
            "They replace fractions in algebra.",
            "They are only used for basic arithmetic.",
            QuestionOption.B,
            "Logarithms simplify calculations involving exponential relationships and are widely used in mathematics, engineering, physics, chemistry, finance, and computer science.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Introduction to Absolute Value
        // ==========================================================

        AddQuestion(
            "Introduction to Absolute Value",
            "What does the absolute value of a number represent?",
            "Its distance from zero on the number line",
            "Its opposite value",
            "Its square root",
            "Its largest factor",
            QuestionOption.A,
            "The absolute value of a number is its non-negative distance from zero, regardless of its direction.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Absolute Value",
            "What is the absolute value of -8?",
            "-8",
            "8",
            "0",
            "16",
            QuestionOption.B,
            "Absolute value measures distance from zero, so |-8| = 8.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Absolute Value",
            "Which notation is used to represent the absolute value of x?",
            "(x)",
            "[x]",
            "|x|",
            "{x}",
            QuestionOption.C,
            "Absolute value is represented using two vertical bars, such as |x|.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Absolute Value",
            "Which statement about absolute value is always true?",
            "It is always negative.",
            "It is always less than zero.",
            "It is always greater than or equal to zero.",
            "It is always equal to the original number.",
            QuestionOption.C,
            "Since absolute value represents distance from zero, it can never be negative.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Absolute Value",
            "Why is the concept of absolute value important in mathematics?",
            "It measures distance without considering direction and is widely used in algebra, geometry, and real-world applications.",
            "It is only used for solving fractions.",
            "It replaces exponents in equations.",
            "It is only applicable to positive numbers.",
            QuestionOption.A,
            "Absolute value is essential for measuring magnitude, solving equations and inequalities, and representing distances in mathematics, science, and engineering.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Introduction to Algebraic Identities
        // ==========================================================

        AddQuestion(
            "Introduction to Algebraic Identities",
            "What is an algebraic identity?",
            "An equation that is true only for one specific value",
            "An equation that is true for all valid values of the variables",
            "An expression containing only constants",
            "An equation with two unknown variables",
            QuestionOption.B,
            "An algebraic identity is an equation that holds true for every valid value of its variables.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Algebraic Identities",
            "Which of the following is an algebraic identity?",
            "(a + b)² = a² + 2ab + b²",
            "x + 5 = 10",
            "2x = 8",
            "x² = 9",
            QuestionOption.A,
            "The expansion (a + b)² = a² + 2ab + b² is true for all values of a and b, making it an algebraic identity.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Algebraic Identities",
            "What is the main purpose of algebraic identities?",
            "To simplify expressions and solve mathematical problems efficiently",
            "To replace variables with constants",
            "To find the square root of numbers",
            "To compare two inequalities",
            QuestionOption.A,
            "Algebraic identities are widely used to simplify expressions, expand products, factorize expressions, and solve equations.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Algebraic Identities",
            "Which of the following is a commonly used algebraic identity?",
            "(a - b)² = a² - 2ab + b²",
            "a + b = ab",
            "a² + b² = (a + b)²",
            "a - b = 0",
            QuestionOption.A,
            "The identity (a - b)² = a² - 2ab + b² is one of the fundamental algebraic identities.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Algebraic Identities",
            "Why are algebraic identities important in mathematics?",
            "They provide universally true relationships that simplify calculations and are widely used in algebra, calculus, engineering, and science.",
            "They are only useful in arithmetic.",
            "They eliminate the need for variables.",
            "They are only used for graphing equations.",
            QuestionOption.A,
            "Algebraic identities form the foundation for simplifying expressions, solving equations, factorization, and advanced mathematical problem-solving across many disciplines.",
            DifficultyLevel.Advance,
            5);













        context.PracticeQuestions.AddRange(questions);
        await context.SaveChangesAsync();
    }
}