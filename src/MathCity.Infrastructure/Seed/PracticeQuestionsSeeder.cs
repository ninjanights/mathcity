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

        // ==========================================================
        // Simplifying and Evaluating Algebraic Expressions
        // ==========================================================

        AddQuestion(
            "Simplifying and Evaluating Algebraic Expressions",
            "What is the simplified form of 3x + 2x?",
            "5x",
            "6x",
            "5",
            "x²",
            QuestionOption.A,
            "Like terms can be combined by adding their coefficients. 3x + 2x = 5x.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Simplifying and Evaluating Algebraic Expressions",
            "Simplify: 4a + 3 - 2a + 5",
            "6a + 8",
            "2a + 8",
            "2a + 2",
            "6a + 2",
            QuestionOption.B,
            "Combine like terms: 4a - 2a = 2a and 3 + 5 = 8, giving 2a + 8.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Simplifying and Evaluating Algebraic Expressions",
            "Evaluate 2x + 5 when x = 3.",
            "8",
            "10",
            "11",
            "13",
            QuestionOption.C,
            "Substitute x = 3: 2(3) + 5 = 6 + 5 = 11.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Simplifying and Evaluating Algebraic Expressions",
            "Which expression is equivalent to 5(x + 2)?",
            "5x + 2",
            "5x + 10",
            "x + 10",
            "5x + 5",
            QuestionOption.B,
            "Using the distributive property: 5(x + 2) = 5x + 10.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Simplifying and Evaluating Algebraic Expressions",
            "Why is simplifying algebraic expressions important?",
            "It makes expressions easier to understand, compare, and solve.",
            "It removes all variables from mathematics.",
            "It only works for numbers without variables.",
            "It changes equations into shapes.",
            QuestionOption.A,
            "Simplification reduces complex expressions into simpler forms, making further calculations and problem-solving easier.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Applications and Practice of Algebraic Expressions
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Algebraic Expressions",
            "A pencil costs ₹x and a notebook costs ₹20. Which expression represents the total cost of 3 pencils and 2 notebooks?",
            "3x + 20",
            "3x + 40",
            "5x + 20",
            "3(x + 20)",
            QuestionOption.B,
            "The cost of 3 pencils is 3x and the cost of 2 notebooks is 2 × 20 = 40, so the total is 3x + 40.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Algebraic Expressions",
            "If the length of a rectangle is x + 5 and the width is x, which expression represents its perimeter?",
            "2x + 5",
            "x² + 5",
            "4x + 10",
            "2x + 10",
            QuestionOption.C,
            "Perimeter of a rectangle = 2(length + width). So 2((x + 5) + x) = 2(2x + 5) = 4x + 10.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Algebraic Expressions",
            "A student has x books and receives 7 more books. Which expression represents the new number of books?",
            "x - 7",
            "7x",
            "x + 7",
            "x ÷ 7",
            QuestionOption.C,
            "Receiving 7 more books means adding 7 to the original number, giving x + 7.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Algebraic Expressions",
            "The cost of a trip is represented by 50 + 10d, where d is the number of days. What does 10d represent?",
            "The fixed starting cost",
            "The cost added for each day",
            "The total number of days",
            "A variable with no meaning",
            QuestionOption.B,
            "10d represents the daily cost multiplied by the number of days.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Algebraic Expressions",
            "Why are algebraic expressions useful in real-world situations?",
            "They help represent unknown values and relationships using mathematical models.",
            "They only work for classroom exercises.",
            "They remove the need for calculations.",
            "They cannot represent real situations.",
            QuestionOption.A,
            "Algebraic expressions allow us to model situations involving costs, distances, quantities, and changing values.",
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
        // Solving Linear Equations
        // ==========================================================

        AddQuestion(
            "Solving Linear Equations",
            "Solve: x + 5 = 12",
            "x = 5",
            "x = 7",
            "x = 12",
            "x = 17",
            QuestionOption.B,
            "Subtract 5 from both sides: x + 5 - 5 = 12 - 5, so x = 7.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Solving Linear Equations",
            "Solve: 3x = 15",
            "x = 3",
            "x = 5",
            "x = 10",
            "x = 45",
            QuestionOption.B,
            "Divide both sides by 3: 3x ÷ 3 = 15 ÷ 3, so x = 5.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Solving Linear Equations",
            "Solve: 2x + 4 = 10",
            "x = 2",
            "x = 3",
            "x = 4",
            "x = 7",
            QuestionOption.B,
            "Subtract 4 from both sides: 2x = 6. Divide by 2: x = 3.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Solving Linear Equations",
            "Which method is used to keep both sides of an equation balanced while solving?",
            "Changing the answer randomly",
            "Performing the same operation on both sides",
            "Removing variables without calculation",
            "Ignoring numbers on one side",
            QuestionOption.B,
            "The balance method requires applying the same operation to both sides so the equation remains equal.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Solving Linear Equations",
            "Why are linear equations useful in real-world problems?",
            "They help model relationships involving unknown values such as cost, distance, and time.",
            "They only solve geometry problems.",
            "They cannot represent real situations.",
            "They remove the need for variables.",
            QuestionOption.A,
            "Linear equations are used to represent and solve problems involving relationships between quantities.",
            DifficultyLevel.Advance,
            5);



        // ==========================================================
        // Applications and Practice of Linear Equations
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Linear Equations",
            "A taxi charges a fixed fee of ₹50 and ₹10 per kilometer. Which equation represents the total cost C for k kilometers?",
            "C = 50k + 10",
            "C = 50 + 10k",
            "C = 10 + k",
            "C = 50 - 10k",
            QuestionOption.B,
            "The fixed fee is ₹50 and the additional cost is ₹10 multiplied by the number of kilometers, so C = 50 + 10k.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Linear Equations",
            "A student has ₹100 and saves ₹20 every week. Which equation represents the total money M after w weeks?",
            "M = 100 + 20w",
            "M = 100w + 20",
            "M = 20 - 100w",
            "M = 100 - 20",
            QuestionOption.A,
            "The starting amount is ₹100 and ₹20 is added each week, giving M = 100 + 20w.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Linear Equations",
            "A car travels at a constant speed of 60 km/h. Which equation represents distance d after t hours?",
            "d = 60 + t",
            "d = 60t",
            "d = t ÷ 60",
            "d = 60 - t",
            QuestionOption.B,
            "Distance = speed × time, so d = 60t.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Linear Equations",
            "A phone plan costs ₹200 per month plus ₹5 per GB of data used. If the total bill is ₹350, how many GB were used?",
            "20 GB",
            "30 GB",
            "40 GB",
            "50 GB",
            QuestionOption.B,
            "The equation is 200 + 5x = 350. Subtract 200: 5x = 150. Divide by 5: x = 30 GB.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Linear Equations",
            "Why are linear equations useful for modelling real-world situations?",
            "They represent relationships between changing quantities and help predict unknown values.",
            "They only work with numbers without variables.",
            "They cannot describe real-life relationships.",
            "They are only used in geometry.",
            QuestionOption.A,
            "Linear equations are widely used in finance, science, engineering, business, and everyday decision-making to model relationships between quantities.",
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
        // Methods for Solving Simultaneous Equations
        // ==========================================================

        AddQuestion(
            "Methods for Solving Simultaneous Equations",
            "Which method involves replacing one variable with an expression from another equation?",
            "Elimination method",
            "Substitution method",
            "Graphical method",
            "Factorization method",
            QuestionOption.B,
            "The substitution method solves simultaneous equations by expressing one variable in terms of another and substituting it into the second equation.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Methods for Solving Simultaneous Equations",
            "Which method eliminates one variable by adding or subtracting equations?",
            "Substitution",
            "Graphical",
            "Elimination",
            "Division",
            QuestionOption.C,
            "The elimination method combines equations to cancel one variable and find the remaining unknown.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Methods for Solving Simultaneous Equations",
            "Solve using elimination: x + y = 10 and x - y = 2. What is the value of x?",
            "4",
            "5",
            "6",
            "8",
            QuestionOption.C,
            "Adding both equations gives 2x = 12, so x = 6.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Methods for Solving Simultaneous Equations",
            "In the graphical method, what represents the solution of two simultaneous equations?",
            "The point where both lines intersect",
            "The highest point on a line",
            "The y-axis only",
            "The distance between lines",
            QuestionOption.A,
            "The intersection point of two graphs represents the values of x and y that satisfy both equations.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Methods for Solving Simultaneous Equations",
            "Why are different methods used for solving simultaneous equations?",
            "Different methods provide efficient ways to solve systems depending on the form of equations.",
            "Each method gives a different answer.",
            "Only one method is mathematically correct.",
            "Methods are used only for drawing graphs.",
            QuestionOption.A,
            "Substitution, elimination, and graphical methods are different approaches that help solve systems efficiently.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Applications and Practice of Simultaneous Equations
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Simultaneous Equations",
            "A notebook costs ₹x and a pen costs ₹y. If 2 notebooks and 3 pens cost ₹160, which equation represents this situation?",
            "2x + 3y = 160",
            "x + y = 160",
            "2x - 3y = 160",
            "x × y = 160",
            QuestionOption.A,
            "The total cost is found by multiplying each item's price by its quantity and adding them together.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Simultaneous Equations",
            "Two numbers have a sum of 20 and their difference is 4. Which pair represents these numbers?",
            "8 and 12",
            "10 and 10",
            "5 and 15",
            "6 and 14",
            QuestionOption.A,
            "Let the numbers be x and y. Solving x + y = 20 and x - y = 4 gives x = 12 and y = 8.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Simultaneous Equations",
            "A farm has chickens and cows. There are 20 animals and 56 legs in total. How many cows are there?",
            "6",
            "8",
            "10",
            "12",
            QuestionOption.B,
            "Let chickens = x and cows = y. x + y = 20 and 2x + 4y = 56. Solving gives y = 8 cows.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Simultaneous Equations",
            "Why are simultaneous equations useful in real-life problems?",
            "They help find unknown values when multiple conditions are connected.",
            "They only solve single-variable problems.",
            "They are only used for drawing graphs.",
            "They cannot represent real situations.",
            QuestionOption.A,
            "Many real-world problems involve multiple unknown quantities that are related through different conditions.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Simultaneous Equations",
            "Which field commonly uses simultaneous equations for solving complex problems?",
            "Engineering and economics",
            "Only handwriting practice",
            "Only basic counting",
            "Only shape drawing",
            QuestionOption.A,
            "Engineers, economists, scientists, and analysts use simultaneous equations to model relationships between multiple variables.",
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
        // Solving and Graphing Inequalities
        // ==========================================================

        AddQuestion(
            "Solving and Graphing Inequalities",
            "Solve: x + 3 > 7",
            "x > 3",
            "x > 4",
            "x < 4",
            "x < 3",
            QuestionOption.B,
            "Subtract 3 from both sides: x + 3 - 3 > 7 - 3, so x > 4.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Solving and Graphing Inequalities",
            "Which symbol represents 'less than or equal to'?",
            ">",
            "<",
            "≥",
            "≤",
            QuestionOption.D,
            "The symbol ≤ means a value is less than or equal to another value.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Solving and Graphing Inequalities",
            "Solve: 2x ≤ 10",
            "x ≤ 2",
            "x ≤ 5",
            "x ≥ 5",
            "x ≥ 2",
            QuestionOption.B,
            "Divide both sides by 2: 2x ÷ 2 ≤ 10 ÷ 2, so x ≤ 5.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Solving and Graphing Inequalities",
            "What happens when an inequality is divided by a negative number?",
            "The inequality sign reverses direction",
            "The inequality disappears",
            "The answer becomes zero",
            "The variable is removed",
            QuestionOption.A,
            "When multiplying or dividing both sides of an inequality by a negative number, the inequality sign must be reversed.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Solving and Graphing Inequalities",
            "Why are inequalities represented on number lines?",
            "They show a range of possible solutions instead of a single value.",
            "They remove the need for solving.",
            "They only show positive numbers.",
            "They are used only for equations.",
            QuestionOption.A,
            "Unlike equations that usually have specific solutions, inequalities represent sets or ranges of values.",
            DifficultyLevel.Advance,
            5);



        // ==========================================================
        // Applications and Practice of Inequalities
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Inequalities",
            "A student must score at least 50 marks to pass an exam. Which inequality represents this situation if x is the student's score?",
            "x < 50",
            "x > 50",
            "x ≥ 50",
            "x ≤ 50",
            QuestionOption.C,
            "The phrase 'at least 50' means the score can be 50 or more, so x ≥ 50.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Inequalities",
            "A bus can carry a maximum of 40 passengers. Which inequality represents the number of passengers p?",
            "p ≥ 40",
            "p ≤ 40",
            "p = 40",
            "p > 40",
            QuestionOption.B,
            "Maximum means the number cannot exceed 40, so p ≤ 40.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Inequalities",
            "A mobile data plan allows up to 20 GB of data usage. If x represents used data, which inequality is correct?",
            "x < 20",
            "x ≤ 20",
            "x ≥ 20",
            "x = 20",
            QuestionOption.B,
            "Up to 20 GB means the usage can be 20 or any smaller amount, so x ≤ 20.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Inequalities",
            "A shopkeeper wants to spend less than ₹500 on supplies. Which inequality represents the spending amount s?",
            "s > 500",
            "s < 500",
            "s ≥ 500",
            "s = 500",
            QuestionOption.B,
            "The phrase 'less than ₹500' means the amount must be smaller than 500, so s < 500.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Inequalities",
            "Why are inequalities useful for solving real-world problems?",
            "They help represent limits, conditions, and possible ranges of values.",
            "They only work with exact answers.",
            "They cannot represent practical situations.",
            "They are only used for drawing graphs.",
            QuestionOption.A,
            "Inequalities are used in budgeting, engineering limits, speed restrictions, capacity problems, and many other situations where ranges matter.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Introduction to Quadratic Equations
        // ==========================================================

        AddQuestion(
            "Introduction to Quadratic Equations",
            "What is the standard form of a quadratic equation?",
            "ax + b = 0",
            "ax² + bx + c = 0",
            "a + b + c = 0",
            "x² + x = 1",
            QuestionOption.B,
            "A quadratic equation is written in the standard form ax² + bx + c = 0, where a is not equal to zero.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Quadratic Equations",
            "What is the highest power of the variable in a quadratic equation?",
            "1",
            "2",
            "3",
            "4",
            QuestionOption.B,
            "Quadratic equations contain a variable raised to the power of 2, which is why they are called quadratic.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Quadratic Equations",
            "Which part of the equation ax² + bx + c = 0 is the quadratic term?",
            "a",
            "bx",
            "ax²",
            "c",
            QuestionOption.C,
            "The term ax² is the quadratic term because it contains the variable with exponent 2.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Quadratic Equations",
            "How are quadratic equations different from linear equations?",
            "Quadratic equations have a squared variable term, while linear equations have only a first-degree variable.",
            "Quadratic equations have no variables.",
            "Linear equations always have x² terms.",
            "There is no difference between them.",
            QuestionOption.A,
            "Linear equations have degree 1, while quadratic equations have degree 2 because of the x² term.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Quadratic Equations",
            "Why are quadratic equations important in mathematics and real-world applications?",
            "They help model situations involving areas, motion, optimization, and many scientific problems.",
            "They are only used for simple calculations.",
            "They cannot represent real situations.",
            "They are only used for naming shapes.",
            QuestionOption.A,
            "Quadratic equations are used in physics, engineering, economics, architecture, and many other fields to model curved relationships.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Methods for Solving Quadratic Equations
        // ==========================================================

        AddQuestion(
            "Methods for Solving Quadratic Equations",
            "Which method solves a quadratic equation by expressing it as a product of two factors?",
            "Graphing",
            "Factorization",
            "Substitution",
            "Division",
            QuestionOption.B,
            "Factorization involves rewriting a quadratic expression as a product of two or more factors and finding the values that make each factor zero.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Methods for Solving Quadratic Equations",
            "What is the quadratic formula used for?",
            "To solve quadratic equations of the form ax² + bx + c = 0",
            "To solve only linear equations",
            "To calculate areas of shapes",
            "To simplify fractions only",
            QuestionOption.A,
            "The quadratic formula provides solutions for any quadratic equation where a is not zero.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Methods for Solving Quadratic Equations",
            "Which expression appears inside the square root of the quadratic formula?",
            "a + b + c",
            "b² - 4ac",
            "2a + b",
            "x² + y²",
            QuestionOption.B,
            "The expression b² - 4ac is called the discriminant and determines the nature of the roots.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Methods for Solving Quadratic Equations",
            "What is the purpose of completing the square method?",
            "To rewrite a quadratic equation into a perfect square form",
            "To remove all variables",
            "To convert it into a linear equation",
            "To multiply both sides randomly",
            QuestionOption.A,
            "Completing the square transforms a quadratic expression into a form that can be solved using square roots.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Methods for Solving Quadratic Equations",
            "Why is it useful to have multiple methods for solving quadratic equations?",
            "Different methods are suitable for different equations and problem situations.",
            "Each method always gives a different answer.",
            "Only one method is mathematically valid.",
            "Methods are used only for graph drawing.",
            QuestionOption.A,
            "Factorization, completing the square, and the quadratic formula provide different approaches depending on the structure of the equation.",
            DifficultyLevel.Advance,
            5);



        // ==========================================================
        // Applications and Practice of Quadratic Equations
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Quadratic Equations",
            "A ball is thrown upward and its height is represented by h = -5t² + 20t. What type of equation represents this situation?",
            "Linear equation",
            "Quadratic equation",
            "Constant equation",
            "Fraction equation",
            QuestionOption.B,
            "The equation contains t², making it a quadratic equation. Quadratic equations are commonly used to model projectile motion.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Quadratic Equations",
            "Why are quadratic equations used to model projectile motion?",
            "Because the height changes in a curved path due to gravity.",
            "Because motion always follows a straight line.",
            "Because they cannot contain variables.",
            "Because they only represent fixed values.",
            QuestionOption.A,
            "Objects thrown into the air follow a parabolic path, which can be represented using quadratic equations.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Quadratic Equations",
            "The area of a rectangular garden is represented by x(x + 5) = 150. Why can this be solved using a quadratic equation?",
            "Because multiplying the expressions creates an x² term.",
            "Because it contains no variables.",
            "Because it is always a linear equation.",
            "Because area cannot be calculated.",
            QuestionOption.A,
            "Expanding x(x + 5) gives x² + 5x = 150, which is a quadratic equation.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Quadratic Equations",
            "What does the graph of a quadratic equation look like?",
            "A parabola",
            "A straight line",
            "A circle",
            "A rectangle",
            QuestionOption.A,
            "The graph of a quadratic equation forms a parabola, which can open upward or downward depending on the coefficient of x².",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Quadratic Equations",
            "Why are quadratic equations important in real-world applications?",
            "They help solve problems involving optimization, motion, area, and changing relationships.",
            "They are only used for basic arithmetic.",
            "They cannot represent practical situations.",
            "They are only useful for drawing graphs.",
            QuestionOption.A,
            "Quadratic equations are widely used in physics, engineering, economics, architecture, and computer science for modelling complex relationships.",
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
        // Polynomial Operations and Factorization
        // ==========================================================

        AddQuestion(
            "Polynomial Operations and Factorization",
            "What is the result of adding 3x² + 2x and 5x² + 4x?",
            "8x² + 6x",
            "15x² + 8x",
            "8x² + 8",
            "2x² + 2x",
            QuestionOption.A,
            "Add like terms: 3x² + 5x² = 8x² and 2x + 4x = 6x.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Polynomial Operations and Factorization",
            "Simplify: (4x² + 3x) - (2x² + x)",
            "2x² + 2x",
            "6x² + 4x",
            "2x² + 4x",
            "6x² + 2x",
            QuestionOption.A,
            "Subtract corresponding terms: 4x² - 2x² = 2x² and 3x - x = 2x.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Polynomial Operations and Factorization",
            "Which method is used to rewrite a polynomial as a product of simpler expressions?",
            "Expansion",
            "Factorization",
            "Addition",
            "Division",
            QuestionOption.B,
            "Factorization breaks a polynomial into factors that multiply together to give the original expression.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Polynomial Operations and Factorization",
            "Factorize: x² + 5x + 6",
            "(x + 2)(x + 3)",
            "(x + 1)(x + 6)",
            "(x + 5)(x + 6)",
            "(x + 2)(x + 4)",
            QuestionOption.A,
            "Find two numbers whose product is 6 and sum is 5. These are 2 and 3, so x² + 5x + 6 = (x + 2)(x + 3).",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Polynomial Operations and Factorization",
            "Why are polynomial operations and factorization important?",
            "They simplify expressions and help solve mathematical problems involving variables.",
            "They only apply to numbers without variables.",
            "They remove the need for calculations.",
            "They are only used for drawing graphs.",
            QuestionOption.A,
            "Polynomial operations are essential in algebra, calculus, physics, engineering, and many mathematical applications.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Applications and Practice of Polynomials
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Polynomials",
            "The area of a rectangle is represented by x² + 5x + 6. Which polynomial form represents its factored dimensions?",
            "(x + 2)(x + 3)",
            "(x + 1)(x + 6)",
            "(x + 5)(x + 6)",
            "(x + 2)(x + 4)",
            QuestionOption.A,
            "Factoring x² + 5x + 6 gives (x + 2)(x + 3), which can represent the length and width of the rectangle.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Polynomials",
            "A company models its profit using a polynomial function. Why are polynomials useful in such situations?",
            "They can represent changing relationships between quantities.",
            "They only represent fixed numbers.",
            "They cannot include variables.",
            "They are only used for geometry.",
            QuestionOption.A,
            "Polynomial functions can model real-world changes such as profit, growth, motion, and cost relationships.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Polynomials",
            "If a polynomial function gives the height of an object over time, what can its graph help determine?",
            "Important values such as maximum height and when the object reaches certain positions.",
            "Only the colour of the object.",
            "The object's weight only.",
            "The number of variables used.",
            QuestionOption.A,
            "Graphs of polynomial functions help analyze behaviour, turning points, intercepts, and changes over time.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Polynomials",
            "Which operation is commonly used to simplify polynomial expressions before solving problems?",
            "Combining like terms",
            "Changing variables randomly",
            "Removing all coefficients",
            "Ignoring negative values",
            QuestionOption.A,
            "Combining like terms reduces polynomial expressions into simpler forms.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Polynomials",
            "Why are polynomial concepts important in advanced mathematics and science?",
            "They are used to model complex systems in engineering, physics, computing, and data analysis.",
            "They are only useful for basic calculations.",
            "They cannot describe real-world patterns.",
            "They are unrelated to scientific fields.",
            QuestionOption.A,
            "Polynomials are fundamental tools used in many fields to approximate and analyze real-world phenomena.",
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
        // Methods of Factorization
        // ==========================================================

        AddQuestion(
            "Methods of Factorization",
            "What is the first step when factoring an algebraic expression using the common factor method?",
            "Find the greatest common factor of all terms",
            "Multiply all terms together",
            "Remove all variables",
            "Convert it into a graph",
            QuestionOption.A,
            "The common factor method begins by identifying the greatest factor shared by all terms and taking it outside the brackets.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Methods of Factorization",
            "Factorize: 6x + 12",
            "6(x + 2)",
            "3(2x + 12)",
            "2(3x + 12)",
            "6(x + 12)",
            QuestionOption.A,
            "The greatest common factor of 6x and 12 is 6, so 6x + 12 = 6(x + 2).",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Methods of Factorization",
            "Which identity is used to factorize a² - b²?",
            "(a + b)²",
            "(a - b)(a + b)",
            "a² + b²",
            "(a + b)(a + b)",
            QuestionOption.B,
            "The difference of squares identity states that a² - b² = (a - b)(a + b).",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Methods of Factorization",
            "Which method is commonly used to factorize expressions with four terms by grouping them?",
            "Grouping method",
            "Division method",
            "Graphing method",
            "Substitution method",
            QuestionOption.A,
            "The grouping method separates terms into groups and finds common factors from each group.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Methods of Factorization",
            "Why is factorization important in algebra?",
            "It simplifies expressions and helps solve equations by breaking them into simpler factors.",
            "It removes all mathematical operations.",
            "It only changes numbers into decimals.",
            "It is only useful for drawing graphs.",
            QuestionOption.A,
            "Factorization is used extensively in solving equations, simplifying expressions, and understanding algebraic structures.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Applications and Practice of Factorization
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Factorization",
            "Factorize x² + 7x + 12.",
            "(x + 3)(x + 4)",
            "(x + 2)(x + 6)",
            "(x + 1)(x + 12)",
            "(x + 5)(x + 7)",
            QuestionOption.A,
            "Find two numbers whose product is 12 and sum is 7. The numbers are 3 and 4, so x² + 7x + 12 = (x + 3)(x + 4).",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Factorization",
            "A rectangular garden has an area represented by x² + 10x + 24. Which expression represents its possible dimensions?",
            "(x + 4)(x + 6)",
            "(x + 2)(x + 12)",
            "(x + 1)(x + 24)",
            "(x + 5)(x + 5)",
            QuestionOption.A,
            "Factorizing x² + 10x + 24 gives (x + 4)(x + 6), which can represent the length and width.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Factorization",
            "Solve the equation x² - 9 = 0 using factorization.",
            "x = 3 only",
            "x = -3 only",
            "x = ±3",
            "x = 9",
            QuestionOption.C,
            "Using difference of squares: x² - 9 = (x - 3)(x + 3). Therefore, x = 3 or x = -3.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Factorization",
            "Which real-world area commonly uses factorization?",
            "Engineering and mathematical modelling",
            "Only handwriting improvement",
            "Only counting objects",
            "Only naming shapes",
            QuestionOption.A,
            "Factorization is used in engineering, physics, computer science, and many areas where mathematical expressions need to be simplified.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Factorization",
            "Why is factorization useful when solving algebraic equations?",
            "It transforms complex expressions into simpler factors that are easier to analyze and solve.",
            "It removes variables from every equation.",
            "It prevents equations from being solved.",
            "It only changes the appearance of numbers.",
            QuestionOption.A,
            "Factorization helps identify possible solutions by rewriting expressions as products of simpler terms.",
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
        // Simplifying and Operating on Rational Expressions
        // ==========================================================

        AddQuestion(
            "Simplifying and Operating on Rational Expressions",
            "What is the first step when simplifying a rational expression?",
            "Factor the numerator and denominator",
            "Add the numerator and denominator",
            "Remove all variables",
            "Multiply all terms randomly",
            QuestionOption.A,
            "To simplify rational expressions, factor the numerator and denominator first, then cancel common factors.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Simplifying and Operating on Rational Expressions",
            "Simplify: 6x / 3",
            "2x",
            "3x",
            "6x",
            "x/2",
            QuestionOption.A,
            "Divide the coefficient 6 by 3 to get 2, so 6x/3 = 2x.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Simplifying and Operating on Rational Expressions",
            "When adding rational expressions with different denominators, what must be found first?",
            "A common denominator",
            "A common numerator",
            "A square root",
            "A factor of zero",
            QuestionOption.A,
            "Fractions with different denominators must be converted to equivalent forms using a common denominator before adding.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Simplifying and Operating on Rational Expressions",
            "Simplify: x² / x",
            "x",
            "x²",
            "1/x",
            "2x",
            QuestionOption.A,
            "Cancel the common factor x from numerator and denominator, leaving x (where x ≠ 0).",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Simplifying and Operating on Rational Expressions",
            "Why are operations on rational expressions important in algebra?",
            "They help simplify complex expressions and solve equations involving fractions and variables.",
            "They only work with whole numbers.",
            "They remove the need for algebraic rules.",
            "They are only used in geometry.",
            QuestionOption.A,
            "Rational expressions are used in advanced algebra, calculus, physics, engineering, and many mathematical models.",
            DifficultyLevel.Advance,
            5);



        // ==========================================================
        // Applications and Practice of Rational Expressions
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Rational Expressions",
            "A car travels a distance of d kilometers in t hours. Which rational expression represents its average speed?",
            "d + t",
            "d / t",
            "d × t",
            "t / d",
            QuestionOption.B,
            "Average speed is calculated using the formula distance divided by time, so speed = d/t.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Rational Expressions",
            "A worker completes a job in x hours. Which expression represents the work rate?",
            "x",
            "1/x",
            "x²",
            "x + 1",
            QuestionOption.B,
            "Rate is the amount of work divided by time. If one job is completed in x hours, the rate is 1/x.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Rational Expressions",
            "A formula contains the expression (x² - 9)/(x - 3). What is the simplified form?",
            "x - 3",
            "x + 3",
            "x² + 3",
            "1",
            QuestionOption.B,
            "Factor the numerator: x² - 9 = (x - 3)(x + 3). Cancel the common factor (x - 3), leaving x + 3 (where x ≠ 3).",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Rational Expressions",
            "Which real-world situation can be represented using rational expressions?",
            "Calculating speed, rates, and proportions",
            "Only naming geometric shapes",
            "Only counting objects",
            "Only drawing graphs",
            QuestionOption.A,
            "Rational expressions are commonly used for rates, ratios, speed, and relationships involving division.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Rational Expressions",
            "Why are rational expressions important in advanced mathematics?",
            "They help model relationships involving rates, variables, and changing quantities.",
            "They are only used for simple arithmetic.",
            "They cannot represent real-world problems.",
            "They eliminate the need for equations.",
            QuestionOption.A,
            "Rational expressions are widely used in algebra, calculus, physics, engineering, and scientific modelling.",
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
        // Laws and Operations of Exponents
        // ==========================================================

        AddQuestion(
            "Laws and Operations of Exponents",
            "Which exponent law is used when multiplying powers with the same base?",
            "Add the exponents",
            "Subtract the exponents",
            "Multiply the bases only",
            "Divide the exponents",
            QuestionOption.A,
            "When multiplying powers with the same base, the exponents are added: aᵐ × aⁿ = aᵐ⁺ⁿ.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Laws and Operations of Exponents",
            "Simplify: x³ × x²",
            "x⁵",
            "x⁶",
            "x",
            "x²",
            QuestionOption.A,
            "Using the product rule of exponents, add the powers: x³ × x² = x³⁺² = x⁵.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Laws and Operations of Exponents",
            "What is the value of any non-zero number raised to the power of zero?",
            "The number itself",
            "Zero",
            "One",
            "Undefined",
            QuestionOption.C,
            "The zero exponent rule states that a⁰ = 1 for any non-zero value of a.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Laws and Operations of Exponents",
            "Simplify: (x²)³",
            "x⁵",
            "x⁶",
            "x⁹",
            "x²",
            QuestionOption.B,
            "Using the power of a power rule, multiply the exponents: (x²)³ = x²×³ = x⁶.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Laws and Operations of Exponents",
            "Why are exponent laws important in mathematics?",
            "They simplify calculations and help solve complex expressions efficiently.",
            "They remove variables from equations.",
            "They only apply to geometry.",
            "They are only used for counting numbers.",
            QuestionOption.A,
            "Exponent rules are essential for simplifying expressions in algebra, calculus, science, engineering, and computing.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Applications and Practice of Exponents
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Exponents",
            "Scientific notation is mainly used to represent which type of numbers?",
            "Very large or very small numbers",
            "Only whole numbers",
            "Only negative numbers",
            "Only fractions",
            QuestionOption.A,
            "Scientific notation uses powers of 10 to represent extremely large or small values in a compact form.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Exponents",
            "Express 1,000,000 using scientific notation.",
            "1 × 10⁶",
            "1 × 10³",
            "10 × 10⁶",
            "100 × 10²",
            QuestionOption.A,
            "1,000,000 has six zeros, so it can be written as 1 × 10⁶.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Exponents",
            "A population doubles every year. Which mathematical concept can represent this growth?",
            "Exponential growth",
            "Linear growth",
            "Constant value",
            "Factorization",
            QuestionOption.A,
            "When a quantity grows by a constant multiplier over time, it is represented using exponential growth.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Exponents",
            "Simplify: 2³ × 2⁴",
            "2⁷",
            "2¹²",
            "4⁷",
            "2¹",
            QuestionOption.A,
            "Using the exponent multiplication rule, add the powers: 2³ × 2⁴ = 2³⁺⁴ = 2⁷.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Exponents",
            "Why are exponent concepts important in science and technology?",
            "They help model growth, decay, measurements, and extremely large or small quantities.",
            "They are only used for simple addition.",
            "They cannot represent real-world situations.",
            "They are only useful in geometry.",
            QuestionOption.A,
            "Exponents are widely used in physics, computing, biology, finance, and scientific calculations.",
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
        // Simplifying and Operating on Radicals
        // ==========================================================

        AddQuestion(
            "Simplifying and Operating on Radicals",
            "Simplify: √16",
            "2",
            "4",
            "8",
            "16",
            QuestionOption.B,
            "The square root of 16 is 4 because 4 × 4 = 16.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Simplifying and Operating on Radicals",
            "What is the first step when simplifying a radical expression?",
            "Find perfect square factors inside the radical",
            "Remove all variables",
            "Multiply all numbers together",
            "Convert it into a fraction",
            QuestionOption.A,
            "To simplify radicals, identify perfect square factors that can be taken outside the radical symbol.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Simplifying and Operating on Radicals",
            "Simplify: √50",
            "5√2",
            "2√5",
            "5√10",
            "10√5",
            QuestionOption.B,
            "√50 = √(25 × 2) = √25 × √2 = 5√2.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Simplifying and Operating on Radicals",
            "Which condition allows two radical terms to be added or subtracted directly?",
            "They must have the same radicand",
            "They must have different variables",
            "They must have different square roots",
            "They must always be integers",
            QuestionOption.A,
            "Only like radicals, which have the same radicand, can be combined by addition or subtraction.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Simplifying and Operating on Radicals",
            "Why is rationalizing the denominator used in radical expressions?",
            "To remove radicals from the denominator and make expressions simpler.",
            "To increase the number of radicals.",
            "To remove all variables.",
            "To convert every expression into a decimal.",
            QuestionOption.A,
            "Rationalizing the denominator creates an equivalent expression with a rational denominator, making calculations easier.",
            DifficultyLevel.Advance,
            5);



        // ==========================================================
        // Applications and Practice of Radicals and Surds
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Radicals and Surds",
            "Which real-world field commonly uses radicals and surds?",
            "Geometry and engineering",
            "Only basic counting",
            "Only alphabetical sorting",
            "Only data storage",
            QuestionOption.A,
            "Radicals are used in geometry, physics, engineering, and measurement calculations involving distances and lengths.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Radicals and Surds",
            "The distance formula uses square roots. Why are radicals useful in this situation?",
            "They help calculate exact distances between points.",
            "They remove the need for measurements.",
            "They only work with whole numbers.",
            "They convert all values to zero.",
            QuestionOption.A,
            "Distance calculations often involve square roots, making radicals useful for finding exact lengths.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Radicals and Surds",
            "Simplify: √9 + √16",
            "5",
            "7",
            "25",
            "√25",
            QuestionOption.B,
            "√9 = 3 and √16 = 4, so √9 + √16 = 3 + 4 = 7.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Radicals and Surds",
            "A square has an area of 50 cm². Which expression represents the length of one side?",
            "√50 cm",
            "50² cm",
            "25 cm",
            "50 + 50 cm",
            QuestionOption.A,
            "The side length of a square is the square root of its area, so the side is √50 cm.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Radicals and Surds",
            "Why are radicals and surds important in advanced mathematics?",
            "They allow exact representation of values that cannot always be written as simple integers or fractions.",
            "They only work for basic arithmetic.",
            "They eliminate mathematical formulas.",
            "They are only used for drawing shapes.",
            QuestionOption.A,
            "Radicals appear throughout algebra, geometry, calculus, physics, and engineering when exact values are required.",
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
        // Laws and Properties of Logarithms
        // ==========================================================

        AddQuestion(
            "Laws and Properties of Logarithms",
            "Which logarithm property is used when multiplying two numbers inside a logarithm?",
            "Product rule",
            "Quotient rule",
            "Power rule",
            "Zero rule",
            QuestionOption.A,
            "The product rule states that log(ab) = log(a) + log(b), allowing multiplication to be converted into addition.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Laws and Properties of Logarithms",
            "Which property states that log(a/b) = log(a) - log(b)?",
            "Product rule",
            "Quotient rule",
            "Power rule",
            "Inverse rule",
            QuestionOption.B,
            "The quotient rule converts division inside a logarithm into subtraction of logarithms.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Laws and Properties of Logarithms",
            "Simplify using the power rule: log(x³)",
            "3log(x)",
            "log(x)³",
            "xlog(3)",
            "log(x + 3)",
            QuestionOption.A,
            "The power rule states that log(xⁿ) = n log(x), so log(x³) = 3log(x).",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Laws and Properties of Logarithms",
            "What is the relationship between exponential and logarithmic forms?",
            "They are inverse operations.",
            "They are unrelated operations.",
            "They always produce the same value.",
            "They only work with negative numbers.",
            QuestionOption.A,
            "Logarithms undo exponentiation, making them inverse operations of exponential functions.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Laws and Properties of Logarithms",
            "Why are logarithm properties important in mathematics?",
            "They simplify complex expressions and help solve exponential equations.",
            "They remove all mathematical operations.",
            "They are only used for geometry.",
            "They only apply to whole numbers.",
            QuestionOption.A,
            "Logarithm laws are essential in algebra, calculus, computer science, finance, and scientific modelling.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Applications and Practice of Logarithms
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Logarithms",
            "Which real-world situation commonly uses logarithms?",
            "Measuring earthquake intensity and sound levels",
            "Counting simple objects",
            "Naming geometric shapes",
            "Drawing straight lines",
            QuestionOption.A,
            "Logarithms are used in scales such as the Richter scale for earthquakes, decibel scale for sound, and many scientific measurements.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Logarithms",
            "Why are logarithms useful for representing very large numbers?",
            "They compress large values into smaller, manageable scales.",
            "They remove all numbers completely.",
            "They only work with negative values.",
            "They convert numbers into fractions only.",
            QuestionOption.A,
            "Logarithmic scales make it easier to compare extremely large or small quantities.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Logarithms",
            "If log₁₀(1000) = x, what is the value of x?",
            "2",
            "3",
            "10",
            "1000",
            QuestionOption.B,
            "Since 10³ = 1000, log₁₀(1000) = 3.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Logarithms",
            "A scientist uses logarithms to analyze population growth. Why are logarithms helpful?",
            "They help study exponential relationships and growth patterns.",
            "They remove the need for calculations.",
            "They only represent linear changes.",
            "They cannot be used with variables.",
            QuestionOption.A,
            "Logarithms are useful when working with exponential growth, decay, and changing quantities over time.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Logarithms",
            "Why are logarithms important in advanced mathematics and technology?",
            "They are used in algorithms, data analysis, scientific modelling, and solving exponential problems.",
            "They are only used for basic arithmetic.",
            "They have no practical applications.",
            "They only apply to geometry.",
            QuestionOption.A,
            "Logarithms are widely used in computer science, engineering, physics, finance, and information theory.",
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
        // Operations and Equations with Absolute Value
        // ==========================================================

        AddQuestion(
            "Operations and Equations with Absolute Value",
            "What does the absolute value of a number represent?",
            "Its distance from zero on the number line",
            "Its opposite value",
            "Its decimal form",
            "Its square value",
            QuestionOption.A,
            "Absolute value represents the distance of a number from zero, so it is always non-negative.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Operations and Equations with Absolute Value",
            "Solve: |x| = 5",
            "x = 5 only",
            "x = -5 only",
            "x = ±5",
            "x = 0",
            QuestionOption.C,
            "Since both 5 and -5 are 5 units away from zero, |x| = 5 gives x = ±5.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Operations and Equations with Absolute Value",
            "Simplify: |-8| + |3|",
            "5",
            "11",
            "-5",
            "-11",
            QuestionOption.B,
            "The absolute values are |-8| = 8 and |3| = 3, so the sum is 8 + 3 = 11.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Operations and Equations with Absolute Value",
            "When solving an absolute value equation |x| = a where a is positive, how many solutions are usually possible?",
            "One solution",
            "Two solutions",
            "No solutions",
            "Infinite solutions",
            QuestionOption.B,
            "For a positive value of a, both x = a and x = -a satisfy the equation.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Operations and Equations with Absolute Value",
            "Why are absolute value equations useful in real-world problems?",
            "They help model situations involving distance, error, and differences without considering direction.",
            "They only work with negative numbers.",
            "They remove all variables from equations.",
            "They are only used for geometry.",
            QuestionOption.A,
            "Absolute value is widely used in measurements, statistics, computer science, and engineering to represent magnitude or distance.",
            DifficultyLevel.Advance,
            5);



        // ==========================================================
        // Applications and Practice of Absolute Value
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Absolute Value",
            "A person walks 5 km east and another person walks 5 km west from the same point. How can absolute value describe their distances?",
            "Both distances are represented as 5 km because direction is ignored.",
            "The west distance becomes negative.",
            "The east distance becomes zero.",
            "Absolute value cannot represent distance.",
            QuestionOption.A,
            "Absolute value represents distance from a reference point without considering direction.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Absolute Value",
            "A temperature changes from 20°C to 15°C. What is the absolute change in temperature?",
            "5°C",
            "-5°C",
            "35°C",
            "0°C",
            QuestionOption.A,
            "The difference is 15 - 20 = -5, and the absolute value gives |-5| = 5°C.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Absolute Value",
            "A machine has an error of ±0.02 cm in measurement. Why is absolute value useful here?",
            "It represents the size of the error regardless of whether it is positive or negative.",
            "It removes the measurement completely.",
            "It makes all values negative.",
            "It only works with whole numbers.",
            QuestionOption.A,
            "Absolute value is used to represent magnitude of error without considering the direction of deviation.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Absolute Value",
            "Solve: |2x| = 10",
            "x = ±5",
            "x = ±10",
            "x = 5 only",
            "x = 10 only",
            QuestionOption.A,
            "Since |2x| = 10, divide both sides by 2 to get |x| = 5, so x = ±5.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Absolute Value",
            "Why is absolute value important in advanced mathematics and technology?",
            "It helps model distance, optimization, errors, and differences between values.",
            "It only applies to simple arithmetic.",
            "It removes the need for mathematical models.",
            "It is only used for geometry.",
            QuestionOption.A,
            "Absolute value is widely used in statistics, computer science, engineering, optimization, and data analysis.",
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

        // ==========================================================
        // Applying Algebraic Identities
        // ==========================================================

        AddQuestion(
            "Applying Algebraic Identities",
            "Which identity is used to expand (a + b)²?",
            "a² + 2ab + b²",
            "a² - b²",
            "a² + b²",
            "a² - 2ab + b²",
            QuestionOption.A,
            "The square of a sum identity is (a + b)² = a² + 2ab + b².",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applying Algebraic Identities",
            "Expand: (x + 3)²",
            "x² + 6x + 9",
            "x² + 9",
            "x² + 3x + 9",
            "x² - 6x + 9",
            QuestionOption.A,
            "Using (a + b)² = a² + 2ab + b², we get x² + 2(x)(3) + 3² = x² + 6x + 9.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applying Algebraic Identities",
            "Which identity is used to simplify a² - b²?",
            "(a - b)(a + b)",
            "(a + b)²",
            "(a - b)²",
            "a² + b²",
            QuestionOption.A,
            "The difference of squares identity states that a² - b² = (a - b)(a + b).",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applying Algebraic Identities",
            "Simplify: (x + y)(x - y)",
            "x² - y²",
            "x² + y²",
            "x² + 2xy + y²",
            "x² - 2xy + y²",
            QuestionOption.A,
            "Using the difference of squares identity, (x + y)(x - y) = x² - y².",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applying Algebraic Identities",
            "Why are algebraic identities useful?",
            "They provide shortcuts for expanding, simplifying, and factoring expressions.",
            "They remove all variables from equations.",
            "They only work with numbers.",
            "They replace all algebraic operations.",
            QuestionOption.A,
            "Algebraic identities make complex calculations faster and are widely used in algebra, calculus, and applied mathematics.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Applications and Practice of Algebraic Identities
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Algebraic Identities",
            "A square garden has side length (x + 5). Which algebraic identity can be used to find its area?",
            "(a + b)² = a² + 2ab + b²",
            "a² - b² = (a - b)(a + b)",
            "a³ + b³",
            "a² + b² = c²",
            QuestionOption.A,
            "The area of a square is side², so (x + 5)² can be expanded using the square of a sum identity.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Algebraic Identities",
            "Simplify: (2x + 3)²",
            "4x² + 12x + 9",
            "4x² + 9",
            "2x² + 6x + 3",
            "4x² - 12x + 9",
            QuestionOption.A,
            "Using (a + b)² = a² + 2ab + b², we get (2x)² + 2(2x)(3) + 3² = 4x² + 12x + 9.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Algebraic Identities",
            "An engineer uses algebraic identities to simplify design calculations. Why are identities useful?",
            "They reduce complex expressions and make calculations faster.",
            "They remove all variables from formulas.",
            "They only work with numbers.",
            "They prevent equations from being solved.",
            QuestionOption.A,
            "Algebraic identities provide standard patterns that simplify calculations in engineering and science.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Algebraic Identities",
            "Factorize: x² - 25",
            "(x - 5)(x + 5)",
            "(x - 25)(x + 25)",
            "(x - 5)²",
            "(x + 5)²",
            QuestionOption.A,
            "Using the difference of squares identity, x² - 25 = x² - 5² = (x - 5)(x + 5).",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Algebraic Identities",
            "Why are algebraic identities important in higher mathematics?",
            "They help simplify expressions, prove relationships, and solve complex problems efficiently.",
            "They only apply to basic arithmetic.",
            "They replace all mathematical concepts.",
            "They cannot be used in real-world applications.",
            QuestionOption.A,
            "Algebraic identities are fundamental in algebra, calculus, physics, engineering, and computer science.",
            DifficultyLevel.Advance,
            5);


        // Geometry PQ. 2
        // ==========================================================
        // Introduction to Points, Lines & Angles
        // ==========================================================

        AddQuestion(
            "Introduction to Points, Lines & Angles",
            "What is a point in geometry?",
            "A figure with length and width",
            "An exact location with no size or dimensions",
            "A straight path extending infinitely",
            "A closed geometric shape",
            QuestionOption.B,
            "A point represents an exact location in space and has no length, width, or thickness.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Points, Lines & Angles",
            "Which geometric figure extends infinitely in both directions?",
            "Line Segment",
            "Ray",
            "Line",
            "Point",
            QuestionOption.C,
            "A line has no endpoints and extends infinitely in both directions.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Points, Lines & Angles",
            "What is the main difference between a ray and a line segment?",
            "A ray has two endpoints.",
            "A line segment extends infinitely.",
            "A ray has one endpoint and extends infinitely in one direction.",
            "A line segment has no endpoints.",
            QuestionOption.C,
            "A ray begins at one endpoint and continues infinitely in one direction, whereas a line segment has two endpoints.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Points, Lines & Angles",
            "Which instrument is commonly used to measure angles?",
            "Compass",
            "Ruler",
            "Protractor",
            "Divider",
            QuestionOption.C,
            "A protractor is used to measure the size of angles in degrees.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Points, Lines & Angles",
            "Why are points, lines, and angles considered the foundation of geometry?",
            "Because they are only used to draw circles.",
            "Because every geometric figure is built from these basic elements.",
            "Because they only exist in coordinate geometry.",
            "Because they replace algebraic equations.",
            QuestionOption.B,
            "Points, lines, and angles are the fundamental building blocks from which all geometric shapes and structures are formed.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Types of Points, Lines & Angles
        // ==========================================================

        AddQuestion(
            "Types of Points, Lines & Angles",
            "Which type of geometric figure has a location but no size?",
            "Point",
            "Line",
            "Angle",
            "Plane",
            QuestionOption.A,
            "A point represents an exact location in geometry and has no length, width, or thickness.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Types of Points, Lines & Angles",
            "What is a line that extends infinitely in both directions called?",
            "Line segment",
            "Ray",
            "Line",
            "Angle",
            QuestionOption.C,
            "A line extends forever in both directions, while a ray has one endpoint and a line segment has two endpoints.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Types of Points, Lines & Angles",
            "What type of angle measures exactly 90 degrees?",
            "Acute angle",
            "Right angle",
            "Obtuse angle",
            "Straight angle",
            QuestionOption.B,
            "A right angle has a measure of exactly 90°, commonly seen at corners and perpendicular intersections.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Types of Points, Lines & Angles",
            "Two angles that add up to 180° are called what?",
            "Complementary angles",
            "Supplementary angles",
            "Vertical angles",
            "Adjacent angles",
            QuestionOption.B,
            "Supplementary angles have a combined measure of 180°.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Types of Points, Lines & Angles",
            "Why are different types of lines and angles important in geometry?",
            "They help describe shapes, structures, measurements, and relationships between geometric figures.",
            "They are only used for counting numbers.",
            "They cannot describe real objects.",
            "They only apply to algebra.",
            QuestionOption.A,
            "Lines and angles are fundamental concepts used in architecture, engineering, design, navigation, and mathematics.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications of Points, Lines & Angles
        // ==========================================================

        AddQuestion(
            "Applications of Points, Lines & Angles",
            "An architect uses lines and angles when designing buildings. Why are angles important in architecture?",
            "They help create accurate structures and maintain proper measurements.",
            "They remove the need for planning.",
            "They only decorate buildings.",
            "They cannot affect construction.",
            QuestionOption.A,
            "Angles are essential in architecture for designing stable structures, slopes, connections, and accurate layouts.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications of Points, Lines & Angles",
            "A navigation system uses angles to determine direction. Which concept is being applied?",
            "Angle measurement",
            "Polynomial factorization",
            "Number comparison",
            "Algebraic expansion",
            QuestionOption.A,
            "Angles are used in navigation systems to calculate directions, bearings, and positions.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications of Points, Lines & Angles",
            "Engineers use perpendicular lines when designing structures. What does perpendicular mean?",
            "Two lines intersect to form a 90° angle.",
            "Two lines never meet.",
            "Two lines have the same length.",
            "Two lines are always curved.",
            QuestionOption.A,
            "Perpendicular lines meet at a right angle of 90°, which is important for stability and accurate construction.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications of Points, Lines & Angles",
            "Computer graphics use points, lines, and angles to create images. Why are these concepts useful?",
            "They help define shapes, positions, and movements in digital environments.",
            "They only work with physical objects.",
            "They cannot represent digital objects.",
            "They replace computer programming.",
            QuestionOption.A,
            "Geometry concepts are used in computer graphics, animation, games, and simulations to represent objects and movement.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications of Points, Lines & Angles",
            "Why are points, lines, and angles considered fundamental concepts in mathematics?",
            "They form the foundation for geometry, measurement, design, engineering, and spatial reasoning.",
            "They are only used for basic drawings.",
            "They have no real-world applications.",
            "They are unrelated to other mathematical topics.",
            QuestionOption.A,
            "Points, lines, and angles are core building blocks used throughout geometry and many applied sciences.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Introduction to Triangles
        // ==========================================================

        AddQuestion(
            "Introduction to Triangles",
            "What is a triangle?",
            "A polygon with four sides",
            "A polygon with three sides",
            "A shape with one curved side",
            "A polygon with five sides",
            QuestionOption.B,
            "A triangle is a polygon that has exactly three sides and three angles.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Triangles",
            "How many interior angles does a triangle have?",
            "2",
            "3",
            "4",
            "5",
            QuestionOption.B,
            "Every triangle has three interior angles formed by its three sides.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Triangles",
            "What is the sum of the interior angles of any triangle?",
            "90°",
            "180°",
            "270°",
            "360°",
            QuestionOption.B,
            "The sum of the three interior angles of every triangle is always 180°.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Triangles",
            "Which of the following is NOT a type of triangle based on its sides?",
            "Equilateral",
            "Isosceles",
            "Scalene",
            "Rectangle",
            QuestionOption.D,
            "A rectangle is a quadrilateral, not a type of triangle.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Triangles",
            "Why are triangles widely used in engineering and construction?",
            "They always have equal sides.",
            "They are the only shapes with three angles.",
            "They provide strength and structural stability.",
            "They can only be drawn with a compass.",
            QuestionOption.C,
            "Triangles are rigid shapes that distribute forces efficiently, making them ideal for bridges, roofs, towers, and other structures.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Types of Triangles
        // ==========================================================

        AddQuestion(
            "Types of Triangles",
            "A triangle with all three sides equal is called what?",
            "Scalene triangle",
            "Isosceles triangle",
            "Equilateral triangle",
            "Right triangle",
            QuestionOption.C,
            "An equilateral triangle has three equal sides and three equal angles of 60° each.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Types of Triangles",
            "A triangle with exactly two equal sides is called what?",
            "Equilateral triangle",
            "Isosceles triangle",
            "Scalene triangle",
            "Obtuse triangle",
            QuestionOption.B,
            "An isosceles triangle has at least two equal sides and two equal opposite angles.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Types of Triangles",
            "Which type of triangle has three different side lengths?",
            "Equilateral triangle",
            "Isosceles triangle",
            "Scalene triangle",
            "Right triangle",
            QuestionOption.C,
            "A scalene triangle has all three sides with different lengths and usually different angles.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Types of Triangles",
            "A triangle with one angle greater than 90° is called what?",
            "Acute triangle",
            "Right triangle",
            "Obtuse triangle",
            "Equilateral triangle",
            QuestionOption.C,
            "An obtuse triangle contains one angle that measures more than 90°.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Types of Triangles",
            "Why is classifying triangles important in geometry?",
            "It helps identify properties, solve problems, and understand relationships between shapes.",
            "It only changes the appearance of triangles.",
            "It removes the need for measurements.",
            "It is only useful for drawing pictures.",
            QuestionOption.A,
            "Triangle classification helps in geometry proofs, calculations, engineering, architecture, and design.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Applications of Triangles
        // ==========================================================

        AddQuestion(
            "Applications of Triangles",
            "Why are triangles commonly used in building structures and bridges?",
            "They provide strength and stability because of their rigid shape.",
            "They are the easiest shapes to draw.",
            "They cannot change size.",
            "They require no measurements.",
            QuestionOption.A,
            "Triangles are structurally stable because their shape does not easily deform under force.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications of Triangles",
            "Surveyors use triangles to measure distances and locations. Which concept is applied?",
            "Triangulation",
            "Factorization",
            "Polynomial division",
            "Logarithmic scaling",
            QuestionOption.A,
            "Triangulation uses triangle relationships to calculate unknown distances and positions.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications of Triangles",
            "Which triangle property is useful in calculating unknown sides in engineering?",
            "Side-angle relationships",
            "Only the number of vertices",
            "Color of the triangle",
            "Position on a page",
            QuestionOption.A,
            "Properties such as the Pythagorean theorem and trigonometric relationships help calculate unknown measurements.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications of Triangles",
            "Computer graphics use triangles to create 3D models. Why are triangles useful?",
            "They can approximate complex surfaces and are easy to process computationally.",
            "They cannot represent shapes.",
            "They only work in two dimensions.",
            "They replace all computer algorithms.",
            QuestionOption.A,
            "3D graphics engines use triangular meshes because triangles are simple, stable, and efficient to calculate.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications of Triangles",
            "Why are triangles important in advanced mathematics and science?",
            "They are used in geometry, physics, engineering, navigation, and mathematical modelling.",
            "They are only used for basic drawings.",
            "They have no practical applications.",
            "They only apply to classroom exercises.",
            QuestionOption.A,
            "Triangles are fundamental in many fields including architecture, robotics, physics, and computer graphics.",
            DifficultyLevel.Advance,
            5);








        // ==========================================================
        // Introduction to Congruence
        // ==========================================================

        AddQuestion(
            "Introduction to Congruence",
            "What does it mean for two geometric figures to be congruent?",
            "They have the same shape only.",
            "They have the same size only.",
            "They have the same shape and the same size.",
            "They have the same area only.",
            QuestionOption.C,
            "Congruent figures have exactly the same shape and size, even if they are positioned differently.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Congruence",
            "Which symbol is commonly used to represent congruence?",
            "=",
            "≈",
            "∼",
            "≅",
            QuestionOption.D,
            "The symbol '≅' is used to indicate that two geometric figures are congruent.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Congruence",
            "If two triangles are congruent, which statement is always true?",
            "Only their areas are equal.",
            "Their corresponding sides and angles are equal.",
            "Only their perimeters are equal.",
            "They must be equilateral triangles.",
            QuestionOption.B,
            "Congruent triangles have all corresponding sides and corresponding angles equal.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Congruence",
            "Which of the following is NOT sufficient by itself to prove two figures are congruent?",
            "They have the same shape.",
            "Their corresponding sides and angles are equal.",
            "One can be placed exactly over the other.",
            "They have identical dimensions.",
            QuestionOption.A,
            "Having the same shape alone indicates similarity, not congruence, because the sizes may differ.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Congruence",
            "Why is congruence important in engineering and construction?",
            "It ensures components fit together accurately.",
            "It eliminates the need for measurements.",
            "It guarantees every structure is symmetrical.",
            "It is only used in classroom geometry.",
            QuestionOption.A,
            "Congruence ensures manufactured parts and structural components have identical dimensions so they fit and function correctly.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Congruence Criteria
        // ==========================================================

        AddQuestion(
            "Congruence Criteria",
            "Which congruence criterion states that three corresponding sides of two triangles are equal?",
            "SAS",
            "ASA",
            "SSS",
            "RHS",
            QuestionOption.C,
            "SSS (Side-Side-Side) congruence states that two triangles are congruent if all three corresponding sides are equal.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Congruence Criteria",
            "What does SAS stand for in triangle congruence?",
            "Side-Angle-Side",
            "Side-Area-Side",
            "Sum-Angle-Sum",
            "Side-Angle-Sum",
            QuestionOption.A,
            "SAS means Side-Angle-Side, where two sides and the included angle of one triangle match another triangle.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Congruence Criteria",
            "Which criterion proves two right-angled triangles are congruent when the hypotenuse and one side are equal?",
            "ASA",
            "RHS",
            "SSS",
            "AAA",
            QuestionOption.B,
            "RHS (Right angle-Hypotenuse-Side) criterion is used specifically for right-angled triangles.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Congruence Criteria",
            "Why can AAA not be used as a triangle congruence criterion?",
            "It proves similarity but not equal size.",
            "It only works for squares.",
            "It cannot compare angles.",
            "It proves all triangles are equal.",
            QuestionOption.A,
            "AAA only guarantees that triangles have the same shape, meaning they are similar, but their sizes may differ.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Congruence Criteria",
            "Why are congruence criteria important in geometry?",
            "They provide methods to prove that two shapes have the same size and shape.",
            "They only help draw triangles.",
            "They remove the need for measurements.",
            "They are only used for calculations.",
            QuestionOption.A,
            "Congruence criteria are essential for geometric proofs, construction, engineering, and design.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications of Congruence
        // ==========================================================

        AddQuestion(
            "Applications of Congruence",
            "Why is congruence important in manufacturing?",
            "It ensures identical parts are produced with the same size and shape.",
            "It removes the need for measurements.",
            "It only applies to drawings.",
            "It prevents objects from being copied.",
            QuestionOption.A,
            "Manufacturing uses congruence to create identical components that fit together accurately.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications of Congruence",
            "An engineer creates two identical bridge supports. Which geometric concept ensures they match?",
            "Congruence",
            "Similarity only",
            "Perimeter only",
            "Area only",
            QuestionOption.A,
            "Congruent figures have exactly the same shape and size, making them suitable for identical structures.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications of Congruence",
            "In surveying, why are congruent triangles useful?",
            "They help determine unknown distances and verify measurements accurately.",
            "They eliminate all calculations.",
            "They only measure angles.",
            "They cannot represent real locations.",
            QuestionOption.A,
            "Surveyors use congruent triangles to compare measurements and establish accurate positions.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications of Congruence",
            "Which situation is an example of congruence in everyday life?",
            "Two identical tiles placed in different locations.",
            "Two shapes with the same color but different sizes.",
            "Two objects with different shapes.",
            "A circle and a triangle of the same area.",
            QuestionOption.A,
            "Objects that have the same shape and size are congruent, even if their positions are different.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications of Congruence",
            "Why are congruence principles important in advanced mathematics and engineering?",
            "They help prove geometric relationships and create accurate designs and models.",
            "They only apply to simple drawings.",
            "They cannot be used in technology.",
            "They replace all mathematical calculations.",
            QuestionOption.A,
            "Congruence is used in geometry proofs, CAD design, engineering, architecture, and scientific modelling.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Introduction to Similarity
        // ==========================================================

        AddQuestion(
            "Introduction to Similarity",
            "What does it mean for two geometric figures to be similar?",
            "They have the same size only.",
            "They have the same shape but may have different sizes.",
            "They have the same perimeter only.",
            "They have equal angles only.",
            QuestionOption.B,
            "Similar figures have the same shape, while their corresponding sides are proportional and their sizes may differ.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Similarity",
            "Which of the following is always true for similar figures?",
            "Their corresponding angles are equal.",
            "Their corresponding sides are equal.",
            "Their areas are equal.",
            "Their perimeters are always equal.",
            QuestionOption.A,
            "In similar figures, corresponding angles are equal, while corresponding sides are proportional.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Similarity",
            "What is the relationship between the corresponding sides of similar figures?",
            "They are always equal.",
            "They are always perpendicular.",
            "They are proportional.",
            "They have no relationship.",
            QuestionOption.C,
            "The lengths of corresponding sides in similar figures have the same ratio, known as the scale factor.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Similarity",
            "Which statement correctly distinguishes similarity from congruence?",
            "Similar figures must have the same size.",
            "Congruent figures may have different sizes.",
            "Similar figures have the same shape, while congruent figures have the same shape and size.",
            "Similarity and congruence mean the same thing.",
            QuestionOption.C,
            "Congruence requires identical shape and size, whereas similarity requires only the same shape with proportional dimensions.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Similarity",
            "Why is the concept of similarity important in real-world applications?",
            "It is only useful for drawing geometric figures.",
            "It helps create scaled models, maps, blueprints, and architectural designs.",
            "It replaces the need for measurements.",
            "It is only used in triangle problems.",
            QuestionOption.B,
            "Similarity is widely used to create accurate scale models, maps, engineering drawings, and architectural plans.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Similarity Criteria
        // ==========================================================

        AddQuestion(
            "Similarity Criteria",
            "Which similarity criterion states that two triangles are similar if their corresponding angles are equal?",
            "AA",
            "SSS",
            "SAS",
            "RHS",
            QuestionOption.A,
            "AA (Angle-Angle) similarity states that if two corresponding angles of triangles are equal, the triangles are similar.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Similarity Criteria",
            "What does SAS similarity compare between two triangles?",
            "Two sides and the included angle",
            "Three equal sides only",
            "Three equal angles only",
            "Only the areas",
            QuestionOption.A,
            "SAS similarity proves triangles are similar when two pairs of corresponding sides are proportional and the included angles are equal.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Similarity Criteria",
            "Which similarity criterion uses all three pairs of corresponding sides being proportional?",
            "AA",
            "SSS",
            "SAS",
            "ASA",
            QuestionOption.B,
            "SSS similarity states that if all corresponding sides are in the same ratio, the triangles are similar.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Similarity Criteria",
            "What is the main difference between congruent and similar triangles?",
            "Congruent triangles have the same size and shape, while similar triangles have the same shape but may have different sizes.",
            "Similar triangles always have different shapes.",
            "Congruent triangles have different angles.",
            "Similarity only applies to circles.",
            QuestionOption.A,
            "Similarity preserves shape while allowing size changes through proportional scaling.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Similarity Criteria",
            "Why are similarity criteria important in geometry?",
            "They help solve problems involving scale, measurements, proportions, and indirect calculations.",
            "They only help draw triangles.",
            "They remove the need for ratios.",
            "They cannot be used in real-world applications.",
            QuestionOption.A,
            "Similarity is widely used in architecture, maps, engineering, photography, and measurement problems.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications of Similarity
        // ==========================================================

        AddQuestion(
            "Applications of Similarity",
            "Why is similarity useful in map making?",
            "It allows large areas to be represented accurately at smaller scales.",
            "It removes the need for measurements.",
            "It changes the shape of locations.",
            "It only works with circles.",
            QuestionOption.A,
            "Maps use similar figures because they maintain the same shape while reducing or enlarging size using a scale factor.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications of Similarity",
            "Architects create small models of buildings before construction. Which concept is being applied?",
            "Similarity",
            "Factorization",
            "Congruence only",
            "Probability",
            QuestionOption.A,
            "Architectural models are scaled versions of real buildings that preserve the same shape through similarity.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications of Similarity",
            "Surveyors use similar triangles to calculate distances that are difficult to measure directly. Why does this work?",
            "Corresponding sides maintain proportional relationships.",
            "All triangles have equal sizes.",
            "Angles do not matter in triangles.",
            "Similarity removes measurements completely.",
            QuestionOption.A,
            "Similar triangles allow unknown distances to be calculated using ratios between corresponding sides.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications of Similarity",
            "A photograph is enlarged while keeping the same shape. Which geometric concept describes this?",
            "Similarity",
            "Congruence",
            "Reflection",
            "Rotation",
            QuestionOption.A,
            "Scaling an image changes its size while preserving its shape, which is a property of similar figures.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications of Similarity",
            "Why are similarity principles important in engineering and computer graphics?",
            "They allow accurate scaling, modelling, and representation of objects while preserving shape.",
            "They only apply to classroom exercises.",
            "They prevent objects from being resized.",
            "They are unrelated to technology.",
            QuestionOption.A,
            "Similarity is used in CAD design, 3D modelling, simulations, engineering prototypes, and digital graphics.",
            DifficultyLevel.Advance,
            5);



        // ==========================================================
        // Introduction to Quadrilaterals
        // ==========================================================

        AddQuestion(
            "Introduction to Quadrilaterals",
            "What is a quadrilateral?",
            "A polygon with three sides",
            "A polygon with four sides",
            "A polygon with five sides",
            "A shape with one curved side",
            QuestionOption.B,
            "A quadrilateral is a closed polygon that has exactly four sides and four angles.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Quadrilaterals",
            "How many interior angles does every quadrilateral have?",
            "Three",
            "Four",
            "Five",
            "Six",
            QuestionOption.B,
            "Every quadrilateral has four interior angles because it has four sides.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Quadrilaterals",
            "What is the sum of the interior angles of any quadrilateral?",
            "180°",
            "270°",
            "360°",
            "540°",
            QuestionOption.C,
            "The sum of the interior angles of every quadrilateral is always 360°.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Quadrilaterals",
            "Which of the following is NOT a type of quadrilateral?",
            "Rectangle",
            "Rhombus",
            "Pentagon",
            "Trapezium",
            QuestionOption.C,
            "A pentagon has five sides, whereas a quadrilateral has exactly four sides.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Quadrilaterals",
            "Why are quadrilaterals widely used in architecture and engineering?",
            "They can only be drawn using a compass.",
            "They form the basis of many stable structures, floor plans, windows, and mechanical designs.",
            "They always have four equal sides.",
            "They are only used in mathematics textbooks.",
            QuestionOption.B,
            "Quadrilaterals such as rectangles and squares are commonly used in construction, engineering, manufacturing, and design because of their practical shapes and properties.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Types of Quadrilaterals
        // ==========================================================

        AddQuestion(
            "Types of Quadrilaterals",
            "A quadrilateral with four equal sides and four right angles is called what?",
            "Rectangle",
            "Square",
            "Trapezium",
            "Kite",
            QuestionOption.B,
            "A square has four equal sides and four right angles.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Types of Quadrilaterals",
            "Which quadrilateral has both pairs of opposite sides parallel?",
            "Parallelogram",
            "Kite",
            "Trapezium",
            "Pentagon",
            QuestionOption.A,
            "A parallelogram is a quadrilateral with two pairs of opposite sides that are parallel.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Types of Quadrilaterals",
            "Which property is unique to a rectangle?",
            "All sides are always equal.",
            "All angles are 90 degrees.",
            "Only one pair of sides is parallel.",
            "No sides are equal.",
            QuestionOption.B,
            "A rectangle has four right angles, although only opposite sides are equal in length.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Types of Quadrilaterals",
            "A rhombus is a quadrilateral where:",
            "All four sides are equal.",
            "All angles are different.",
            "Only two sides are equal.",
            "No sides are parallel.",
            QuestionOption.A,
            "A rhombus has four equal sides, while its angles do not necessarily have to be right angles.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Types of Quadrilaterals",
            "Why is classifying quadrilaterals important in geometry?",
            "It helps identify properties, solve problems, and understand relationships between shapes.",
            "It only changes the names of shapes.",
            "It removes the need for measurements.",
            "It only applies to drawings.",
            QuestionOption.A,
            "Understanding quadrilateral properties is important in geometry proofs, architecture, engineering, and design.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications of Quadrilaterals
        // ==========================================================

        AddQuestion(
            "Applications of Quadrilaterals",
            "Why are rectangles commonly used in architecture and construction?",
            "They provide practical shapes for rooms, buildings, and structures.",
            "They cannot be measured accurately.",
            "They only exist in drawings.",
            "They have no real-world applications.",
            QuestionOption.A,
            "Rectangles are widely used in construction because they provide efficient layouts and easy measurement.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications of Quadrilaterals",
            "A floor tile has four equal sides and four right angles. Which quadrilateral shape is it?",
            "Square",
            "Trapezium",
            "Kite",
            "Parallelogram",
            QuestionOption.A,
            "A square has four equal sides and four right angles, making it common in tiles and designs.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications of Quadrilaterals",
            "Engineers use parallelograms in designs because:",
            "They help model forces, structures, and balanced shapes.",
            "They cannot represent measurements.",
            "They only work for circular objects.",
            "They have no mathematical properties.",
            QuestionOption.A,
            "Parallelograms are useful in engineering because of their parallel sides and predictable geometric properties.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications of Quadrilaterals",
            "Computer graphics use quadrilateral shapes in modelling. Why are they useful?",
            "They help create surfaces and represent objects efficiently.",
            "They cannot be displayed digitally.",
            "They only represent numbers.",
            "They prevent objects from being scaled.",
            QuestionOption.A,
            "Quadrilaterals are commonly used in graphics, CAD, and 3D modelling to represent surfaces and designs.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications of Quadrilaterals",
            "Why are quadrilateral properties important in advanced fields?",
            "They support accurate design, construction, engineering analysis, and mathematical modelling.",
            "They are only useful for naming shapes.",
            "They cannot be applied outside classrooms.",
            "They replace all other geometric concepts.",
            QuestionOption.A,
            "Quadrilaterals are fundamental in architecture, engineering, computer graphics, and structural design.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Polygons
        // ==========================================================

        AddQuestion(
            "Introduction to Polygons",
            "What is a polygon?",
            "A closed figure made of curved lines",
            "A closed plane figure formed by straight line segments",
            "A three-dimensional shape",
            "A figure with only one side",
            QuestionOption.B,
            "A polygon is a closed two-dimensional figure made up entirely of straight line segments.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Polygons",
            "Which of the following is NOT a polygon?",
            "Triangle",
            "Rectangle",
            "Circle",
            "Pentagon",
            QuestionOption.C,
            "A circle has a curved boundary, while polygons are made only of straight sides.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Polygons",
            "How are polygons commonly classified?",
            "By their colour",
            "By the number of their sides",
            "By their area only",
            "By their perimeter only",
            QuestionOption.B,
            "Polygons are primarily classified according to the number of sides they have, such as triangles, quadrilaterals, pentagons, and hexagons.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Polygons",
            "Which statement about a regular polygon is correct?",
            "Only its sides are equal.",
            "Only its angles are equal.",
            "All its sides and all its interior angles are equal.",
            "It must have exactly six sides.",
            QuestionOption.C,
            "A regular polygon has all sides of equal length and all interior angles equal.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Polygons",
            "Why are polygons important in engineering, architecture, and computer graphics?",
            "They are only used for classroom exercises.",
            "They provide the foundation for designing structures, models, and digital objects.",
            "They can only represent two-dimensional drawings.",
            "They eliminate the need for measurements.",
            QuestionOption.B,
            "Polygons are fundamental in construction, CAD software, computer graphics, and engineering because complex shapes are often built from polygonal components.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Types of Polygons
        // ==========================================================

        AddQuestion(
            "Types of Polygons",
            "A polygon with three sides is called what?",
            "Quadrilateral",
            "Triangle",
            "Pentagon",
            "Hexagon",
            QuestionOption.B,
            "A triangle is a polygon with three sides and three angles.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Types of Polygons",
            "A polygon with all sides and angles equal is called what?",
            "Irregular polygon",
            "Concave polygon",
            "Regular polygon",
            "Open polygon",
            QuestionOption.C,
            "A regular polygon has equal side lengths and equal interior angles.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Types of Polygons",
            "How many sides does a hexagon have?",
            "Five",
            "Six",
            "Seven",
            "Eight",
            QuestionOption.B,
            "A hexagon is a polygon with six sides and six angles.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Types of Polygons",
            "What is the difference between a convex and concave polygon?",
            "A convex polygon has no inward angles, while a concave polygon has at least one inward angle.",
            "A convex polygon has curved sides.",
            "A concave polygon always has equal sides.",
            "They are exactly the same.",
            QuestionOption.A,
            "Convex polygons have all interior angles less than 180°, while concave polygons have at least one interior angle greater than 180°.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Types of Polygons",
            "Why is classifying polygons important in geometry?",
            "It helps identify properties, calculate measurements, and solve geometric problems.",
            "It only changes the names of shapes.",
            "It removes the need for formulas.",
            "It is only useful for drawing.",
            QuestionOption.A,
            "Polygon classification helps understand relationships between shapes and is used in mathematics, design, engineering, and architecture.",
            DifficultyLevel.Advance,
            5);



        // ==========================================================
        // Applications of Polygons
        // ==========================================================

        AddQuestion(
            "Applications of Polygons",
            "Why are polygons commonly used in architecture and construction?",
            "They help design structures, patterns, and stable geometric layouts.",
            "They cannot represent real objects.",
            "They are only used for decoration.",
            "They do not have measurable properties.",
            QuestionOption.A,
            "Polygons are used in architecture to create building designs, floor plans, patterns, and structural layouts.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications of Polygons",
            "Computer graphics use polygons to create 3D models. Why are polygons useful?",
            "They can represent complex surfaces using connected shapes.",
            "They cannot be processed by computers.",
            "They only work for 2D drawings.",
            "They remove the need for calculations.",
            QuestionOption.A,
            "3D graphics use polygon meshes to represent objects efficiently by combining many small polygon surfaces.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications of Polygons",
            "Maps and geographic systems use polygons to represent areas. What can a polygon represent on a map?",
            "Regions, boundaries, and land areas.",
            "Only individual points.",
            "Only straight lines.",
            "Only numerical values.",
            QuestionOption.A,
            "In mapping systems, polygons are used to represent countries, cities, properties, lakes, and other defined regions.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications of Polygons",
            "Why are regular polygons useful in design and engineering?",
            "Their equal sides and angles create balanced and predictable patterns.",
            "They cannot be measured.",
            "They always have curved edges.",
            "They cannot form structures.",
            QuestionOption.A,
            "Regular polygons provide symmetry and consistency, making them useful in engineering, design, and manufacturing.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications of Polygons",
            "Why are polygons important in advanced mathematics and technology?",
            "They help model shapes, analyze structures, create graphics, and solve geometric problems.",
            "They are only used in basic drawings.",
            "They have no connection to technology.",
            "They cannot be used for measurements.",
            QuestionOption.A,
            "Polygons are fundamental in computer graphics, architecture, engineering, robotics, and mathematical modelling.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Introduction to Circles
        // ==========================================================

        AddQuestion(
            "Introduction to Circles",
            "What is a circle?",
            "A polygon with four sides",
            "A closed two-dimensional shape where all points are the same distance from the center",
            "A three-dimensional solid shape",
            "A shape made only of straight lines",
            QuestionOption.B,
            "A circle is a closed two-dimensional figure where every point on its boundary is at an equal distance from the center.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Circles",
            "What is the fixed point inside a circle called?",
            "Radius",
            "Diameter",
            "Center",
            "Chord",
            QuestionOption.C,
            "The center is the fixed point from which all points on the circle are equally distant.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Circles",
            "What is the distance from the center of a circle to any point on its boundary called?",
            "Diameter",
            "Radius",
            "Circumference",
            "Arc",
            QuestionOption.B,
            "The radius is the distance between the center of a circle and any point on its circumference.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Circles",
            "Which part of a circle passes through the center and connects two points on the circle?",
            "Chord",
            "Arc",
            "Diameter",
            "Sector",
            QuestionOption.C,
            "A diameter is a line segment that passes through the center and connects two points on the circle. It is twice the length of the radius.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Circles",
            "Why are circles important in real-world applications?",
            "They are only used in mathematics textbooks.",
            "They are used in wheels, machines, architecture, engineering, and design.",
            "They cannot represent real objects.",
            "They only help calculate angles.",
            QuestionOption.B,
            "Circles are widely used in engineering, transportation, mechanical systems, architecture, and many everyday objects because of their symmetry and properties.",
            DifficultyLevel.Advance,
            5);



        // ==========================================================
        // Parts and Properties of Circles
        // ==========================================================

        AddQuestion(
            "Parts and Properties of Circles",
            "What is the fixed point at the center of a circle called?",
            "Radius",
            "Center",
            "Chord",
            "Arc",
            QuestionOption.B,
            "The center is the fixed point from which all points on the circle are at the same distance.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Parts and Properties of Circles",
            "What is the distance from the center of a circle to any point on its circumference called?",
            "Diameter",
            "Radius",
            "Tangent",
            "Sector",
            QuestionOption.B,
            "The radius is the distance from the center to any point on the circle, and the diameter is twice the radius.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Parts and Properties of Circles",
            "A line segment that passes through the center of a circle and connects two points on the circumference is called:",
            "Chord",
            "Arc",
            "Diameter",
            "Secant",
            QuestionOption.C,
            "A diameter is the longest chord of a circle and passes through the center.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Parts and Properties of Circles",
            "What is a line that touches a circle at exactly one point called?",
            "Secant",
            "Chord",
            "Tangent",
            "Radius",
            QuestionOption.C,
            "A tangent touches the circle at one point, called the point of contact.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Parts and Properties of Circles",
            "Why are understanding the parts and properties of circles important?",
            "They help solve geometric problems involving measurements, angles, and circular structures.",
            "They are only useful for drawing circles.",
            "They cannot be applied outside mathematics.",
            "They replace all geometry concepts.",
            QuestionOption.A,
            "Circle properties are used in engineering, architecture, physics, design, and many real-world applications involving circular objects.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications of Circles
        // ==========================================================

        AddQuestion(
            "Applications of Circles",
            "Why are circles commonly used in wheels and gears?",
            "They provide smooth rotation around a fixed center.",
            "They cannot be measured accurately.",
            "They only work in drawings.",
            "They prevent movement.",
            QuestionOption.A,
            "Circles are ideal for rotational motion because every point on the edge is equally distant from the center.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications of Circles",
            "Astronomers use circular paths to describe the motion of planets. Which circle property is useful?",
            "Distance from the center remains constant.",
            "All circles have different centers.",
            "Circles have no measurements.",
            "Circles cannot represent movement.",
            QuestionOption.A,
            "Circular motion is based on the constant distance between an object and the center of rotation.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications of Circles",
            "Engineers use circles in mechanical designs. Why are circular shapes useful?",
            "They allow efficient rotation and balanced distribution of forces.",
            "They cannot be calculated.",
            "They only represent flat objects.",
            "They have no practical purpose.",
            QuestionOption.A,
            "Circular components such as wheels, bearings, and gears rely on circle properties for efficient operation.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications of Circles",
            "A satellite dish uses a circular shape. Which property helps it work effectively?",
            "The circular design helps collect and focus signals symmetrically.",
            "It prevents all signals from reaching the dish.",
            "It removes the need for technology.",
            "It only works for decoration.",
            QuestionOption.A,
            "Circular shapes are used in antennas and dishes because of their symmetry and reflective properties.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications of Circles",
            "Why are circles important in advanced mathematics and technology?",
            "They are used in engineering, physics, astronomy, graphics, and many mathematical models.",
            "They are only used for classroom drawings.",
            "They cannot represent real-world objects.",
            "They are unrelated to measurements.",
            QuestionOption.A,
            "Circle concepts are fundamental in fields such as robotics, transportation, astronomy, mechanical design, and computer graphics.",
            DifficultyLevel.Advance,
            5);



        // ==========================================================
        // Introduction to Geometric Constructions
        // ==========================================================

        AddQuestion(
            "Introduction to Geometric Constructions",
            "What are geometric constructions?",
            "Drawing random shapes without measurements",
            "Creating accurate geometric figures using specific tools and methods",
            "Calculating only the area of shapes",
            "Measuring temperature using instruments",
            QuestionOption.B,
            "Geometric constructions involve creating accurate geometric figures using tools such as a compass and straightedge following specific rules.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Geometric Constructions",
            "Which two tools are traditionally used for geometric constructions?",
            "Calculator and ruler",
            "Compass and straightedge",
            "Protractor and calculator",
            "Pencil and eraser only",
            QuestionOption.B,
            "A compass and straightedge are the traditional tools used to create precise geometric constructions.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Geometric Constructions",
            "What is the main purpose of using a compass in geometric constructions?",
            "To measure angles directly",
            "To draw circles and arcs with a fixed radius",
            "To calculate areas",
            "To create curved equations",
            QuestionOption.B,
            "A compass is used to draw circles and arcs while maintaining a fixed distance from a point.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Geometric Constructions",
            "Which of the following can be constructed using geometric methods?",
            "A perfectly measured angle bisector",
            "A random freehand drawing",
            "A photograph",
            "A digital animation only",
            QuestionOption.A,
            "Geometric construction methods can accurately create objects such as angle bisectors, perpendicular lines, and triangles.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Geometric Constructions",
            "Why are geometric constructions important in real-world fields?",
            "They remove the need for precision.",
            "They help create accurate designs in architecture, engineering, and technical drawings.",
            "They are only useful for solving puzzles.",
            "They are only used to draw circles.",
            QuestionOption.B,
            "Geometric constructions provide accuracy and precision, making them useful in architecture, engineering, design, and manufacturing.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Common Geometric Constructions
        // ==========================================================

        AddQuestion(
            "Common Geometric Constructions",
            "Which two tools are traditionally used for geometric constructions?",
            "Ruler and calculator",
            "Compass and straightedge",
            "Protractor and calculator",
            "Computer and printer",
            QuestionOption.B,
            "Classical geometric constructions are performed using a compass and straightedge.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Common Geometric Constructions",
            "What is the purpose of constructing an angle bisector?",
            "To divide an angle into two equal parts.",
            "To increase the size of an angle.",
            "To remove an angle.",
            "To create a circle.",
            QuestionOption.A,
            "An angle bisector divides an angle into two congruent angles.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Common Geometric Constructions",
            "What does a perpendicular line form when it intersects another line?",
            "A 90° angle",
            "A 180° angle",
            "A curved shape",
            "An unequal angle only",
            QuestionOption.A,
            "Perpendicular lines intersect at a right angle of 90°.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Common Geometric Constructions",
            "Why is a compass used in geometric constructions?",
            "To draw arcs and create equal distances from points.",
            "To measure temperature.",
            "To calculate equations automatically.",
            "To draw only straight lines.",
            QuestionOption.A,
            "A compass helps construct circles, arcs, and equal-length segments accurately.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Common Geometric Constructions",
            "Why are geometric constructions important in mathematics and engineering?",
            "They provide accurate methods for creating and analyzing geometric figures.",
            "They only apply to simple drawings.",
            "They cannot be used for real designs.",
            "They replace all mathematical formulas.",
            QuestionOption.A,
            "Geometric constructions are used in design, architecture, engineering, and mathematical proofs.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications of Geometric Constructions
        // ==========================================================

        AddQuestion(
            "Applications of Geometric Constructions",
            "Why are geometric constructions useful in architecture?",
            "They help create accurate designs, layouts, and structural plans.",
            "They remove the need for measurements.",
            "They only work for drawings.",
            "They cannot represent buildings.",
            QuestionOption.A,
            "Architects use geometric constructions to create precise designs, floor plans, and structural models.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications of Geometric Constructions",
            "Surveyors use geometric constructions to determine locations and distances. Which concept is commonly applied?",
            "Accurate geometric measurement and construction",
            "Polynomial expansion",
            "Probability calculation",
            "Number classification",
            QuestionOption.A,
            "Surveying uses geometric methods to measure land, establish boundaries, and determine positions accurately.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications of Geometric Constructions",
            "Technical drawings use geometric constructions because they:",
            "Allow precise representation of objects and components.",
            "Prevent accurate measurements.",
            "Only create artistic sketches.",
            "Remove the need for geometry.",
            QuestionOption.A,
            "Engineering and technical drawings require precise geometric constructions to represent real objects correctly.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications of Geometric Constructions",
            "Computer-aided design (CAD) software uses geometric constructions to:",
            "Create accurate digital models and engineering designs.",
            "Avoid using mathematical principles.",
            "Only draw random shapes.",
            "Replace all engineering calculations.",
            QuestionOption.A,
            "CAD systems rely on geometric principles to create precise models used in engineering, manufacturing, and design.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications of Geometric Constructions",
            "Why are geometric constructions important in advanced fields?",
            "They provide accurate methods for designing, modelling, analysing, and solving geometric problems.",
            "They are only useful in school exercises.",
            "They cannot be applied in technology.",
            "They only involve simple drawings.",
            QuestionOption.A,
            "Geometric constructions are fundamental in architecture, engineering, robotics, surveying, and computer modelling.",
            DifficultyLevel.Advance,
            5);











        // ==========================================================
        // Introduction to Area
        // ==========================================================

        AddQuestion(
            "Introduction to Area",
            "What does area measure in geometry?",
            "The distance around a shape",
            "The space enclosed inside a two-dimensional shape",
            "The number of sides of a shape",
            "The angle between two lines",
            QuestionOption.B,
            "Area measures the amount of space covered or enclosed by a two-dimensional shape.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Area",
            "What is the standard unit used to measure area?",
            "Metres (m)",
            "Square metres (m²)",
            "Cubic metres (m³)",
            "Degrees (°)",
            QuestionOption.B,
            "Area is measured in square units such as square metres (m²), square centimetres (cm²), and square kilometres (km²).",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Area",
            "Which formula is used to calculate the area of a rectangle?",
            "Length + Width",
            "2 × (Length + Width)",
            "Length × Width",
            "Length ÷ Width",
            QuestionOption.C,
            "The area of a rectangle is calculated by multiplying its length by its width.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Area",
            "If a square has a side length of 5 cm, what is its area?",
            "10 cm²",
            "20 cm²",
            "25 cm²",
            "30 cm²",
            QuestionOption.C,
            "The area of a square is side × side. Therefore, 5 × 5 = 25 cm².",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Area",
            "Why is understanding area important in real-world applications?",
            "It helps measure spaces needed for construction, design, and planning.",
            "It only helps draw geometric shapes.",
            "It replaces all other mathematical measurements.",
            "It is only used in classroom exercises.",
            QuestionOption.A,
            "Area calculations are used in architecture, engineering, construction, land measurement, interior design, and many practical situations.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Area of Common Shapes
        // ==========================================================

        AddQuestion(
            "Area of Common Shapes",
            "What does the area of a shape represent?",
            "The amount of space enclosed inside the shape.",
            "The distance around the shape.",
            "The number of sides of the shape.",
            "The angles of the shape only.",
            QuestionOption.A,
            "Area measures the amount of surface enclosed within a two-dimensional shape.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Area of Common Shapes",
            "What is the formula for finding the area of a rectangle?",
            "Length × Width",
            "2 × (Length + Width)",
            "Side × Side × Side",
            "Base + Height",
            QuestionOption.A,
            "The area of a rectangle is calculated by multiplying its length by its width.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Area of Common Shapes",
            "Which formula is used to calculate the area of a triangle?",
            "Base × Height",
            "(1/2) × Base × Height",
            "Side × Side",
            "π × Radius",
            QuestionOption.B,
            "The area of a triangle is half the product of its base and perpendicular height.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Area of Common Shapes",
            "The area of a circle depends on which measurements?",
            "Radius",
            "Diameter only",
            "Number of sides",
            "Perimeter only",
            QuestionOption.A,
            "The area of a circle is calculated using π multiplied by the square of its radius.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Area of Common Shapes",
            "Why is calculating the area of different shapes important?",
            "It helps solve problems in construction, design, engineering, and real-world measurements.",
            "It is only used for naming shapes.",
            "It removes the need for geometry.",
            "It only applies to drawings.",
            QuestionOption.A,
            "Area calculations are essential in architecture, construction, land measurement, manufacturing, and many practical applications.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Applications of Area
        // ==========================================================

        AddQuestion(
            "Applications of Area",
            "Why is calculating area important in construction?",
            "It helps determine the amount of materials needed for surfaces and structures.",
            "It removes the need for measurements.",
            "It only helps name shapes.",
            "It cannot be applied to buildings.",
            QuestionOption.A,
            "Builders use area calculations to estimate materials such as flooring, paint, tiles, and land coverage.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications of Area",
            "Farmers use area calculations mainly to determine:",
            "The size of farmland and required resources.",
            "The number of angles in a field.",
            "The color of crops.",
            "The shape of clouds.",
            QuestionOption.A,
            "Area helps farmers measure land size, plan cultivation, and estimate resource requirements.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications of Area",
            "Architects calculate the area of rooms and surfaces to:",
            "Design spaces and estimate material requirements accurately.",
            "Avoid using measurements.",
            "Remove geometric calculations.",
            "Only create drawings.",
            QuestionOption.A,
            "Area calculations help architects plan floor spaces, wall surfaces, and building layouts.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications of Area",
            "Computer graphics use area calculations for:",
            "Rendering surfaces, textures, and visual elements.",
            "Removing all geometry from graphics.",
            "Only creating text.",
            "Avoiding measurements.",
            QuestionOption.A,
            "Graphics systems use geometric area calculations when displaying and processing digital objects.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications of Area",
            "Why is understanding area important in advanced fields?",
            "It helps solve real-world problems involving space, resources, design, and measurement.",
            "It only applies to basic geometry lessons.",
            "It cannot be used outside mathematics.",
            "It replaces all other calculations.",
            QuestionOption.A,
            "Area concepts are fundamental in engineering, architecture, science, geography, agriculture, and technology.",
            DifficultyLevel.Advance,
            5);



        // ==========================================================
        // Introduction to Perimeter
        // ==========================================================

        AddQuestion(
            "Introduction to Perimeter",
            "What does perimeter measure in geometry?",
            "The space inside a shape",
            "The total distance around the boundary of a shape",
            "The number of angles in a shape",
            "The height of a shape",
            QuestionOption.B,
            "Perimeter measures the total distance around the outside boundary of a two-dimensional shape.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Perimeter",
            "What unit is commonly used to measure perimeter?",
            "Square units",
            "Cubic units",
            "Linear units",
            "Degrees",
            QuestionOption.C,
            "Perimeter is a length measurement, so it is measured using linear units such as metres (m) or centimetres (cm).",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Perimeter",
            "How do you find the perimeter of a rectangle?",
            "Length × Width",
            "Add all four sides together",
            "Length ÷ Width",
            "Side × Side",
            QuestionOption.B,
            "The perimeter of a rectangle is found by adding the lengths of all four sides, or using 2 × (length + width).",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Perimeter",
            "A square has sides of length 6 cm. What is its perimeter?",
            "12 cm",
            "18 cm",
            "24 cm",
            "36 cm",
            QuestionOption.C,
            "A square has four equal sides, so the perimeter is 4 × 6 = 24 cm.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Perimeter",
            "Why is understanding perimeter useful in real-world applications?",
            "It helps calculate boundaries for fencing, construction, and design.",
            "It is only used to find the area of shapes.",
            "It removes the need for measurements.",
            "It is only useful for circles.",
            QuestionOption.A,
            "Perimeter is used in practical situations such as finding the amount of fencing needed, measuring borders, and planning construction layouts.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Calculating the Perimeter of Shapes
        // ==========================================================

        AddQuestion(
            "Calculating the Perimeter of Shapes",
            "What does the perimeter of a shape represent?",
            "The total distance around the boundary of the shape.",
            "The space inside the shape.",
            "The number of angles in the shape.",
            "The size of the shape's area.",
            QuestionOption.A,
            "Perimeter measures the complete distance around the outside edge of a two-dimensional shape.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Calculating the Perimeter of Shapes",
            "How is the perimeter of a rectangle calculated?",
            "Length × Width",
            "2 × (Length + Width)",
            "Base × Height",
            "π × Radius²",
            QuestionOption.B,
            "A rectangle has two equal lengths and two equal widths, so its perimeter is 2 × (Length + Width).",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Calculating the Perimeter of Shapes",
            "What is the perimeter formula for a square?",
            "4 × Side length",
            "Side length²",
            "2 × Side length",
            "Length × Width",
            QuestionOption.A,
            "A square has four equal sides, so its perimeter is four times the length of one side.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Calculating the Perimeter of Shapes",
            "How is the perimeter of a circle calculated?",
            "π × Radius²",
            "2 × π × Radius",
            "Length × Width",
            "Base × Height",
            QuestionOption.B,
            "The perimeter of a circle is called circumference and is calculated using 2πr.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Calculating the Perimeter of Shapes",
            "Why is calculating perimeter important in real-world applications?",
            "It helps measure boundaries, fencing, borders, construction materials, and object dimensions.",
            "It only helps identify shapes.",
            "It removes the need for measurements.",
            "It is only useful for drawings.",
            QuestionOption.A,
            "Perimeter calculations are used in construction, land measurement, design, manufacturing, and everyday planning.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Applications of Perimeter
        // ==========================================================

        AddQuestion(
            "Applications of Perimeter",
            "Why is perimeter used when building a fence around a property?",
            "It helps determine the total length of fencing material needed.",
            "It calculates the area inside the property.",
            "It determines the height of the fence only.",
            "It removes the need for measurements.",
            QuestionOption.A,
            "Perimeter measures the boundary length, which helps calculate how much fencing material is required.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications of Perimeter",
            "Landscapers use perimeter calculations to:",
            "Measure boundaries of gardens, parks, and outdoor spaces.",
            "Calculate the weight of plants.",
            "Determine the colour of landscapes.",
            "Replace all design planning.",
            QuestionOption.A,
            "Perimeter helps landscapers plan borders, pathways, fences, and decorative boundaries.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications of Perimeter",
            "Architects and engineers calculate perimeter mainly to:",
            "Design boundaries and estimate materials needed for structures.",
            "Avoid using geometric measurements.",
            "Only create drawings.",
            "Calculate only the volume of objects.",
            QuestionOption.A,
            "Perimeter calculations help estimate materials for frames, borders, walls, and structural components.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications of Perimeter",
            "A manufacturer creates a frame around a rectangular product. Which measurement is needed?",
            "Perimeter of the rectangle.",
            "Area of the rectangle only.",
            "Number of angles only.",
            "Diagonal length only.",
            QuestionOption.A,
            "The perimeter gives the total length of material required to create a border or frame.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications of Perimeter",
            "Why is understanding perimeter important in advanced fields?",
            "It helps solve real-world problems involving boundaries, construction, design, and measurement.",
            "It is only useful for simple classroom exercises.",
            "It has no connection with engineering.",
            "It cannot be applied to real objects.",
            QuestionOption.A,
            "Perimeter is widely used in architecture, engineering, geography, manufacturing, and everyday planning.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Introduction to Transformations
        // ==========================================================

        AddQuestion(
            "Introduction to Transformations",
            "What are geometric transformations?",
            "Methods used to calculate the area of shapes",
            "Operations that move, flip, turn, or resize geometric figures",
            "Ways to measure angles only",
            "Techniques used to draw circles",
            QuestionOption.B,
            "Geometric transformations are operations that change the position, orientation, or size of a figure while maintaining its geometric properties.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Transformations",
            "Which transformation moves a shape from one location to another without changing its size or orientation?",
            "Rotation",
            "Reflection",
            "Translation",
            "Dilation",
            QuestionOption.C,
            "A translation slides a figure from one position to another while keeping the same shape, size, and orientation.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Transformations",
            "What happens to a figure during a reflection?",
            "It becomes larger",
            "It flips over a line to create a mirror image",
            "It changes into a different shape",
            "It loses all measurements",
            QuestionOption.B,
            "A reflection creates a mirror image of a figure across a line called the line of reflection.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Transformations",
            "Which transformation changes the size of a figure while keeping the same shape?",
            "Rotation",
            "Translation",
            "Reflection",
            "Dilation",
            QuestionOption.D,
            "A dilation enlarges or reduces a figure by a scale factor while preserving its shape.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Transformations",
            "Why are geometric transformations important in real-world applications?",
            "They are only used for solving textbook problems.",
            "They are used in computer graphics, animation, engineering, robotics, and design.",
            "They eliminate the need for measurements.",
            "They only apply to triangles.",
            QuestionOption.B,
            "Transformations are widely used in digital graphics, games, animation, architecture, robotics, and engineering to manipulate objects accurately.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Types of Transformations
        // ==========================================================

        AddQuestion(
            "Types of Transformations",
            "Which transformation moves a figure from one position to another without changing its size or shape?",
            "Translation",
            "Reflection",
            "Rotation",
            "Dilation",
            QuestionOption.A,
            "A translation slides a figure to a new position while preserving its size, shape, and orientation.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Types of Transformations",
            "Which transformation creates a mirror image of a figure across a line?",
            "Rotation",
            "Reflection",
            "Translation",
            "Dilation",
            QuestionOption.B,
            "Reflection flips a figure over a line called the line of reflection, creating a mirror image.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Types of Transformations",
            "Which transformation turns a figure around a fixed point?",
            "Translation",
            "Dilation",
            "Rotation",
            "Reflection",
            QuestionOption.C,
            "Rotation turns a figure around a fixed point by a specific angle and direction.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Types of Transformations",
            "What happens to a figure during dilation?",
            "Its size changes while its shape remains the same.",
            "Its shape changes completely.",
            "It moves without changing position.",
            "It disappears from the plane.",
            QuestionOption.A,
            "Dilation enlarges or reduces a figure using a scale factor while preserving its shape.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Types of Transformations",
            "Why are geometric transformations important in mathematics and technology?",
            "They help describe movements, designs, graphics, and changes in geometric figures.",
            "They are only used for naming shapes.",
            "They cannot be applied outside geometry.",
            "They remove the need for measurements.",
            QuestionOption.A,
            "Transformations are used in computer graphics, engineering, animation, architecture, and mathematical modelling.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications of Transformations
        // ==========================================================

        AddQuestion(
            "Applications of Transformations",
            "Why are transformations used in computer graphics?",
            "They help move, rotate, resize, and modify digital objects.",
            "They prevent objects from being displayed.",
            "They remove the need for calculations.",
            "They only work with physical objects.",
            QuestionOption.A,
            "Computer graphics use transformations to position, scale, and animate objects in digital environments.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications of Transformations",
            "Animation software uses transformations to create movement. Which transformation helps rotate an object?",
            "Rotation",
            "Translation",
            "Reflection",
            "Dilation",
            QuestionOption.A,
            "Rotation transformations allow objects to turn around a fixed point, which is essential in animation.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications of Transformations",
            "Robotics uses transformations mainly to:",
            "Control positions, movements, and orientations of robotic parts.",
            "Remove all movement from robots.",
            "Avoid using geometry.",
            "Only create drawings.",
            QuestionOption.A,
            "Robotics relies on transformations to calculate how objects move and change position in space.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications of Transformations",
            "Image processing uses transformations to:",
            "Resize, rotate, adjust, and analyze digital images.",
            "Delete all image information.",
            "Prevent image modification.",
            "Only store text data.",
            QuestionOption.A,
            "Transformations are used in image editing, computer vision, and digital graphics processing.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications of Transformations",
            "Why are transformations important in advanced fields such as engineering and game development?",
            "They help model motion, create simulations, and represent changes in objects accurately.",
            "They only apply to simple classroom drawings.",
            "They cannot be used with technology.",
            "They replace all mathematical concepts.",
            QuestionOption.A,
            "Transformations are fundamental in CAD systems, simulations, robotics, games, animation, and 3D modelling.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Introduction to Coordinate Proofs
        // ==========================================================

        AddQuestion(
            "Introduction to Coordinate Proofs",
            "What is a coordinate proof?",
            "A proof that uses only geometric drawings",
            "A method of proving geometric statements using coordinates and algebra",
            "A way to calculate only the area of shapes",
            "A technique used only for measuring angles",
            QuestionOption.B,
            "Coordinate proofs use points on a coordinate plane and algebraic methods to prove geometric properties.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Coordinate Proofs",
            "Which mathematical system is mainly used in coordinate proofs?",
            "Number line only",
            "Coordinate plane with x and y axes",
            "Clock system",
            "Three-dimensional model only",
            QuestionOption.B,
            "Coordinate proofs use the coordinate plane, which consists of horizontal x-axis and vertical y-axis, to represent geometric figures.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Coordinate Proofs",
            "Which formula can be used to find the distance between two points in a coordinate plane?",
            "Area formula",
            "Distance formula",
            "Quadratic formula",
            "Slope formula only",
            QuestionOption.B,
            "The distance formula calculates the length between two points using their coordinates.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Coordinate Proofs",
            "How can the slope of a line help in coordinate proofs?",
            "It can determine relationships such as parallel or perpendicular lines.",
            "It calculates the area of every shape.",
            "It changes a shape into a circle.",
            "It removes the need for coordinates.",
            QuestionOption.A,
            "Slope helps prove geometric relationships by showing whether lines are parallel, perpendicular, or have the same direction.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Coordinate Proofs",
            "Why are coordinate proofs useful in mathematics and real-world fields?",
            "They combine algebra and geometry to verify designs and relationships accurately.",
            "They are only used for drawing pictures.",
            "They replace all mathematical formulas.",
            "They only work with circles.",
            QuestionOption.A,
            "Coordinate proofs connect algebra with geometry and are useful in engineering, computer graphics, architecture, and analytical problem-solving.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Methods of Coordinate Proofs
        // ==========================================================

        AddQuestion(
            "Methods of Coordinate Proofs",
            "What is the main purpose of a coordinate proof?",
            "To use algebra and coordinates to prove geometric relationships.",
            "To draw shapes without measurements.",
            "To avoid using mathematical reasoning.",
            "To only calculate areas.",
            QuestionOption.A,
            "Coordinate proofs combine geometry and algebra by representing figures on a coordinate plane and verifying properties mathematically.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Methods of Coordinate Proofs",
            "Which formula is used to find the distance between two points on a coordinate plane?",
            "Midpoint formula",
            "Distance formula",
            "Slope formula",
            "Area formula",
            QuestionOption.B,
            "The distance formula calculates the length between two points using their coordinates.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Methods of Coordinate Proofs",
            "What does the midpoint formula help determine?",
            "The exact center point between two coordinates.",
            "The angle between two lines.",
            "The area of a circle.",
            "The length of a triangle only.",
            QuestionOption.A,
            "The midpoint formula finds the point exactly halfway between two endpoints.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Methods of Coordinate Proofs",
            "How is slope useful in coordinate proofs?",
            "It helps determine the relationship between lines, such as parallel or perpendicular.",
            "It calculates the area of any shape directly.",
            "It replaces all geometric concepts.",
            "It only measures distances.",
            QuestionOption.A,
            "Slope is used to compare line directions and prove relationships between geometric figures.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Methods of Coordinate Proofs",
            "Why are coordinate proof methods important in advanced mathematics?",
            "They provide systematic ways to verify geometric properties using algebraic reasoning.",
            "They only apply to simple drawings.",
            "They cannot be used in technology.",
            "They remove the need for mathematical proofs.",
            QuestionOption.A,
            "Coordinate proofs are used in geometry, engineering, computer graphics, and analytical mathematics.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Applications of Coordinate Proofs
        // ==========================================================

        AddQuestion(
            "Applications of Coordinate Proofs",
            "Why are coordinate proofs useful in engineering?",
            "They help verify designs, measurements, and geometric relationships accurately.",
            "They remove the need for calculations.",
            "They only create artistic drawings.",
            "They cannot represent real structures.",
            QuestionOption.A,
            "Engineers use coordinate methods to analyze structures, positions, and geometric properties of designs.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications of Coordinate Proofs",
            "Architects use coordinate proofs mainly to:",
            "Analyze layouts, positions, and relationships between design elements.",
            "Avoid using measurements.",
            "Replace all building materials.",
            "Only decorate drawings.",
            QuestionOption.A,
            "Coordinate systems help architects create accurate plans and verify geometric arrangements.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications of Coordinate Proofs",
            "Computer graphics use coordinate geometry to:",
            "Represent and manipulate objects using points and geometric relationships.",
            "Prevent objects from being displayed.",
            "Remove all mathematical calculations.",
            "Only create text elements.",
            QuestionOption.A,
            "Graphics systems use coordinates to position, transform, and model digital objects.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications of Coordinate Proofs",
            "Surveyors use coordinate methods to:",
            "Determine accurate locations, distances, and boundaries of land.",
            "Calculate only object colours.",
            "Avoid measuring locations.",
            "Replace maps completely.",
            QuestionOption.A,
            "Surveying relies on coordinate systems to record positions and measure real-world locations.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications of Coordinate Proofs",
            "Why are coordinate proofs important in advanced fields?",
            "They connect algebra and geometry to solve complex design, modelling, and analysis problems.",
            "They are only useful for basic geometry exercises.",
            "They cannot be applied in technology.",
            "They replace all mathematical concepts.",
            QuestionOption.A,
            "Coordinate proofs are fundamental in engineering, robotics, CAD, computer graphics, and analytical mathematics.",
            DifficultyLevel.Advance,
            5);

        // PQ. 3
        // Introduction to Cartesian Plane

        AddQuestion(
            "Introduction to Cartesian Plane",
            "What are the two main axes used in a Cartesian plane?",
            "The x-axis and y-axis",
            "The horizontal axis and diagonal axis",
            "The radius and diameter",
            "The length and width",
            QuestionOption.A,
            "A Cartesian plane is formed by two perpendicular axes: the x-axis and y-axis.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Cartesian Plane",
            "What is the coordinate of the origin in a Cartesian plane?",
            "(0,0)",
            "(1,1)",
            "(-1,-1)",
            "(0,1)",
            QuestionOption.A,
            "The origin is the point where the x-axis and y-axis intersect, represented as (0,0).",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Cartesian Plane",
            "How many quadrants are formed by the x-axis and y-axis?",
            "Four quadrants",
            "Two quadrants",
            "Three quadrants",
            "Five quadrants",
            QuestionOption.A,
            "The two perpendicular axes divide the Cartesian plane into four quadrants.",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Cartesian Plane",
            "In which quadrant does the point (4,5) lie?",
            "First quadrant",
            "Second quadrant",
            "Third quadrant",
            "Fourth quadrant",
            QuestionOption.A,
            "Points with positive x and positive y coordinates lie in the first quadrant.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Cartesian Plane",
            "A point has coordinates (-3,6). Which quadrant does it belong to?",
            "Second quadrant",
            "First quadrant",
            "Third quadrant",
            "Fourth quadrant",
            QuestionOption.A,
            "A negative x-coordinate and positive y-coordinate place the point in the second quadrant.",
            DifficultyLevel.Intermediate,
            5);
        // Understanding Coordinates and Quadrants

        AddQuestion(
            "Understanding Coordinates and Quadrants",
            "What does an ordered pair (x, y) represent in a Cartesian plane?",
            "The position of a point using its x-coordinate and y-coordinate",
            "The distance between two points",
            "The angle between two lines",
            "The size of a geometric shape",
            QuestionOption.A,
            "An ordered pair represents the location of a point where x shows horizontal position and y shows vertical position.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Understanding Coordinates and Quadrants",
            "In which quadrant does the point (-5, 3) lie?",
            "Second quadrant",
            "First quadrant",
            "Third quadrant",
            "Fourth quadrant",
            QuestionOption.A,
            "A point with a negative x-coordinate and positive y-coordinate lies in the second quadrant.",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Understanding Coordinates and Quadrants",
            "Which coordinate remains zero for a point located on the y-axis?",
            "The x-coordinate",
            "The y-coordinate",
            "Both coordinates",
            "Neither coordinate",
            QuestionOption.A,
            "Any point on the y-axis has an x-coordinate of zero.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Understanding Coordinates and Quadrants",
            "A point has coordinates (−4, −7). Which quadrant does it belong to?",
            "Third quadrant",
            "First quadrant",
            "Second quadrant",
            "Fourth quadrant",
            QuestionOption.A,
            "Points with both negative x and negative y coordinates are located in the third quadrant.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Understanding Coordinates and Quadrants",
            "Which point lies in the fourth quadrant?",
            "(3, -6)",
            "(-3, 6)",
            "(-5, -2)",
            "(4, 7)",
            QuestionOption.A,
            "The fourth quadrant contains points with positive x-coordinates and negative y-coordinates.",
            DifficultyLevel.Intermediate,
            5);
        // Applications and Practice of Cartesian Plane

        AddQuestion(
            "Applications and Practice of Cartesian Plane",
            "Why is the Cartesian plane useful in real-world applications?",
            "It helps represent locations, movements, and relationships using coordinates.",
            "It is only used for basic arithmetic calculations.",
            "It removes the need for measurements.",
            "It can only represent circles.",
            QuestionOption.A,
            "The Cartesian plane is widely used in maps, engineering, computer graphics, and data analysis to represent positions and relationships.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Cartesian Plane",
            "A drone moves from point (2,3) to point (7,3). In which direction does it move?",
            "Horizontally to the right",
            "Vertically upward",
            "Diagonally downward",
            "Vertically downward",
            QuestionOption.A,
            "The y-coordinate remains the same while the x-coordinate increases, showing horizontal movement to the right.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Cartesian Plane",
            "A city map uses coordinates to mark locations. What mathematical concept is being applied?",
            "Coordinate geometry",
            "Algebraic factorization",
            "Trigonometric identities",
            "Probability theory",
            QuestionOption.A,
            "Coordinate geometry uses points and coordinates to represent locations and solve spatial problems.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Cartesian Plane",
            "A point moves from (−2,4) to (−2,−5). What type of movement occurs?",
            "Vertical movement downward",
            "Horizontal movement right",
            "Horizontal movement left",
            "No movement",
            QuestionOption.A,
            "The x-coordinate remains constant while the y-coordinate decreases, indicating downward vertical movement.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Cartesian Plane",
            "How are Cartesian coordinates used in computer graphics?",
            "They help position and transform objects on a screen.",
            "They are only used to calculate probabilities.",
            "They replace programming languages.",
            "They are used only for measuring angles.",
            QuestionOption.A,
            "Computer graphics rely on coordinate systems to place, move, rotate, and scale objects digitally.",
            DifficultyLevel.Advance,
            5);

        // Introduction to Distance Formula

        AddQuestion(
            "Introduction to Distance Formula",
            "What is the distance formula used to find?",
            "The distance between two points on a coordinate plane",
            "The midpoint of a line segment",
            "The slope of a line",
            "The area of a triangle",
            QuestionOption.A,
            "The distance formula calculates the length of the line segment joining two points in a coordinate plane.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Distance Formula",
            "Which theorem is used to derive the distance formula?",
            "Pythagorean theorem",
            "Angle sum theorem",
            "Similarity theorem",
            "Binomial theorem",
            QuestionOption.A,
            "The distance formula is derived by applying the Pythagorean theorem to the horizontal and vertical differences between two points.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Distance Formula",
            "What are the coordinates of two points generally represented as in the distance formula?",
            "(x₁, y₁) and (x₂, y₂)",
            "(a, b) and (c, d)",
            "(x, y) and (r, θ)",
            "(l, w) and (h, k)",
            QuestionOption.A,
            "The distance formula uses two points represented as (x₁, y₁) and (x₂, y₂).",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Distance Formula",
            "If two points have the same x-coordinate, what type of line segment connects them?",
            "Vertical line segment",
            "Horizontal line segment",
            "Curved line segment",
            "No line segment",
            QuestionOption.A,
            "When x-coordinates are equal, the points lie on the same vertical line.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Distance Formula",
            "Why is the distance formula important in coordinate geometry?",
            "It helps measure lengths between points using coordinates",
            "It calculates only angles between lines",
            "It replaces all geometric formulas",
            "It is only used for circles",
            QuestionOption.A,
            "The distance formula connects algebra and geometry by allowing lengths to be calculated from coordinate values.",
            DifficultyLevel.Begineer,
            5);

        // Solving Problems Using Distance Formula

        AddQuestion(
            "Solving Problems Using Distance Formula",
            "Find the distance between the points (0,0) and (3,4).",
            "5 units",
            "6 units",
            "7 units",
            "4 units",
                        QuestionOption.A,
            "Using the distance formula: √((3-0)² + (4-0)²) = √(9+16) = √25 = 5 units.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Solving Problems Using Distance Formula",
            "What is the distance between the points (2,3) and (6,6)?",
            "5 units",
            "4 units",
            "6 units",
            "7 units",
                        QuestionOption.A,
            "The distance is √((6-2)² + (6-3)²) = √(16+9) = √25 = 5 units.",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Solving Problems Using Distance Formula",
            "The points A(1,2) and B(1,8) lie on the same vertical line. What is the distance between them?",
            "6 units",
            "7 units",
            "5 units",
            "8 units",
                        QuestionOption.A,
            "Since the x-coordinates are the same, the distance is the difference between y-coordinates: |8-2| = 6 units.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Solving Problems Using Distance Formula",
            "Find the distance between the points (-2,-3) and (4,5).",
            "10 units",
            "8 units",
            "12 units",
            "6 units",
                        QuestionOption.A,
            "Using the distance formula: √((4+2)² + (5+3)²) = √(36+64) = √100 = 10 units.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Solving Problems Using Distance Formula",
            "A point is moved from (3,5) to (9,13). What is the length of the movement?",
            "10 units",
            "8 units",
            "12 units",
            "14 units",
            QuestionOption.A,
            "The movement distance is √((9-3)² + (13-5)²) = √(36+64) = 10 units.",
            DifficultyLevel.Intermediate,
            5);

        // Applications and Practice of Distance Formula

        AddQuestion(
            "Applications and Practice of Distance Formula",
            "Why is the distance formula used in engineering and design applications?",
            "It helps calculate accurate distances between points in models and layouts.",
            "It only measures angles between objects.",
            "It replaces coordinate systems completely.",
            "It is used only for basic arithmetic.",
            QuestionOption.A,
            "Engineers and designers use coordinate distances to measure lengths, positions, and spatial relationships in models.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Distance Formula",
            "A robot moves from position (2,4) to (8,12) on a coordinate map. What distance does it travel?",
            "10 units",
            "8 units",
            "12 units",
            "14 units",
            QuestionOption.A,
            "Using the distance formula: √((8-2)² + (12-4)²) = √(36+64) = √100 = 10 units.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Distance Formula",
            "How can the distance formula help in map-based applications?",
            "It calculates the distance between two locations represented by coordinates.",
            "It determines only the direction of movement.",
            "It calculates population growth.",
            "It measures only angles.",
            QuestionOption.A,
            "Maps and navigation systems use coordinate distances to estimate real-world distances between locations.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Distance Formula",
            "Two points on a blueprint are located at (-3,4) and (5,-2). What is the distance between them?",
            "10 units",
            "8 units",
            "12 units",
            "14 units",
            QuestionOption.A,
            "Distance = √((5+3)² + (-2-4)²) = √(64+36) = √100 = 10 units.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Distance Formula",
            "Why is the distance formula considered a connection between algebra and geometry?",
            "It uses algebraic coordinates to solve geometric distance problems.",
            "It removes the need for geometric reasoning.",
            "It is only used for algebraic equations.",
            "It cannot be applied outside mathematics.",
            QuestionOption.A,
            "The distance formula converts geometric measurements into algebraic calculations using coordinates.",
            DifficultyLevel.Advance,
            5);

        // Introduction to Midpoint Formula

        AddQuestion(
            "Introduction to Midpoint Formula",
            "Which formula is used to find the midpoint between two points?",
            "M = ((x₁ + x₂) / 2, (y₁ + y₂) / 2)",
            "M = (x₂ - x₁, y₂ - y₁)",
            "M = √((x₂-x₁)²+(y₂-y₁)²)",
            "M = (x₁ × x₂, y₁ × y₂)",
            QuestionOption.A,
            "The midpoint formula finds the average of the x-coordinates and y-coordinates of two endpoints.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Midpoint Formula",
            "What does the midpoint of a line segment represent?",
            "The point exactly halfway between two endpoints",
            "The longest distance between two points",
            "The angle formed by two lines",
            "The slope of the line segment",
            QuestionOption.A,
            "A midpoint divides a line segment into two equal parts.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Midpoint Formula",
            "If the endpoints of a line segment are (x₁,y₁) and (x₂,y₂), what values are averaged to find the midpoint?",
            "The x-coordinates and y-coordinates separately",
            "Only the x-coordinates",
            "Only the y-coordinates",
            "The distances between points",
            QuestionOption.A,
            "The midpoint is calculated by averaging the x-values and averaging the y-values.",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Midpoint Formula",
            "The midpoint formula is mainly used in which branch of mathematics?",
            "Coordinate Geometry",
            "Probability",
            "Statistics",
            "Trigonometry",
            QuestionOption.A,
            "The midpoint formula is a fundamental concept in coordinate geometry.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Midpoint Formula",
            "Why is the midpoint formula considered useful?",
            "It helps locate the center point of a segment using coordinates",
            "It calculates the area of any shape",
            "It finds only angles",
            "It converts coordinates into measurements",
            QuestionOption.A,
            "The midpoint formula allows us to find exact central positions between two points.",
            DifficultyLevel.Begineer,
            5);


        // Solving Problems Using Midpoint Formula

        AddQuestion(
            "Solving Problems Using Midpoint Formula",
            "Find the midpoint of the points (4,6) and (8,10).",
            "(6,8)",
            "(12,16)",
            "(4,4)",
            "(2,2)",
            QuestionOption.B,
            "Midpoint = ((4+8)/2, (6+10)/2) = (6,8).",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Solving Problems Using Midpoint Formula",
            "Find the midpoint of (-2,5) and (6,9).",
            "(2,7)",
            "(4,14)",
            "(8,4)",
            "(-4,2)",
            QuestionOption.A,
            "Midpoint = ((-2+6)/2, (5+9)/2) = (2,7).",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Solving Problems Using Midpoint Formula",
            "The midpoint of two points is (5,4). One endpoint is (2,3). Find the other endpoint.",
            "(8,5)",
            "(7,6)",
            "(3,1)",
            "(10,8)",
            QuestionOption.A,
            "Using midpoint relation: x₂ = 2(5)-2 = 8 and y₂ = 2(4)-3 = 5.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Solving Problems Using Midpoint Formula",
            "What is the midpoint of the points (-6,-4) and (2,8)?",
            "(-2,2)",
            "(4,4)",
            "(-4,6)",
            "(2,-2)",
            QuestionOption.A,
            "Midpoint = ((-6+2)/2, (-4+8)/2) = (-2,2).",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Solving Problems Using Midpoint Formula",
            "A line segment has endpoints (10,2) and (10,12). What is its midpoint?",
            "(10,7)",
            "(20,14)",
            "(5,7)",
            "(10,10)",
            QuestionOption.A,
            "The x-coordinate remains 10, and the y-coordinate is averaged: (2+12)/2 = 7.",
            DifficultyLevel.Intermediate,
            5);


        // Applications and Practice of Midpoint Formula

        AddQuestion(
            "Applications and Practice of Midpoint Formula",
            "How is the midpoint formula used in architecture and engineering?",
            "To find central points and balance locations in designs",
            "To calculate only angles",
            "To remove coordinate systems",
            "To measure temperature changes",
            QuestionOption.A,
            "Engineers use midpoint calculations for symmetry, balance, and positioning structures.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Midpoint Formula",
            "A GPS system uses two coordinate locations and calculates their midpoint. What does this represent?",
            "The location halfway between the two points",
            "The total distance between points",
            "The direction of movement",
            "The area between locations",
            QuestionOption.A,
            "The midpoint represents the exact center location between two coordinate positions.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Midpoint Formula",
            "In computer graphics, midpoint calculations help with:",
            "Positioning and transforming objects",
            "Calculating sound waves",
            "Measuring electrical power",
            "Creating random values",
            QuestionOption.A,
            "Graphics systems use midpoint calculations to determine object positions and transformations.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Midpoint Formula",
            "A designer finds the midpoint of two corners of a digital object. Why is this useful?",
            "To locate the object's center position",
            "To calculate its colour",
            "To remove its dimensions",
            "To change its coordinate system",
            QuestionOption.A,
            "The midpoint helps identify the central position of an object.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Midpoint Formula",
            "Why is the midpoint formula important in real-world coordinate applications?",
            "It connects mathematical coordinates with practical location problems",
            "It only works for textbook exercises",
            "It replaces all geometry formulas",
            "It cannot be used outside mathematics",
            QuestionOption.A,
            "The midpoint formula is used in mapping, navigation, engineering, and computer graphics.",
            DifficultyLevel.Advance,
            5);
        // Introduction to Section Formula

        AddQuestion(
            "Introduction to Section Formula",
            "What does the section formula help us find?",
            "The distance between two points",
            "The coordinates of a point dividing a line segment in a given ratio",
            "The slope of a line",
            "The angle between two lines",
            QuestionOption.B,
            "The section formula is used to find the coordinates of a point that divides a line segment internally or externally in a given ratio.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Section Formula",
            "In internal division, where is the dividing point located?",
            "Between the two endpoints of the line segment",
            "Outside the line segment",
            "Always at the origin",
            "Only on the x-axis",
            QuestionOption.A,
            "Internal division means the point lies between the two given endpoints.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Section Formula",
            "Which information is required to apply the section formula?",
            "Only the slope of the line",
            "Only one coordinate point",
            "Two endpoints and the ratio of division",
            "Only the length of the segment",
            QuestionOption.C,
            "The section formula requires coordinates of both endpoints and the ratio in which the segment is divided.",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Section Formula",
            "Section formula is a concept mainly studied under:",
            "Probability",
            "Statistics",
            "Trigonometry",
            "Coordinate Geometry",
            QuestionOption.D,
            "Section formula is an important topic in coordinate geometry.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Section Formula",
            "What does a ratio like 2:3 represent in section formula?",
            "The angle between two points",
            "How the line segment is divided",
            "The distance from origin",
            "The slope value",
            QuestionOption.B,
            "The ratio shows the relative lengths of the two parts created by the dividing point.",
            DifficultyLevel.Begineer,
            5);


        // Solving Problems Using Section Formula

        AddQuestion(
            "Solving Problems Using Section Formula",
            "Find the point dividing (2,4) and (8,10) internally in the ratio 1:1.",
            "(5,7)",
            "(6,8)",
            "(4,6)",
            "(3,5)",
            QuestionOption.A,
            "Ratio 1:1 gives the midpoint: ((2+8)/2, (4+10)/2) = (5,7).",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Solving Problems Using Section Formula",
            "Find the point dividing (0,0) and (6,9) internally in the ratio 1:2.",
            "(4,6)",
            "(2,3)",
            "(3,4)",
            "(1,2)",
            QuestionOption.B,
            "Using section formula: ((1×6+2×0)/(3), (1×9+2×0)/(3)) = (2,3).",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Solving Problems Using Section Formula",
            "The midpoint of a line segment is a special case of section formula with ratio:",
            "2:3",
            "3:4",
            "1:1",
            "1:2",
            QuestionOption.C,
            "When the ratio is 1:1, the point divides the segment into two equal parts and becomes the midpoint.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Solving Problems Using Section Formula",
            "Find the point dividing (-4,2) and (6,12) in ratio 1:1.",
            "(2,8)",
            "(-1,6)",
            "(0,5)",
            "(1,7)",
            QuestionOption.D,
            "The midpoint is ((-4+6)/2, (2+12)/2) = (1,7).",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Solving Problems Using Section Formula",
            "Which formula is used to find internal division point?",
            "((mx₂+nx₁)/(m+n), (my₂+ny₁)/(m+n))",
            "√((x₂-x₁)²+(y₂-y₁)²)",
            "((x₁+x₂),(y₁+y₂))",
            "y = mx + c",
            QuestionOption.A,
            "The internal section formula uses weighted averages of the endpoint coordinates.",
            DifficultyLevel.Intermediate,
            5);


        // Applications and Practice of Section Formula

        AddQuestion(
            "Applications and Practice of Section Formula",
            "Why is section formula useful in engineering drawings?",
            "It helps locate points at specific proportional positions",
            "It calculates only angles",
            "It removes coordinate systems",
            "It replaces all measurements",
            QuestionOption.A,
            "Engineers use section formula to locate points along structures based on ratios.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Section Formula",
            "A designer wants to find a point that divides a bridge support in a fixed ratio. Which concept is useful?",
            "Distance Formula",
            "Section Formula",
            "Slope Formula",
            "Circle Equation",
            QuestionOption.B,
            "Section formula helps find coordinates of points dividing a segment in a given ratio.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Section Formula",
            "How is section formula applied in computer graphics?",
            "By placing objects at proportional positions",
            "By calculating sound frequencies",
            "By removing coordinate systems",
            "By measuring only angles",
            QuestionOption.A,
            "Graphics applications use coordinate ratios for positioning and transformations.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Section Formula",
            "A map shows two locations and needs a point exactly halfway between them. Which method can be used?",
            "Distance formula only",
            "Slope formula only",
            "Section formula with ratio 1:1",
            "Area formula",
            QuestionOption.C,
            "A midpoint is obtained using section formula with a 1:1 ratio.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Section Formula",
            "Why is section formula important in coordinate geometry?",
            "It connects ratios with coordinate positions",
            "It works only for circles",
            "It replaces geometry completely",
            "It cannot be used practically",
            QuestionOption.A,
            "Section formula connects algebraic ratios with geometric positions on a coordinate plane.",
            DifficultyLevel.Advance,
            5);


        // Introduction to Straight Line

        AddQuestion(
            "Introduction to Straight Line",
            "What is a straight line in coordinate geometry?",
            "A line that extends infinitely in both directions with a constant slope",
            "A closed geometric figure",
            "A curve with changing slope",
            "A line segment with fixed length",
            QuestionOption.A,
            "A straight line has a constant slope and can be represented using an equation on the coordinate plane.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Straight Line",
            "Which equation represents the general form of a straight line?",
            "y = mx + c",
            "x² + y² = r²",
            "a² + b² = c²",
            "y = x²",
            QuestionOption.A,
            "The equation y = mx + c represents a straight line where m is the slope and c is the y-intercept.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Straight Line",
            "What does the slope of a straight line represent?",
            "The rate of change between y and x",
            "The length of the line",
            "The area below the line",
            "The angle of a triangle",
            QuestionOption.A,
            "Slope measures how much y changes for a change in x.",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Straight Line",
            "A straight line with positive slope moves in which direction?",
            "Upward from left to right",
            "Downward from left to right",
            "Only vertically",
            "Only horizontally",
            QuestionOption.A,
            "A positive slope means the line rises as it moves from left to right.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Straight Line",
            "The point where a line crosses the y-axis is called:",
            "Y-intercept",
            "X-intercept",
            "Origin",
            "Slope",
            QuestionOption.A,
            "The y-intercept is the value of y when x equals zero.",
            DifficultyLevel.Begineer,
            5);


        // Equations and Properties of Straight Lines

        AddQuestion(
            "Equations and Properties of Straight Lines",
            "Find the slope of the line passing through (2,3) and (6,11).",
            "2",
            "3",
            "4",
            "1",
            QuestionOption.A,
            "Slope = (11-3)/(6-2) = 8/4 = 2.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Equations and Properties of Straight Lines",
            "Which form of equation is known as slope-intercept form?",
            "y = mx + c",
            "ax + by + c = 0",
            "x² + y² = r²",
            "y = x²",
            QuestionOption.A,
            "Slope-intercept form directly shows slope and y-intercept values.",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Equations and Properties of Straight Lines",
            "What is the slope of a horizontal line?",
            "0",
            "1",
            "Undefined",
            "Infinite",
            QuestionOption.A,
            "A horizontal line has no vertical change, so its slope is zero.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Straight Lines",
            "Two lines having the same slope are:",
            "Parallel lines",
            "Perpendicular lines",
            "Intersecting lines",
            "Curved lines",
            QuestionOption.A,
            "Lines with equal slopes remain the same distance apart and are parallel.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Straight Lines",
            "What is the y-intercept of the line y = 3x + 5?",
            "5",
            "3",
            "8",
            "0",
            QuestionOption.A,
            "In y = mx + c, c represents the y-intercept. Here c = 5.",
            DifficultyLevel.Intermediate,
            5);


        // Applications and Practice of Straight Lines

        AddQuestion(
            "Applications and Practice of Straight Lines",
            "Why are straight line equations useful in real-world applications?",
            "They model constant relationships between quantities",
            "They only describe circles",
            "They cannot represent data",
            "They are only used in geometry classes",
            QuestionOption.A,
            "Straight lines are used in engineering, physics, economics, and data analysis to represent linear relationships.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Straight Lines",
            "A graph showing constant speed over time is usually represented by:",
            "A straight line",
            "A circle",
            "A random curve",
            "A triangle",
            QuestionOption.A,
            "Constant speed creates a linear relationship between distance and time.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Straight Lines",
            "In computer graphics, straight line equations are used for:",
            "Drawing and positioning objects",
            "Calculating probability only",
            "Finding chemical formulas",
            "Measuring temperature only",
            QuestionOption.A,
            "Graphics systems use line equations for rendering shapes and paths.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Straight Lines",
            "A road on a map is represented by a linear equation. What does the slope indicate?",
            "The direction and steepness of the road",
            "The colour of the road",
            "The total area of the map",
            "The population of the location",
            QuestionOption.A,
            "Slope represents the change in vertical position compared to horizontal movement.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Straight Lines",
            "Why are straight lines important in coordinate geometry?",
            "They connect algebraic equations with geometric representations",
            "They replace all mathematical concepts",
            "They only work for triangles",
            "They cannot be used practically",
            QuestionOption.A,
            "Straight lines are a foundation of coordinate geometry and many real-world models.",
            DifficultyLevel.Advance,
            5);


        // Introduction to Pair of Straight Lines

        AddQuestion(
            "Introduction to Pair of Straight Lines",
            "What does a pair of straight lines represent in coordinate geometry?",
            "Two straight lines considered together as a single equation",
            "A single curved line",
            "A circle equation",
            "A quadratic graph only",
            QuestionOption.A,
            "A pair of straight lines represents two lines together using a combined equation.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Pair of Straight Lines",
            "A pair of straight lines can intersect at:",
            "Two different circles",
            "A common point",
            "No coordinate point",
            "Only the origin",
            QuestionOption.B,
            "Two intersecting straight lines meet at one common point.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Pair of Straight Lines",
            "Which equation represents a pair of straight lines passing through the origin?",
            "ax² + 2hxy + by² = 0",
            "x² + y² = r²",
            "y = mx + c",
            "ax + by + c = 0",
            QuestionOption.A,
            "The homogeneous second-degree equation ax² + 2hxy + by² = 0 represents a pair of lines through the origin.",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Pair of Straight Lines",
            "Two lines that never meet are called:",
            "Intersecting lines",
            "Parallel lines",
            "Perpendicular lines",
            "Coincident lines",
            QuestionOption.B,
            "Parallel lines have the same slope and never intersect.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Pair of Straight Lines",
            "The angle between two straight lines depends on their:",
            "Slopes",
            "Lengths",
            "Coordinates only",
            "Areas",
            QuestionOption.A,
            "The angle between two lines can be calculated using their slopes.",
            DifficultyLevel.Begineer,
            5);


        // Equations and Properties of Pair of Straight Lines

        AddQuestion(
            "Equations and Properties of Pair of Straight Lines",
            "The general equation of a pair of straight lines is:",
            "ax + by + c = 0",
            "ax² + 2hxy + by² + 2gx + 2fy + c = 0",
            "x² + y² = r²",
            "y = mx + c",
            QuestionOption.B,
            "A second-degree equation can represent a pair of straight lines under specific conditions.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Equations and Properties of Pair of Straight Lines",
            "When two straight lines intersect, they have:",
            "The same slope",
            "A common point",
            "No solution",
            "Infinite distance",
            QuestionOption.B,
            "Intersecting lines share one common point.",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Equations and Properties of Pair of Straight Lines",
            "For two lines to be parallel, their slopes must be:",
            "Equal",
            "Opposite",
            "Zero always",
            "Undefined always",
            QuestionOption.A,
            "Parallel lines have equal slopes.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Pair of Straight Lines",
            "Which condition represents perpendicular lines?",
            "m₁ = m₂",
            "m₁ + m₂ = 1",
            "m₁m₂ = -1",
            "m₁m₂ = 1",
            QuestionOption.C,
            "Two lines are perpendicular when the product of their slopes is -1.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Pair of Straight Lines",
            "A pair of coincident lines means:",
            "Two lines overlap completely",
            "Two lines intersect once",
            "Two lines are perpendicular",
            "Two lines are parallel but different",
            QuestionOption.A,
            "Coincident lines represent the same line occupying the same position.",
            DifficultyLevel.Intermediate,
            5);


        // Applications and Practice of Pair of Straight Lines

        AddQuestion(
            "Applications and Practice of Pair of Straight Lines",
            "Pair of straight lines are useful in engineering because they help model:",
            "Intersections and directional relationships",
            "Only circular objects",
            "Only statistical data",
            "Random patterns",
            QuestionOption.A,
            "Engineers use pairs of lines to analyse intersections and geometric structures.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Pair of Straight Lines",
            "In computer graphics, pairs of straight lines are commonly used for:",
            "Creating intersections and geometric shapes",
            "Calculating probability",
            "Generating sound waves",
            "Measuring temperature",
            QuestionOption.A,
            "Graphics systems use line intersections to construct shapes and models.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Pair of Straight Lines",
            "A road junction represented by two crossing roads can be analysed using:",
            "Circle equations",
            "Pair of straight lines",
            "Area formulas",
            "Probability formulas",
            QuestionOption.B,
            "Intersecting roads can be represented mathematically as a pair of straight lines.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Pair of Straight Lines",
            "Why is the angle between two lines important?",
            "It helps analyse direction and intersection relationships",
            "It calculates only areas",
            "It removes coordinate systems",
            "It is unrelated to geometry",
            QuestionOption.A,
            "The angle between lines helps understand orientation and geometric relationships.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Pair of Straight Lines",
            "Pair of straight line concepts are applied in:",
            "Architecture, engineering, and computer modelling",
            "Only basic arithmetic",
            "Only biology",
            "Only probability",
            QuestionOption.D,
            "Pairs of lines are widely used in design, modelling, and analytical geometry.",
            DifficultyLevel.Advance,
            5);

        // Introduction to Circle in Coordinate Geometry

        AddQuestion(
            "Introduction to Circle in Coordinate Geometry",
            "What is the equation of a circle with centre (0,0) and radius r?",
            "x² + y² = r²",
            "y = mx + c",
            "ax + by + c = 0",
            "x = r",
            QuestionOption.A,
            "A circle centred at the origin has the standard equation x² + y² = r².",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Circle in Coordinate Geometry",
            "What does the radius of a circle represent?",
            "The distance between two points on the circle",
            "The distance from the centre to any point on the circle",
            "The slope of the circle",
            "The area inside the circle",
            QuestionOption.B,
            "The radius is the distance from the centre of the circle to any point on its boundary.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Circle in Coordinate Geometry",
            "Which point is called the centre of a circle?",
            "The point where the circle crosses the x-axis",
            "The point with maximum radius",
            "The fixed point from which all boundary points are equally distant",
            "The highest point of the circle",
            QuestionOption.C,
            "The centre is the fixed point that maintains equal distance from every point on the circle.",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Circle in Coordinate Geometry",
            "A circle in coordinate geometry is mainly represented using:",
            "Slope",
            "Ratio",
            "Linear equation",
            "Equation involving centre and radius",
            QuestionOption.D,
            "Coordinate geometry represents circles using equations involving centre coordinates and radius.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Circle in Coordinate Geometry",
            "If the radius of a circle increases, the size of the circle:",
            "Increases",
            "Decreases",
            "Remains unchanged",
            "Becomes a straight line",
            QuestionOption.A,
            "A larger radius creates a larger circle.",
            DifficultyLevel.Begineer,
            5);


        // Equations and Properties of Circle

        AddQuestion(
            "Equations and Properties of Circle",
            "What is the standard form equation of a circle with centre (h,k)?",
            "(x-h)² + (y-k)² = r²",
            "y = mx + c",
            "ax + by + c = 0",
            "x² + y² = 0",
            QuestionOption.A,
            "The standard equation represents a circle with centre (h,k) and radius r.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Equations and Properties of Circle",
            "In the circle equation, what does r represent?",
            "Centre",
            "Radius",
            "Slope",
            "Diameter",
            QuestionOption.B,
            "The value r represents the radius of the circle.",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Equations and Properties of Circle",
            "The centre of the circle x² + y² = 25 is:",
            "(5,5)",
            "(25,0)",
            "(0,0)",
            "(0,5)",
            QuestionOption.C,
            "Since there are no shifted terms, the centre is the origin (0,0).",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Circle",
            "The diameter of a circle with radius 7 is:",
            "7",
            "14",
            "21",
            "49",
            QuestionOption.B,
            "Diameter is twice the radius: 2 × 7 = 14.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Circle",
            "Which equation represents a circle?",
            "x² + y² = 16",
            "y = 2x + 1",
            "x + y = 5",
            "y = x²",
            QuestionOption.A,
            "An equation containing squared x and y terms with equal coefficients can represent a circle.",
            DifficultyLevel.Intermediate,
            5);


        // Applications and Practice of Circle

        AddQuestion(
            "Applications and Practice of Circle",
            "Circles in coordinate geometry are useful in:",
            "Modelling circular objects and paths",
            "Only solving inequalities",
            "Only measuring angles",
            "Only calculating slopes",
            QuestionOption.A,
            "Circle equations are used in engineering, graphics, navigation, and design.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Circle",
            "In computer graphics, circle equations are used for:",
            "Creating circular shapes and curves",
            "Writing text documents",
            "Calculating probability only",
            "Replacing coordinate systems",
            QuestionOption.A,
            "Graphics systems use circle equations to render circular objects.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Circle",
            "A satellite orbit can be approximated mathematically using:",
            "Straight line equation",
            "Circle equation",
            "Triangle formula",
            "Slope formula",
            QuestionOption.B,
            "Circular motion can often be represented using circle equations.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Circle",
            "Why are circle equations important in engineering?",
            "They help model circular components and motion",
            "They remove the need for measurements",
            "They only describe triangles",
            "They cannot be applied practically",
            QuestionOption.A,
            "Engineers use circle equations for wheels, gears, pipes, and mechanical designs.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Circle",
            "Which fields commonly use circle concepts?",
            "Only history",
            "Only literature",
            "Engineering, astronomy, and computer graphics",
            "Only basic arithmetic",
            QuestionOption.C,
            "Circle geometry is widely used in science, engineering, and technology.",
            DifficultyLevel.Advance,
            5);

        // Introduction to Parabola in Coordinate Geometry

        AddQuestion(
            "Introduction to Parabola in Coordinate Geometry",
            "What is a parabola?",
            "A curve formed by points equidistant from a focus and directrix",
            "A closed circular shape",
            "A straight line",
            "A polygon with equal sides",
            QuestionOption.A,
            "A parabola is a conic section where every point is equally distant from the focus and directrix.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Parabola in Coordinate Geometry",
            "The fixed point of a parabola is called:",
            "Directrix",
            "Focus",
            "Vertex",
            "Axis",
            QuestionOption.B,
            "The focus is the fixed point used to define a parabola.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Parabola in Coordinate Geometry",
            "The fixed line associated with a parabola is called:",
            "Axis of symmetry",
            "Tangent",
            "Directrix",
            "Chord",
            QuestionOption.C,
            "The directrix is the fixed line from which points on a parabola are equally distant from the focus.",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Parabola in Coordinate Geometry",
            "The highest or lowest point of a parabola is called:",
            "Focus",
            "Directrix",
            "Axis",
            "Vertex",
            QuestionOption.D,
            "The vertex is the turning point of a parabola.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Parabola in Coordinate Geometry",
            "A parabola is a type of:",
            "Conic section",
            "Triangle",
            "Quadrilateral",
            "Circle only",
            QuestionOption.A,
            "Parabola is one of the four major conic sections.",
            DifficultyLevel.Begineer,
            5);


        // Equations and Properties of Parabola

        AddQuestion(
            "Equations and Properties of Parabola",
            "Which equation represents a basic parabola opening upward?",
            "y² = 4ax",
            "y = x²",
            "x² + y² = r²",
            "ax + by + c = 0",
            QuestionOption.B,
            "The equation y = x² represents a standard upward-opening parabola.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Equations and Properties of Parabola",
            "The line that divides a parabola into two equal halves is called:",
            "Focus",
            "Directrix",
            "Axis of symmetry",
            "Tangent",
            QuestionOption.C,
            "The axis of symmetry divides the parabola into two mirror-image halves.",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Equations and Properties of Parabola",
            "In the equation y² = 4ax, the value a represents:",
            "Radius",
            "Slope",
            "Distance from vertex to focus",
            "Diameter",
            QuestionOption.C,
            "The parameter a represents the distance between the vertex and focus.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Parabola",
            "A parabola with equation x² = 4ay opens:",
            "Along the x-axis",
            "Along the y-axis",
            "Only downward",
            "In a circular direction",
            QuestionOption.A,
            "The equation x² = 4ay represents a parabola opening along the y-axis.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Parabola",
            "Which property is true for every parabola?",
            "Every point is equally distant from focus and directrix",
            "It always forms a circle",
            "It has no symmetry",
            "It has four vertices",
            QuestionOption.A,
            "Equal distance from focus and directrix is the defining property of a parabola.",
            DifficultyLevel.Intermediate,
            5);


        // Applications and Practice of Parabola

        AddQuestion(
            "Applications and Practice of Parabola",
            "Parabolic reflectors are used in:",
            "Satellite dishes and headlights",
            "Flat surfaces",
            "Rectangular designs",
            "Only maps",
            QuestionOption.A,
            "Parabolic shapes reflect signals and light efficiently toward a focus.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Parabola",
            "The path of a projectile under gravity is approximately:",
            "Circular",
            "Parabolic",
            "Linear",
            "Triangular",
            QuestionOption.B,
            "Projectile motion follows a parabolic trajectory when air resistance is ignored.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Parabola",
            "In engineering, parabolas are useful for designing:",
            "Reflectors and optimized structures",
            "Only straight roads",
            "Only square objects",
            "Random patterns",
            QuestionOption.A,
            "Engineers use parabolic curves in antennas, bridges, and optical devices.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Parabola",
            "A satellite communication dish uses a parabola because:",
            "It concentrates signals at the focus",
            "It removes all signals",
            "It creates random waves",
            "It prevents reflection",
            QuestionOption.D,
            "The reflective property of a parabola directs signals toward the focus.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Parabola",
            "Which field commonly applies parabola concepts?",
            "Astronomy and physics",
            "Only literature",
            "Only history",
            "Only basic counting",
            QuestionOption.A,
            "Parabolas are widely used in physics, astronomy, engineering, and technology.",
            DifficultyLevel.Advance,
            5);

        // Introduction to Ellipse in Coordinate Geometry

        AddQuestion(
            "Introduction to Ellipse in Coordinate Geometry",
            "What is an ellipse?",
            "A closed curve where the sum of distances from two fixed points is constant",
            "A straight line with constant slope",
            "A curve with only one focus",
            "A polygon with equal sides",
            QuestionOption.A,
            "An ellipse is defined as a set of points where the sum of distances from two foci remains constant.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Ellipse in Coordinate Geometry",
            "The fixed points used to define an ellipse are called:",
            "Vertices",
            "Foci",
            "Axes",
            "Directrices",
            QuestionOption.B,
            "The two fixed points inside an ellipse are called foci.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Ellipse in Coordinate Geometry",
            "The longest diameter of an ellipse is called:",
            "Minor axis",
            "Radius",
            "Major axis",
            "Directrix",
            QuestionOption.C,
            "The major axis is the longest line segment passing through the centre of an ellipse.",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Ellipse in Coordinate Geometry",
            "The shortest diameter of an ellipse is called:",
            "Focus",
            "Major axis",
            "Vertex",
            "Minor axis",
            QuestionOption.D,
            "The minor axis is the shorter diameter perpendicular to the major axis.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Ellipse in Coordinate Geometry",
            "An ellipse is a type of:",
            "Conic section",
            "Triangle",
            "Straight line",
            "Quadrilateral",
            QuestionOption.A,
            "Ellipse is one of the four main conic sections.",
            DifficultyLevel.Begineer,
            5);


        // Equations and Properties of Ellipse

        AddQuestion(
            "Equations and Properties of Ellipse",
            "Which equation represents a standard ellipse centred at the origin?",
            "(x²/a²) + (y²/b²) = 1",
            "y = mx + c",
            "x² + y² = r²",
            "ax + by + c = 0",
            QuestionOption.A,
            "The standard ellipse equation uses squared coordinates divided by squared axes lengths.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Equations and Properties of Ellipse",
            "In an ellipse equation, a and b represent:",
            "Slopes",
            "Semi-axis lengths",
            "Angles",
            "Coordinates only",
            QuestionOption.B,
            "The values a and b represent the semi-major and semi-minor axis lengths.",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Equations and Properties of Ellipse",
            "The centre of the ellipse x²/25 + y²/9 = 1 is:",
            "(5,9)",
            "(25,9)",
            "(0,0)",
            "(1,1)",
            QuestionOption.C,
            "Since there are no shifted terms, the ellipse is centred at the origin.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Ellipse",
            "An ellipse has:",
            "No symmetry",
            "Only one axis",
            "A circular shape always",
            "Two axes of symmetry",
            QuestionOption.D,
            "Every ellipse has symmetry about both its major and minor axes.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Ellipse",
            "If both axes of an ellipse become equal, the ellipse becomes:",
            "A circle",
            "A parabola",
            "A hyperbola",
            "A line",
            QuestionOption.A,
            "A circle is a special case of an ellipse where both axes are equal.",
            DifficultyLevel.Intermediate,
            5);


        // Applications and Practice of Ellipse

        AddQuestion(
            "Applications and Practice of Ellipse",
            "Ellipses are used in astronomy to describe:",
            "Planetary orbits",
            "Straight roads",
            "Square structures",
            "Random motion",
            QuestionOption.A,
            "Many planetary orbits are approximately elliptical.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Ellipse",
            "An elliptical reflector works because:",
            "It blocks all waves",
            "It can direct energy between its foci",
            "It removes the centre point",
            "It creates straight lines",
            QuestionOption.B,
            "A property of ellipses allows signals or sound to travel between the two foci.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Ellipse",
            "Elliptical shapes are commonly used in:",
            "Only arithmetic",
            "Only biology",
            "Architecture and engineering design",
            "Only programming syntax",
            QuestionOption.C,
            "Elliptical designs appear in buildings, mechanical parts, and structures.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Ellipse",
            "Why are ellipse equations important in coordinate geometry?",
            "They connect algebra with geometric curves",
            "They replace all geometric concepts",
            "They only calculate slopes",
            "They cannot model real objects",
            QuestionOption.A,
            "Ellipse equations allow mathematical analysis of curved shapes and real-world systems.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Ellipse",
            "Which field uses ellipse concepts for orbital calculations?",
            "Astronomy",
            "Literature",
            "History",
            "Basic arithmetic",
            QuestionOption.A,
            "Astronomy uses elliptical models to study planetary motion.",
            DifficultyLevel.Advance,
            5);

        // Introduction to Hyperbola in Coordinate Geometry

        AddQuestion(
            "Introduction to Hyperbola in Coordinate Geometry",
            "What is a hyperbola?",
            "A conic section formed by points with a constant difference of distances from two fixed points",
            "A closed circular curve",
            "A straight line",
            "A polygon with equal sides",
            QuestionOption.A,
            "A hyperbola is defined as a set of points where the difference of distances from two foci is constant.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Hyperbola in Coordinate Geometry",
            "The fixed points of a hyperbola are called:",
            "Vertices",
            "Foci",
            "Axes",
            "Directrices",
            QuestionOption.B,
            "The fixed points used to define a hyperbola are called foci.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Hyperbola in Coordinate Geometry",
            "The lines that a hyperbola approaches but never touches are called:",
            "Vertices",
            "Foci",
            "Asymptotes",
            "Axes",
            QuestionOption.C,
            "Asymptotes are lines that guide the shape of a hyperbola as it extends outward.",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Hyperbola in Coordinate Geometry",
            "The turning points of a hyperbola are called:",
            "Focus",
            "Directrix",
            "Centre",
            "Vertices",
            QuestionOption.D,
            "The vertices are the points where each branch of a hyperbola reaches its closest point to the centre.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Hyperbola in Coordinate Geometry",
            "A hyperbola is a type of:",
            "Conic section",
            "Triangle",
            "Quadrilateral",
            "Circle only",
            QuestionOption.A,
            "Hyperbola is one of the four main conic sections.",
            DifficultyLevel.Begineer,
            5);


        // Equations and Properties of Hyperbola

        AddQuestion(
            "Equations and Properties of Hyperbola",
            "Which equation represents a standard hyperbola centred at the origin?",
            "x²/a² - y²/b² = 1",
            "x² + y² = r²",
            "y = mx + c",
            "ax + by + c = 0",
            QuestionOption.A,
            "The standard equation of a horizontal hyperbola is x²/a² - y²/b² = 1.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Equations and Properties of Hyperbola",
            "In a hyperbola equation, a represents:",
            "Slope",
            "Distance from centre to vertex",
            "Radius",
            "Area",
            QuestionOption.B,
            "The value a represents the distance from the centre to a vertex.",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Equations and Properties of Hyperbola",
            "The centre of the hyperbola x²/16 - y²/9 = 1 is:",
            "(16,9)",
            "(4,3)",
            "(0,0)",
            "(1,1)",
            QuestionOption.C,
            "Since there are no translated terms, the centre is at the origin.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Hyperbola",
            "A hyperbola has how many branches?",
            "One",
            "Three",
            "Four",
            "Two",
            QuestionOption.D,
            "A standard hyperbola consists of two separate branches.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Hyperbola",
            "Which property helps determine the shape of a hyperbola?",
            "Asymptotes",
            "Only radius",
            "Only circumference",
            "Area formula",
            QuestionOption.A,
            "Asymptotes define the direction and shape of hyperbola branches.",
            DifficultyLevel.Intermediate,
            5);


        // Applications and Practice of Hyperbola

        AddQuestion(
            "Applications and Practice of Hyperbola",
            "Hyperbolas are used in navigation systems for:",
            "Locating positions using signal differences",
            "Drawing circles only",
            "Calculating areas only",
            "Creating triangles",
            QuestionOption.A,
            "Navigation systems can use hyperbolic curves based on differences in signal arrival times.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Hyperbola",
            "A hyperbolic path can be observed in:",
            "Projectile motion only",
            "Some physics and engineering systems",
            "Only square structures",
            "Only arithmetic problems",
            QuestionOption.B,
            "Hyperbolic models are used in physics, engineering, and signal analysis.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Hyperbola",
            "Hyperbola concepts are applied in:",
            "Only literature",
            "Only history",
            "Engineering and astronomy",
            "Only basic counting",
            QuestionOption.C,
            "Engineering and astronomy use hyperbolic models for analysis and design.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Hyperbola",
            "Why are hyperbola equations important in coordinate geometry?",
            "They connect algebra with complex geometric curves",
            "They remove the need for graphs",
            "They only describe circles",
            "They cannot model real systems",
            QuestionOption.A,
            "Hyperbola equations allow mathematical analysis of important curved structures.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Hyperbola",
            "Which technology uses hyperbolic principles for positioning?",
            "GPS and navigation systems",
            "Text editors",
            "Image filters only",
            "Simple calculators",
            QuestionOption.A,
            "Navigation technologies use hyperbolic relationships for accurate positioning.",
            DifficultyLevel.Advance,
            5);
        // Introduction to Conic Sections

        AddQuestion(
            "Introduction to Conic Sections",
            "What are conic sections?",
            "Curves obtained by intersecting a cone with a plane",
            "Types of polygons",
            "Straight lines only",
            "Arithmetic formulas",
            QuestionOption.A,
            "Conic sections are curves formed when a plane intersects a double cone.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Conic Sections",
            "Which of the following is a conic section?",
            "Square",
            "Ellipse",
            "Triangle",
            "Rectangle",
            QuestionOption.B,
            "An ellipse is one of the four main conic sections.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Conic Sections",
            "The four main types of conic sections are:",
            "Triangles, squares, circles, rectangles",
            "Lines, angles, points, planes",
            "Circle, parabola, ellipse, and hyperbola",
            "Only circles and lines",
            QuestionOption.C,
            "The four major conic sections are circles, parabolas, ellipses, and hyperbolas.",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Conic Sections",
            "Which conic section has a constant distance from a centre point?",
            "Parabola",
            "Hyperbola",
            "Ellipse",
            "Circle",
            QuestionOption.D,
            "A circle is defined as all points at a fixed distance from the centre.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Conic Sections",
            "Conic sections are mainly studied in:",
            "Coordinate geometry",
            "Basic arithmetic",
            "Number theory only",
            "Statistics only",
            QuestionOption.A,
            "Coordinate geometry uses equations to represent and analyse conic sections.",
            DifficultyLevel.Begineer,
            5);


        // Equations and Properties of Conic Sections

        AddQuestion(
            "Equations and Properties of Conic Sections",
            "Which equation represents a circle centred at the origin?",
            "x² + y² = r²",
            "y = mx + c",
            "x²/a² - y²/b² = 1",
            "y² = 4ax",
            QuestionOption.A,
            "The equation x² + y² = r² represents a circle with centre at the origin.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Equations and Properties of Conic Sections",
            "Which conic section is represented by y = x²?",
            "Circle",
            "Parabola",
            "Ellipse",
            "Hyperbola",
            QuestionOption.B,
            "The equation y = x² represents a standard upward-opening parabola.",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Equations and Properties of Conic Sections",
            "The equation x²/a² + y²/b² = 1 represents:",
            "Hyperbola",
            "Parabola",
            "Ellipse",
            "Straight line",
            QuestionOption.C,
            "The standard ellipse equation contains the sum of two squared terms equal to one.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Conic Sections",
            "The equation x²/a² - y²/b² = 1 represents:",
            "Circle",
            "Ellipse",
            "Parabola",
            "Hyperbola",
            QuestionOption.D,
            "A difference between squared terms represents a standard hyperbola.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Conic Sections",
            "Which property helps classify different conic sections?",
            "Their equations and geometric characteristics",
            "Only their colours",
            "Only their sizes",
            "Only their positions",
            QuestionOption.A,
            "Conic sections are classified using their equations and geometric properties.",
            DifficultyLevel.Intermediate,
            5);


        // Applications and Practice of Conic Sections

        AddQuestion(
            "Applications and Practice of Conic Sections",
            "Conic sections are used in astronomy for:",
            "Studying planetary orbits",
            "Writing documents",
            "Counting numbers",
            "Creating tables",
            QuestionOption.A,
            "Elliptical and hyperbolic paths are important in astronomy.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Conic Sections",
            "Parabolic reflectors are commonly used in:",
            "Satellite dishes and antennas",
            "Flat surfaces",
            "Random structures",
            "Only books",
            QuestionOption.B,
            "Parabolic reflectors focus signals and waves efficiently.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Conic Sections",
            "Which field uses conic sections for modelling real-world structures?",
            "Only history",
            "Only literature",
            "Engineering and physics",
            "Only basic calculation",
            QuestionOption.C,
            "Engineering and physics use conic sections for modelling curves and motion.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Conic Sections",
            "Why are conic sections important in mathematics?",
            "They connect algebra with geometric shapes and real applications",
            "They replace all mathematical topics",
            "They only describe straight lines",
            "They cannot be used practically",
            QuestionOption.A,
            "Conic sections provide mathematical models for many scientific and engineering systems.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Conic Sections",
            "Which technology uses conic section principles?",
            "Optics, navigation, and engineering systems",
            "Only calculators",
            "Only text processing",
            "Only simple arithmetic",
            QuestionOption.A,
            "Many technologies rely on conic sections for design and analysis.",
            DifficultyLevel.Advance,
            5);


        // PQ. 3
        // ==========================================================
        // Introduction to Cartesian Plane
        // ==========================================================

        AddQuestion(
            "Introduction to Cartesian Plane",
            "What is the Cartesian plane?",
            "A mathematical equation",
            "A two-dimensional coordinate system used to locate points",
            "A type of triangle",
            "A collection of numbers",
            QuestionOption.B,
            "The Cartesian plane is a two-dimensional coordinate system formed by the x-axis and y-axis, used to locate points.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Cartesian Plane",
            "Which axis runs horizontally on the Cartesian plane?",
            "y-axis",
            "z-axis",
            "x-axis",
            "Origin axis",
            QuestionOption.C,
            "The x-axis is the horizontal axis, while the y-axis is vertical.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Cartesian Plane",
            "What is the point where the x-axis and y-axis intersect called?",
            "Quadrant",
            "Midpoint",
            "Origin",
            "Vertex",
            QuestionOption.C,
            "The origin is the point (0,0) where both coordinate axes intersect.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Cartesian Plane",
            "Which ordered pair represents the origin?",
            "(1,1)",
            "(0,1)",
            "(1,0)",
            "(0,0)",
            QuestionOption.D,
            "The origin has both x-coordinate and y-coordinate equal to zero.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Cartesian Plane",
            "Why is the Cartesian plane important in mathematics?",
            "It is only used to draw circles.",
            "It helps represent and analyze the positions of points using coordinates.",
            "It replaces algebra completely.",
            "It is only used in geometry.",
            QuestionOption.B,
            "The Cartesian plane provides a way to locate points and visualize mathematical relationships.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Understanding Coordinates and Quadrants
        // ==========================================================

        AddQuestion(
            "Understanding Coordinates and Quadrants",
            "In the ordered pair (5, -2), what is the x-coordinate?",
            "5",
            "-2",
            "3",
            "0",
            QuestionOption.A,
            "The first number in an ordered pair represents the x-coordinate.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Understanding Coordinates and Quadrants",
            "A point with coordinates (4, 3) lies in which quadrant?",
            "Quadrant I",
            "Quadrant II",
            "Quadrant III",
            "Quadrant IV",
            QuestionOption.A,
            "Both coordinates are positive, so the point lies in Quadrant I.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Understanding Coordinates and Quadrants",
            "A point with coordinates (-5, 2) lies in which quadrant?",
            "Quadrant I",
            "Quadrant II",
            "Quadrant III",
            "Quadrant IV",
            QuestionOption.B,
            "A negative x-coordinate and positive y-coordinate place the point in Quadrant II.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Understanding Coordinates and Quadrants",
            "Which point lies in Quadrant III?",
            "(3, -2)",
            "(-4, 5)",
            "(-2, -6)",
            "(5, 4)",
            QuestionOption.C,
            "Quadrant III contains points where both x and y coordinates are negative.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Understanding Coordinates and Quadrants",
            "What is the correct order when writing coordinates?",
            "(y, x)",
            "(x + y)",
            "(x, y)",
            "(y - x)",
            QuestionOption.C,
            "Coordinates are always written in the form (x, y), where x comes first followed by y.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Cartesian Plane
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Cartesian Plane",
            "Which of the following uses the Cartesian plane in real life?",
            "Maps and GPS systems",
            "Cooking recipes",
            "Alphabetical sorting",
            "Calendar dates",
            QuestionOption.A,
            "Maps and GPS use coordinate systems to identify exact locations.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Cartesian Plane",
            "A treasure is located at (6, -4). Which direction from the origin must you move first?",
            "6 units left",
            "6 units right",
            "4 units up",
            "4 units left",
            QuestionOption.B,
            "Move 6 units to the right along the x-axis, then 4 units down along the y-axis.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Cartesian Plane",
            "A point lies on the y-axis. Which statement is true?",
            "Its y-coordinate is always 0.",
            "Its x-coordinate is always 0.",
            "Both coordinates are positive.",
            "Its x-coordinate equals its y-coordinate.",
            QuestionOption.B,
            "Every point on the y-axis has an x-coordinate of 0.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Cartesian Plane",
            "Which point lies on the x-axis?",
            "(0, 5)",
            "(3, 0)",
            "(2, 2)",
            "(-1, 4)",
            QuestionOption.B,
            "Points on the x-axis always have a y-coordinate of 0.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Cartesian Plane",
            "Why is the Cartesian plane widely used in mathematics, science, and engineering?",
            "It allows precise representation of positions, graphs, and relationships between variables.",
            "It is only useful for drawing shapes.",
            "It replaces the need for equations.",
            "It can only represent whole numbers.",
            QuestionOption.A,
            "The Cartesian plane is essential for graphing functions, locating positions, and modelling real-world situations.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Introduction to Distance Formula
        // ==========================================================

        AddQuestion(
            "Introduction to Distance Formula",
            "What is the primary purpose of the distance formula?",
            "To find the midpoint of two points",
            "To calculate the distance between two points on a coordinate plane",
            "To find the slope of a line",
            "To determine the area of a triangle",
            QuestionOption.B,
            "The distance formula is used to calculate the straight-line distance between two points on a coordinate plane.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Distance Formula",
            "The distance formula is derived from which mathematical theorem?",
            "Fundamental Theorem of Algebra",
            "Pythagorean Theorem",
            "Binomial Theorem",
            "Euclid's Division Lemma",
            QuestionOption.B,
            "The distance formula is derived using the Pythagorean Theorem.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Distance Formula",
            "Which expression correctly represents the distance between two points (x₁, y₁) and (x₂, y₂)?",
            "√((x₂ - x₁)² + (y₂ - y₁)²)",
            "(x₂ - x₁) + (y₂ - y₁)",
            "(x₁ + x₂) / 2",
            "(y₂ - y₁) / (x₂ - x₁)",
            QuestionOption.A,
            "The distance formula is √((x₂ - x₁)² + (y₂ - y₁)²).",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Distance Formula",
            "What is the distance between the points (2, 3) and (2, 8)?",
            "3",
            "5",
            "6",
            "8",
            QuestionOption.B,
            "Since the x-coordinates are the same, the distance is the difference between the y-coordinates: 8 - 3 = 5.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Distance Formula",
            "Why is the distance formula important in coordinate geometry?",
            "It helps calculate exact distances between points.",
            "It only finds the midpoint of a line segment.",
            "It is only used for horizontal lines.",
            "It replaces the need for coordinates.",
            QuestionOption.A,
            "The distance formula provides an accurate way to measure the distance between any two points on a coordinate plane.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Solving Problems Using Distance Formula
        // ==========================================================

        AddQuestion(
            "Solving Problems Using Distance Formula",
            "What is the distance between the points (1, 1) and (4, 5)?",
            "4",
            "5",
            "6",
            "7",
            QuestionOption.B,
            "Distance = √((4-1)² + (5-1)²) = √(9 + 16) = √25 = 5.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Solving Problems Using Distance Formula",
            "Find the distance between the points (-2, 3) and (-2, 9).",
            "4",
            "5",
            "6",
            "7",
            QuestionOption.C,
            "The x-coordinates are equal, so the distance is |9 - 3| = 6.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Solving Problems Using Distance Formula",
            "What is the distance between (0, 0) and (6, 8)?",
            "8",
            "9",
            "10",
            "12",
            QuestionOption.C,
            "Distance = √(6² + 8²) = √100 = 10.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Solving Problems Using Distance Formula",
            "The distance between two points is always:",
            "Negative",
            "Positive or zero",
            "Less than 1",
            "An integer",
            QuestionOption.B,
            "Distance represents length, which cannot be negative.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Solving Problems Using Distance Formula",
            "Which situation requires the use of the distance formula?",
            "Finding the straight-line distance between two cities on a coordinate map",
            "Finding the average of two numbers",
            "Adding two fractions",
            "Multiplying matrices",
            QuestionOption.A,
            "The distance formula is used whenever the straight-line distance between two coordinate points is required.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Distance Formula
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Distance Formula",
            "Which profession commonly uses the distance formula for mapping and measurements?",
            "Cartographers",
            "Chefs",
            "Musicians",
            "Poets",
            QuestionOption.A,
            "Cartographers use coordinate systems and distance calculations when creating maps.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Distance Formula",
            "The distance formula helps determine the:",
            "Straight-line distance between two locations",
            "Temperature of an object",
            "Colour of a graph",
            "Weight of a point",
            QuestionOption.A,
            "It calculates the shortest straight-line distance between two coordinate points.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Distance Formula",
            "In computer graphics, the distance formula is commonly used to:",
            "Measure the distance between objects on the screen",
            "Change font styles",
            "Store files",
            "Connect to the internet",
            QuestionOption.A,
            "Computer graphics frequently use distance calculations for rendering, collision detection, and animation.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Distance Formula",
            "If two points have the same coordinates, what is the distance between them?",
            "0",
            "1",
            "Undefined",
            "Cannot be determined",
            QuestionOption.A,
            "The distance between a point and itself is always zero.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Distance Formula",
            "Why is the distance formula widely used in science, engineering, and navigation?",
            "It provides an accurate method for measuring distances between coordinate points.",
            "It only works with horizontal lines.",
            "It replaces the need for maps.",
            "It is only useful in classrooms.",
            QuestionOption.A,
            "The distance formula is fundamental for solving real-world measurement problems involving coordinates.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Midpoint Formula
        // ==========================================================

        AddQuestion(
            "Introduction to Midpoint Formula",
            "What is the purpose of the midpoint formula?",
            "To find the distance between two points",
            "To find the point exactly halfway between two points",
            "To calculate the slope of a line",
            "To determine the area of a rectangle",
            QuestionOption.B,
            "The midpoint formula is used to find the point that lies exactly halfway between two points on a line segment.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Midpoint Formula",
            "The midpoint formula finds the average of which values?",
            "Only the x-coordinates",
            "Only the y-coordinates",
            "The x-coordinates and y-coordinates separately",
            "The distances between the points",
            QuestionOption.C,
            "The midpoint is found by averaging the x-coordinates and the y-coordinates separately.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Midpoint Formula",
            "Which expression correctly represents the midpoint of two points (x₁, y₁) and (x₂, y₂)?",
            "((x₁+x₂)/2, (y₁+y₂)/2)",
            "(x₂-x₁, y₂-y₁)",
            "((x₂-x₁)/2, (y₂-y₁)/2)",
            "(x₁+x₂, y₁+y₂)",
            QuestionOption.A,
            "The midpoint formula averages the x-coordinates and the y-coordinates independently.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Midpoint Formula",
            "What is the midpoint of the points (2, 4) and (6, 8)?",
            "(4, 6)",
            "(8, 12)",
            "(2, 2)",
            "(5, 6)",
            QuestionOption.A,
            "The midpoint is ((2+6)/2, (4+8)/2) = (4, 6).",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Midpoint Formula",
            "Why is the midpoint formula useful in coordinate geometry?",
            "It finds the exact center between two points.",
            "It calculates the length of a line segment.",
            "It determines the slope of a line.",
            "It only works for horizontal lines.",
            QuestionOption.A,
            "The midpoint formula identifies the exact center point of a line segment.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Solving Problems Using Midpoint Formula
        // ==========================================================

        AddQuestion(
            "Solving Problems Using Midpoint Formula",
            "Find the midpoint of the points (0, 0) and (4, 6).",
            "(2, 3)",
            "(4, 3)",
            "(2, 6)",
            "(0, 3)",
            QuestionOption.A,
            "Midpoint = ((0+4)/2, (0+6)/2) = (2, 3).",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Solving Problems Using Midpoint Formula",
            "What is the midpoint of (-2, 4) and (6, 8)?",
            "(2, 6)",
            "(4, 6)",
            "(2, 4)",
            "(6, 8)",
            QuestionOption.A,
            "Midpoint = ((-2+6)/2, (4+8)/2) = (2, 6).",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Solving Problems Using Midpoint Formula",
            "What is the midpoint of (3, -1) and (7, 5)?",
            "(5, 2)",
            "(4, 2)",
            "(5, 3)",
            "(10, 4)",
            QuestionOption.A,
            "Midpoint = ((3+7)/2, (-1+5)/2) = (5, 2).",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Solving Problems Using Midpoint Formula",
            "If the midpoint of two points is (0, 0), which statement could be true?",
            "The points are (2, 2) and (-2, -2).",
            "The points are (1, 1) and (2, 2).",
            "The points are (0, 3) and (0, 4).",
            "The points are (5, 0) and (6, 0).",
            QuestionOption.A,
            "The average of the x-coordinates and y-coordinates is 0 for the points (2,2) and (-2,-2).",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Solving Problems Using Midpoint Formula",
            "When solving midpoint problems, what mathematical operation is always performed?",
            "Multiplication",
            "Division by 2 after adding corresponding coordinates",
            "Subtraction only",
            "Squaring each coordinate",
            QuestionOption.B,
            "The midpoint is found by adding corresponding coordinates and dividing each sum by 2.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Midpoint Formula
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Midpoint Formula",
            "The midpoint formula can be used to:",
            "Find the center point between two locations",
            "Calculate the area of a circle",
            "Multiply two matrices",
            "Find the perimeter of a triangle",
            QuestionOption.A,
            "The midpoint formula helps locate the point exactly halfway between two positions.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Midpoint Formula",
            "Architects and engineers often use the midpoint formula to:",
            "Determine the center of structures and designs",
            "Measure temperature",
            "Calculate percentages",
            "Convert units",
            QuestionOption.A,
            "Finding exact center points is important when designing balanced structures.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Midpoint Formula",
            "In computer graphics, the midpoint formula is useful for:",
            "Finding the center between two points on a screen",
            "Compressing files",
            "Connecting to networks",
            "Increasing screen brightness",
            QuestionOption.A,
            "Computer graphics use midpoint calculations for drawing and positioning objects.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Midpoint Formula",
            "If two endpoints of a road are known, the midpoint represents:",
            "The halfway point between the endpoints",
            "The total length of the road",
            "The slope of the road",
            "The highest point on the road",
            QuestionOption.A,
            "The midpoint identifies the location exactly halfway between the two endpoints.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Midpoint Formula",
            "Why is the midpoint formula important in mathematics and real-world applications?",
            "It accurately identifies the center point between two coordinates for analysis and design.",
            "It only works for horizontal lines.",
            "It replaces the distance formula.",
            "It is only useful in classroom exercises.",
            QuestionOption.A,
            "The midpoint formula is widely used in geometry, engineering, mapping, computer graphics, and construction to determine central positions.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Section Formula
        // ==========================================================

        AddQuestion(
            "Introduction to Section Formula",
            "What is the purpose of the section formula?",
            "To calculate the distance between two points",
            "To find a point that divides a line segment in a given ratio",
            "To determine the slope of a line",
            "To find the midpoint of a circle",
            QuestionOption.B,
            "The section formula is used to determine the coordinates of a point dividing a line segment in a specified ratio.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Section Formula",
            "The section formula is mainly used in:",
            "Coordinate geometry",
            "Probability",
            "Statistics",
            "Trigonometry",
            QuestionOption.A,
            "The section formula is an important concept in coordinate geometry.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Section Formula",
            "If a point divides a line segment into two equal parts, it is called the:",
            "Origin",
            "Centroid",
            "Midpoint",
            "Vertex",
            QuestionOption.C,
            "A point dividing a line segment into two equal parts is the midpoint.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Section Formula",
            "A point dividing a line segment in the ratio 2:3 lies:",
            "Exactly at the midpoint",
            "Closer to one endpoint than the other",
            "Outside the line segment",
            "At the origin",
            QuestionOption.B,
            "A ratio other than 1:1 places the point closer to one endpoint.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Section Formula",
            "Why is the section formula useful?",
            "It helps locate points dividing line segments accurately.",
            "It only calculates line lengths.",
            "It only works for horizontal lines.",
            "It replaces the midpoint formula.",
            QuestionOption.A,
            "The section formula accurately determines points dividing line segments in specified ratios.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Solving Problems Using Section Formula
        // ==========================================================

        AddQuestion(
            "Solving Problems Using Section Formula",
            "The midpoint formula is a special case of the section formula when the ratio is:",
            "1 : 1",
            "1 : 2",
            "2 : 3",
            "3 : 1",
            QuestionOption.A,
            "When the ratio is 1:1, the section formula gives the midpoint.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Solving Problems Using Section Formula",
            "A point divides a line segment internally in the ratio 3:2. Which ratio is used in the section formula?",
            "3:2",
            "2:3",
            "1:1",
            "5:1",
            QuestionOption.A,
            "The given internal ratio is used directly in the section formula.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Solving Problems Using Section Formula",
            "Which coordinate values are required to apply the section formula?",
            "Only the x-coordinates",
            "Only the y-coordinates",
            "Coordinates of both endpoints",
            "Only the midpoint",
            QuestionOption.C,
            "The coordinates of both endpoints are needed to calculate the required point.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Solving Problems Using Section Formula",
            "If a point divides a line segment internally in the ratio 1:1, the result is:",
            "The origin",
            "The midpoint",
            "The distance",
            "The slope",
            QuestionOption.B,
            "A ratio of 1:1 always gives the midpoint of the segment.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Solving Problems Using Section Formula",
            "The section formula is most useful when:",
            "A point divides a line segment in a known ratio",
            "Only the length of a line is required",
            "Finding the area of a rectangle",
            "Calculating percentages",
            QuestionOption.A,
            "The section formula is specifically designed to locate dividing points on a line segment.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Section Formula
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Section Formula",
            "The section formula is commonly applied in:",
            "Coordinate geometry",
            "Cooking recipes",
            "Grammar exercises",
            "Music notation",
            QuestionOption.A,
            "Coordinate geometry frequently uses the section formula to locate points.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Section Formula",
            "Surveyors may use the section formula to:",
            "Locate points dividing measured land into specific ratios",
            "Measure temperature",
            "Calculate electricity usage",
            "Find rainfall",
            QuestionOption.A,
            "Surveying often requires dividing measured distances accurately.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Section Formula",
            "Computer graphics use the section formula to:",
            "Position objects proportionally between two points",
            "Increase screen brightness",
            "Store files",
            "Play animations",
            QuestionOption.A,
            "Graphics software often calculates intermediate positions using coordinate geometry.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Section Formula",
            "The section formula helps engineers by:",
            "Finding precise positions along structures and designs",
            "Calculating sound volume",
            "Measuring humidity",
            "Finding internet speed",
            QuestionOption.A,
            "Engineers use coordinate geometry to locate precise design points.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Section Formula",
            "Why is the section formula important in mathematics and engineering?",
            "It accurately determines points that divide line segments in specified ratios.",
            "It only works for vertical lines.",
            "It replaces the distance formula.",
            "It is only useful in classroom examples.",
            QuestionOption.A,
            "The section formula has practical applications in geometry, engineering, mapping, construction, and computer graphics where proportional division is required.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Straight Line
        // ==========================================================

        AddQuestion(
            "Introduction to Straight Line",
            "What is a straight line?",
            "A curve with no fixed direction",
            "The shortest distance between two points",
            "A closed geometric shape",
            "A circle passing through two points",
            QuestionOption.B,
            "A straight line represents the shortest distance between two points and extends infinitely in both directions.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Straight Line",
            "Which equation is in the slope-intercept form of a straight line?",
            "x² + y² = 1",
            "y = mx + c",
            "ax² + bx + c = 0",
            "x + y² = 5",
            QuestionOption.B,
            "The equation y = mx + c represents a straight line where m is the slope and c is the y-intercept.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Straight Line",
            "What does the slope (m) of a straight line represent?",
            "Its area",
            "Its length",
            "Its steepness and direction",
            "Its midpoint",
            QuestionOption.C,
            "The slope describes how steep a line is and whether it rises or falls.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Straight Line",
            "What is the y-intercept of the line y = 3x + 4?",
            "3",
            "4",
            "7",
            "0",
            QuestionOption.B,
            "The y-intercept is the value of y when x = 0, which is 4.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Straight Line",
            "Why are straight lines important in mathematics?",
            "They help model linear relationships between quantities.",
            "They are only used to draw graphs.",
            "They can only represent horizontal lines.",
            "They replace all other geometric figures.",
            QuestionOption.A,
            "Straight lines are fundamental for representing linear relationships in mathematics and science.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Equations and Properties of Straight Lines
        // ==========================================================

        AddQuestion(
            "Equations and Properties of Straight Lines",
            "What is the slope of the line y = 5x + 2?",
            "2",
            "5",
            "7",
            "-5",
            QuestionOption.B,
            "In the equation y = mx + c, the slope is the coefficient of x.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Equations and Properties of Straight Lines",
            "A horizontal line has a slope of:",
            "1",
            "0",
            "Undefined",
            "-1",
            QuestionOption.B,
            "A horizontal line has no vertical change, so its slope is 0.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Equations and Properties of Straight Lines",
            "A vertical line has a slope that is:",
            "0",
            "1",
            "Undefined",
            "-1",
            QuestionOption.C,
            "Since the horizontal change is zero, the slope of a vertical line is undefined.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Straight Lines",
            "Two lines with the same slope are:",
            "Perpendicular",
            "Parallel",
            "Intersecting at the origin",
            "Always identical",
            QuestionOption.B,
            "Lines having the same slope are parallel if they have different intercepts.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Straight Lines",
            "Which point lies on the line y = 2x + 1?",
            "(1, 2)",
            "(2, 4)",
            "(2, 5)",
            "(3, 8)",
            QuestionOption.C,
            "Substituting x = 2 gives y = 2(2) + 1 = 5, so (2,5) lies on the line.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Straight Lines
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Straight Lines",
            "Straight line graphs are commonly used to represent:",
            "Linear relationships between variables",
            "Circular motion only",
            "Random shapes",
            "Three-dimensional objects",
            QuestionOption.A,
            "Straight lines are used to represent linear relationships between two quantities.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Straight Lines",
            "Which profession commonly uses straight line graphs for data analysis?",
            "Engineers",
            "Painters",
            "Musicians",
            "Photographers",
            QuestionOption.A,
            "Engineers frequently use straight-line graphs to analyze measurements and trends.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Straight Lines",
            "In economics, a straight line graph can represent:",
            "The relationship between cost and quantity",
            "The phases of the moon",
            "The colour of products",
            "The shape of planets",
            QuestionOption.A,
            "Many economic relationships, such as fixed-rate costs, can be represented using straight lines.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Straight Lines",
            "A positive slope indicates that the line:",
            "Falls from left to right",
            "Rises from left to right",
            "Is horizontal",
            "Is vertical",
            QuestionOption.B,
            "A positive slope means y increases as x increases.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Straight Lines",
            "Why are straight lines important in science and engineering?",
            "They help model, analyze, and predict relationships between measurable quantities.",
            "They are only useful in geometry classes.",
            "They replace all mathematical formulas.",
            "They are only used for drawing graphs.",
            QuestionOption.A,
            "Straight lines are widely used to model physical laws, engineering designs, and data trends.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Pair of Straight Lines
        // ==========================================================

        AddQuestion(
            "Introduction to Pair of Straight Lines",
            "What is meant by a pair of straight lines?",
            "A single line passing through two points",
            "Two straight lines represented together by one equation",
            "Two parallel curves",
            "A line segment and a ray",
            QuestionOption.B,
            "A pair of straight lines consists of two straight lines that can be represented together by a single equation.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Pair of Straight Lines",
            "A pair of straight lines may be:",
            "Only parallel",
            "Only perpendicular",
            "Intersecting or parallel",
            "Always coincident",
            QuestionOption.C,
            "A pair of straight lines can intersect, be parallel, or even coincide depending on the equation.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Pair of Straight Lines",
            "Where do two intersecting straight lines meet?",
            "At exactly one point",
            "At two points",
            "They never meet",
            "At infinitely many points",
            QuestionOption.A,
            "Intersecting lines meet at one unique point.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Pair of Straight Lines",
            "If two straight lines never meet, they are called:",
            "Perpendicular lines",
            "Intersecting lines",
            "Parallel lines",
            "Coincident lines",
            QuestionOption.C,
            "Parallel lines remain the same distance apart and never intersect.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Pair of Straight Lines",
            "Why are pairs of straight lines important in coordinate geometry?",
            "They help analyze relationships between two lines on a plane.",
            "They are only used for drawing graphs.",
            "They replace quadratic equations.",
            "They are only useful in statistics.",
            QuestionOption.A,
            "Studying pairs of straight lines helps understand intersections, angles, and geometric relationships.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Equations and Properties of Pair of Straight Lines
        // ==========================================================

        AddQuestion(
            "Equations and Properties of Pair of Straight Lines",
            "Two lines having the same slope are:",
            "Perpendicular",
            "Parallel",
            "Intersecting",
            "Coincident with the x-axis",
            QuestionOption.B,
            "Lines with equal slopes are parallel if they have different intercepts.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Equations and Properties of Pair of Straight Lines",
            "Perpendicular lines intersect at an angle of:",
            "45°",
            "60°",
            "90°",
            "180°",
            QuestionOption.C,
            "Perpendicular lines always meet at a right angle of 90°.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Equations and Properties of Pair of Straight Lines",
            "If two lines intersect, they have:",
            "Exactly one common point",
            "No common points",
            "Infinitely many common points",
            "Exactly two common points",
            QuestionOption.A,
            "Intersecting lines always meet at one point.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Pair of Straight Lines",
            "Coincident lines are lines that:",
            "Never meet",
            "Meet at one point",
            "Lie exactly on top of each other",
            "Are always perpendicular",
            QuestionOption.C,
            "Coincident lines overlap completely and share every point.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Pair of Straight Lines",
            "Which property is true for parallel lines?",
            "They intersect at one point.",
            "They have equal slopes.",
            "They always pass through the origin.",
            "They form a right angle.",
            QuestionOption.B,
            "Parallel lines have the same slope and never intersect.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Pair of Straight Lines
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Pair of Straight Lines",
            "Pairs of straight lines are commonly used in:",
            "Coordinate geometry",
            "Cooking",
            "Poetry",
            "Music theory",
            QuestionOption.A,
            "Coordinate geometry studies the relationships between straight lines on a plane.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Pair of Straight Lines",
            "Road intersections can be modeled using:",
            "Parallel circles",
            "Intersecting straight lines",
            "Random curves",
            "Triangles only",
            QuestionOption.B,
            "Roads crossing each other can be represented by intersecting straight lines.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Pair of Straight Lines",
            "Railway tracks are often represented by which type of pair of lines?",
            "Perpendicular lines",
            "Parallel lines",
            "Coincident lines",
            "Curved lines",
            QuestionOption.B,
            "Railway tracks remain at a constant distance from each other and are modeled as parallel lines.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Pair of Straight Lines",
            "Architects use pairs of straight lines mainly to:",
            "Design walls, beams, and layouts accurately",
            "Measure rainfall",
            "Predict earthquakes",
            "Calculate probabilities",
            QuestionOption.A,
            "Buildings and structures are designed using geometric relationships between straight lines.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Pair of Straight Lines",
            "Why is the study of pairs of straight lines important?",
            "It helps solve geometric, engineering, and graphical problems involving relationships between lines.",
            "It is only useful for drawing graphs.",
            "It replaces the distance formula.",
            "It is only used in classroom activities.",
            QuestionOption.A,
            "Understanding how two lines relate helps solve many real-world problems in engineering, architecture, mapping, and mathematics.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Circle in Coordinate Geometry
        // ==========================================================

        AddQuestion(
            "Introduction to Circle in Coordinate Geometry",
            "What is a circle in coordinate geometry?",
            "A polygon with equal sides",
            "A set of points equidistant from a fixed point",
            "A straight line joining two points",
            "A curved line with two centers",
            QuestionOption.B,
            "A circle is the set of all points that are at the same distance (radius) from a fixed point called the center.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Circle in Coordinate Geometry",
            "What is the fixed point of a circle called?",
            "Radius",
            "Diameter",
            "Center",
            "Chord",
            QuestionOption.C,
            "Every point on a circle is equally distant from its center.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Circle in Coordinate Geometry",
            "What is the distance from the center of a circle to any point on the circle called?",
            "Diameter",
            "Radius",
            "Chord",
            "Circumference",
            QuestionOption.B,
            "The radius is the constant distance from the center to any point on the circle.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Circle in Coordinate Geometry",
            "Which of the following is the standard equation of a circle with center (h, k) and radius r?",
            "x² + y² = r",
            "(x - h)² + (y - k)² = r²",
            "y = mx + c",
            "ax² + bx + c = 0",
            QuestionOption.B,
            "The standard equation of a circle is (x - h)² + (y - k)² = r².",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Circle in Coordinate Geometry",
            "Why is the equation of a circle important?",
            "It helps locate and analyze circles on the coordinate plane.",
            "It is only used to calculate perimeter.",
            "It replaces all geometric formulas.",
            "It is only useful for drawing.",
            QuestionOption.A,
            "The equation allows us to determine the center, radius, and other properties of a circle.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Equations and Properties of Circle
        // ==========================================================

        AddQuestion(
            "Equations and Properties of Circle",
            "What is the center of the circle x² + y² = 25?",
            "(5, 5)",
            "(0, 0)",
            "(25, 0)",
            "(0, 25)",
            QuestionOption.B,
            "The equation x² + y² = 25 represents a circle centered at the origin.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Equations and Properties of Circle",
            "What is the radius of the circle x² + y² = 49?",
            "49",
            "24.5",
            "7",
            "14",
            QuestionOption.C,
            "Since r² = 49, the radius is 7.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Equations and Properties of Circle",
            "The center of the circle (x - 3)² + (y + 2)² = 16 is:",
            "(3, -2)",
            "(-3, 2)",
            "(3, 2)",
            "(-3, -2)",
            QuestionOption.A,
            "The center is (h, k), so here it is (3, -2).",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Circle",
            "The radius of the circle (x - 1)² + (y - 4)² = 36 is:",
            "3",
            "6",
            "12",
            "36",
            QuestionOption.B,
            "Since r² = 36, the radius is 6.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Circle",
            "Which property is true for every circle?",
            "All radii are equal.",
            "All diameters are different.",
            "Every chord passes through the center.",
            "A circle has four sides.",
            QuestionOption.A,
            "Every radius of a circle has the same length.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Circle
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Circle",
            "Circles are commonly used in:",
            "Wheel design",
            "Writing essays",
            "Sorting numbers",
            "Reading books",
            QuestionOption.A,
            "Wheels, gears, and many mechanical components are circular in shape.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Circle",
            "GPS coverage around a fixed location is often represented using:",
            "A triangle",
            "A square",
            "A circle",
            "A rectangle",
            QuestionOption.C,
            "A fixed distance from a central point forms a circular region.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Circle",
            "In engineering, circle equations help in:",
            "Designing circular structures and machine parts",
            "Writing software documentation",
            "Sorting databases",
            "Managing emails",
            QuestionOption.A,
            "Many engineering designs involve circular objects and require circle equations.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Circle",
            "Which real-world object is best represented by a circle in coordinate geometry?",
            "A bicycle wheel",
            "A notebook",
            "A television",
            "A ruler",
            QuestionOption.A,
            "A bicycle wheel closely resembles a perfect circle.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Circle",
            "Why is the study of circles important in mathematics and science?",
            "It helps model circular objects, motion, and geometric relationships accurately.",
            "It only helps in drawing diagrams.",
            "It replaces straight-line equations.",
            "It is only useful for examinations.",
            QuestionOption.A,
            "Circle equations are widely used in physics, engineering, architecture, navigation, and computer graphics.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Parabola in Coordinate Geometry
        // ==========================================================

        AddQuestion(
            "Introduction to Parabola in Coordinate Geometry",
            "What is a parabola?",
            "A closed circular curve",
            "A set of points equidistant from a fixed point and a fixed line",
            "A straight line",
            "A polygon with four sides",
            QuestionOption.B,
            "A parabola is the set of all points that are equidistant from a fixed point (focus) and a fixed line (directrix).",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Parabola in Coordinate Geometry",
            "What is the fixed point of a parabola called?",
            "Vertex",
            "Center",
            "Focus",
            "Radius",
            QuestionOption.C,
            "The fixed point used to define a parabola is called the focus.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Parabola in Coordinate Geometry",
            "What is the fixed line associated with a parabola called?",
            "Axis",
            "Diameter",
            "Directrix",
            "Chord",
            QuestionOption.C,
            "The directrix is the fixed line used in the definition of a parabola.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Parabola in Coordinate Geometry",
            "The point where a parabola changes direction is called the:",
            "Focus",
            "Vertex",
            "Origin",
            "Intercept",
            QuestionOption.B,
            "The vertex is the turning point of a parabola.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Parabola in Coordinate Geometry",
            "Why are parabolas important in coordinate geometry?",
            "They help model curved paths and reflective surfaces.",
            "They only represent circles.",
            "They replace straight lines.",
            "They are only used for classroom exercises.",
            QuestionOption.A,
            "Parabolas are widely used to model projectile motion, satellite dishes, and reflective surfaces.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Equations and Properties of Parabola
        // ==========================================================

        AddQuestion(
            "Equations and Properties of Parabola",
            "Which of the following is the standard equation of a parabola opening to the right?",
            "x² = 4ay",
            "y² = 4ax",
            "x² + y² = r²",
            "y = mx + c",
            QuestionOption.B,
            "The standard equation of a parabola opening to the right is y² = 4ax.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Equations and Properties of Parabola",
            "The graph of x² = 4ay opens:",
            "Left and right",
            "Upward or downward",
            "In all directions",
            "As a straight line",
            QuestionOption.B,
            "The equation x² = 4ay represents a parabola opening upward if a > 0 and downward if a < 0.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Equations and Properties of Parabola",
            "Every parabola has:",
            "One focus and one directrix",
            "Two centers",
            "Two radii",
            "Four vertices",
            QuestionOption.A,
            "A parabola is uniquely defined by one focus and one directrix.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Parabola",
            "The axis of symmetry of a parabola:",
            "Divides the parabola into two equal halves",
            "Is always horizontal",
            "Is always vertical",
            "Does not pass through the vertex",
            QuestionOption.A,
            "The axis of symmetry passes through the vertex and divides the parabola into two mirror-image halves.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Parabola",
            "Which statement is true for every parabola?",
            "It has exactly one vertex.",
            "It has two centers.",
            "It is a closed curve.",
            "It always forms a circle.",
            QuestionOption.A,
            "Every parabola has exactly one vertex, which is its turning point.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Parabola
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Parabola",
            "The path of a ball thrown into the air is approximately:",
            "A straight line",
            "A circle",
            "A parabola",
            "A rectangle",
            QuestionOption.C,
            "Ignoring air resistance, projectile motion follows a parabolic path.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Parabola",
            "Satellite dishes are designed using the shape of a:",
            "Circle",
            "Triangle",
            "Parabola",
            "Rectangle",
            QuestionOption.C,
            "Parabolic reflectors focus incoming signals at a single point called the focus.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Parabola",
            "Car headlights commonly use parabolic reflectors because they:",
            "Scatter light in every direction",
            "Focus light into a strong beam",
            "Reduce battery usage",
            "Make the bulb brighter",
            QuestionOption.B,
            "A parabolic reflector directs light rays into a nearly parallel beam.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Parabola",
            "Parabolas are commonly used in which field?",
            "Engineering and physics",
            "Cooking",
            "Music composition",
            "Language translation",
            QuestionOption.A,
            "Parabolas are widely used in engineering, architecture, physics, and communication systems.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Parabola",
            "Why are parabolas important in science and technology?",
            "They accurately model curved motion and reflective surfaces used in many real-world applications.",
            "They only help draw graphs.",
            "They replace circle equations.",
            "They are only useful in mathematics classrooms.",
            QuestionOption.A,
            "Parabolas are fundamental in projectile motion, satellite communication, optics, and engineering design.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Ellipse in Coordinate Geometry
        // ==========================================================

        AddQuestion(
            "Introduction to Ellipse in Coordinate Geometry",
            "What is an ellipse?",
            "A closed curve where the sum of the distances from any point to two fixed points is constant",
            "A circle with two centers",
            "A straight line",
            "A polygon with four sides",
            QuestionOption.A,
            "An ellipse is the set of all points for which the sum of the distances from two fixed points (foci) remains constant.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Ellipse in Coordinate Geometry",
            "The two fixed points of an ellipse are called:",
            "Vertices",
            "Centers",
            "Foci",
            "Axes",
            QuestionOption.C,
            "The fixed points used to define an ellipse are called the foci.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Ellipse in Coordinate Geometry",
            "Which axis of an ellipse is the longest?",
            "Minor axis",
            "Major axis",
            "Vertical axis",
            "Horizontal axis",
            QuestionOption.B,
            "The major axis is the longest diameter of an ellipse.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Ellipse in Coordinate Geometry",
            "What is the center of an ellipse?",
            "The midpoint of its major and minor axes",
            "One of its foci",
            "The highest point",
            "The point where it touches the x-axis",
            QuestionOption.A,
            "The center is the midpoint where the major and minor axes intersect.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Ellipse in Coordinate Geometry",
            "Why are ellipses important in coordinate geometry?",
            "They help model many natural and engineered shapes.",
            "They only represent circles.",
            "They replace straight lines.",
            "They are only used in examinations.",
            QuestionOption.A,
            "Ellipses are widely used in mathematics, astronomy, engineering, and design.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Equations and Properties of Ellipse
        // ==========================================================

        AddQuestion(
            "Equations and Properties of Ellipse",
            "Which is the standard equation of an ellipse centered at the origin?",
            "x² + y² = r²",
            "x²/a² + y²/b² = 1",
            "y = mx + c",
            "x² = 4ay",
            QuestionOption.B,
            "The standard equation of an ellipse centered at the origin is x²/a² + y²/b² = 1.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Equations and Properties of Ellipse",
            "If a > b in the equation x²/a² + y²/b² = 1, the major axis is:",
            "Vertical",
            "Horizontal",
            "Diagonal",
            "Undefined",
            QuestionOption.B,
            "When a > b, the major axis lies along the x-axis.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Equations and Properties of Ellipse",
            "An ellipse has:",
            "One focus",
            "Two foci",
            "Three foci",
            "No focus",
            QuestionOption.B,
            "Every ellipse has two fixed points called foci.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Ellipse",
            "The major axis of an ellipse always passes through the:",
            "Radius",
            "Center",
            "Circumference",
            "Directrix",
            QuestionOption.B,
            "Both the major and minor axes pass through the center of the ellipse.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Ellipse",
            "Which statement is true for every ellipse?",
            "It is a closed curve.",
            "It has four vertices only.",
            "It always forms a circle.",
            "Its major and minor axes are always equal.",
            QuestionOption.A,
            "An ellipse is always a closed curve surrounding a region.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Ellipse
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Ellipse",
            "The orbits of many planets around the Sun are approximately:",
            "Circular",
            "Elliptical",
            "Rectangular",
            "Triangular",
            QuestionOption.B,
            "According to Kepler's First Law, planets move in elliptical orbits.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Ellipse",
            "Ellipses are commonly used in:",
            "Astronomy",
            "Cooking",
            "Poetry",
            "Music theory",
            QuestionOption.A,
            "Astronomy uses ellipses to describe planetary and satellite orbits.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Ellipse",
            "Architects may use elliptical shapes because they:",
            "Provide attractive and efficient designs",
            "Replace all straight lines",
            "Always require less material",
            "Can only be drawn by computers",
            QuestionOption.A,
            "Elliptical shapes are widely used in architecture for both aesthetics and structural design.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Ellipse",
            "Which field commonly uses ellipses to study the motion of celestial bodies?",
            "Astronomy",
            "Biology",
            "History",
            "Chemistry",
            QuestionOption.A,
            "Astronomy uses ellipses extensively to describe orbital motion.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Ellipse",
            "Why are ellipses important in mathematics and science?",
            "They model planetary motion, engineering designs, and many natural phenomena.",
            "They only help draw graphs.",
            "They replace circle equations.",
            "They are only useful in geometry classes.",
            QuestionOption.A,
            "Ellipses are fundamental in astronomy, engineering, architecture, optics, and many areas of applied mathematics.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Probability
        // ==========================================================

        AddQuestion(
            "Introduction to Probability",
            "What is probability?",
            "The study of geometric shapes",
            "A measure of how likely an event is to occur",
            "A method of solving equations",
            "The study of numbers only",
            QuestionOption.B,
            "Probability measures the chance that a particular event will happen.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Probability",
            "What is the probability of a certain event?",
            "0",
            "1",
            "0.5",
            "2",
            QuestionOption.B,
            "A certain event always occurs, so its probability is 1.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Probability",
            "What is the probability of an impossible event?",
            "0",
            "1",
            "0.5",
            "-1",
            QuestionOption.A,
            "An impossible event can never occur, so its probability is 0.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Probability",
            "The probability of any event always lies between:",
            "0 and 1",
            "1 and 10",
            "-1 and 1",
            "0 and 100",
            QuestionOption.A,
            "Probability values range from 0 (impossible) to 1 (certain).",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Probability",
            "Why is probability important?",
            "It helps predict and analyze uncertain events.",
            "It only solves algebraic equations.",
            "It is only used in gambling.",
            "It replaces arithmetic.",
            QuestionOption.A,
            "Probability is widely used to make informed decisions under uncertainty.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Basic Probability Rules
        // ==========================================================

        AddQuestion(
            "Basic Probability Rules",
            "What is the probability of getting a head when tossing a fair coin?",
            "1/4",
            "1/2",
            "1",
            "2",
            QuestionOption.B,
            "A fair coin has two equally likely outcomes, so the probability of heads is 1/2.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Basic Probability Rules",
            "What is the probability of rolling a 4 on a fair six-sided die?",
            "1/4",
            "1/5",
            "1/6",
            "1/3",
            QuestionOption.C,
            "There is one favorable outcome out of six equally likely outcomes.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Basic Probability Rules",
            "If an event has probability 0.3, what is the probability that it does not occur?",
            "0.3",
            "0.5",
            "0.7",
            "1.3",
            QuestionOption.C,
            "The probability of the complement is 1 - 0.3 = 0.7.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Basic Probability Rules",
            "When two events cannot happen at the same time, they are called:",
            "Independent events",
            "Mutually exclusive events",
            "Dependent events",
            "Certain events",
            QuestionOption.B,
            "Mutually exclusive events cannot occur simultaneously.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Basic Probability Rules",
            "The sum of the probabilities of all possible outcomes of an experiment is:",
            "0",
            "1",
            "10",
            "100",
            QuestionOption.B,
            "The probabilities of all possible outcomes always add up to 1.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Probability
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Probability",
            "Weather forecasting commonly uses:",
            "Probability",
            "Geometry",
            "Calculus only",
            "Trigonometry only",
            QuestionOption.A,
            "Meteorologists use probability to predict the likelihood of weather events.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Probability",
            "Insurance companies use probability to:",
            "Assess risks",
            "Draw geometric figures",
            "Measure distances",
            "Find square roots",
            QuestionOption.A,
            "Insurance companies estimate the likelihood of events to determine premiums.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Probability",
            "Which field uses probability to analyze data and make predictions?",
            "Statistics",
            "Grammar",
            "Painting",
            "Music",
            QuestionOption.A,
            "Statistics relies heavily on probability to interpret data and predict outcomes.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Probability",
            "Probability is useful in games because it helps:",
            "Estimate the chances of different outcomes",
            "Guarantee winning",
            "Change the rules",
            "Remove uncertainty",
            QuestionOption.A,
            "Probability helps players understand the likelihood of different results but does not guarantee outcomes.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Probability",
            "Why is probability important in everyday life?",
            "It helps people make informed decisions when outcomes are uncertain.",
            "It eliminates uncertainty completely.",
            "It only applies to mathematics exams.",
            "It replaces logical reasoning.",
            QuestionOption.A,
            "Probability supports decision-making in science, medicine, finance, engineering, business, and daily life whenever uncertainty exists.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Conic Sections
        // ==========================================================

        AddQuestion(
            "Introduction to Conic Sections",
            "What are conic sections?",
            "Curves formed by the intersection of a plane and a cone",
            "Straight lines drawn on a plane",
            "Closed polygons with equal sides",
            "Three-dimensional solids",
            QuestionOption.A,
            "Conic sections are curves obtained when a plane intersects a double cone.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Conic Sections",
            "Which of the following is NOT a conic section?",
            "Circle",
            "Ellipse",
            "Rectangle",
            "Hyperbola",
            QuestionOption.C,
            "The four conic sections are circle, parabola, ellipse, and hyperbola.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Conic Sections",
            "Which conic section is formed when the plane cuts the cone parallel to its base?",
            "Parabola",
            "Circle",
            "Ellipse",
            "Hyperbola",
            QuestionOption.B,
            "A circle is formed when the cutting plane is parallel to the base of the cone.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Conic Sections",
            "How many basic conic sections are there?",
            "Two",
            "Three",
            "Four",
            "Five",
            QuestionOption.C,
            "The four basic conic sections are the circle, parabola, ellipse, and hyperbola.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Conic Sections",
            "Why are conic sections important?",
            "They help describe many natural and engineered curves.",
            "They are only useful for drawing graphs.",
            "They replace algebra completely.",
            "They are only used in geometry exams.",
            QuestionOption.A,
            "Conic sections are widely used in mathematics, engineering, astronomy, and physics.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Equations and Properties of Conic Sections
        // ==========================================================

        AddQuestion(
            "Equations and Properties of Conic Sections",
            "Which equation represents a circle centered at the origin?",
            "x² + y² = r²",
            "y² = 4ax",
            "x²/a² + y²/b² = 1",
            "x²/a² - y²/b² = 1",
            QuestionOption.A,
            "The equation x² + y² = r² represents a circle centered at the origin.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Equations and Properties of Conic Sections",
            "Which conic section has exactly one focus?",
            "Circle",
            "Ellipse",
            "Parabola",
            "Hyperbola",
            QuestionOption.C,
            "A parabola has one focus and one directrix.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Equations and Properties of Conic Sections",
            "Which conic section has two branches?",
            "Circle",
            "Parabola",
            "Ellipse",
            "Hyperbola",
            QuestionOption.D,
            "A hyperbola consists of two separate branches.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Conic Sections",
            "Which conic section has two foci?",
            "Ellipse and Hyperbola",
            "Circle only",
            "Parabola only",
            "Circle and Parabola",
            QuestionOption.A,
            "Both ellipses and hyperbolas have two foci.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Conic Sections",
            "Which statement is true about all conic sections?",
            "They are obtained by intersecting a plane with a cone.",
            "They are all closed curves.",
            "They all have two foci.",
            "They all have the same equation.",
            QuestionOption.A,
            "Every conic section is formed by slicing a cone with a plane at different angles.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Conic Sections
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Conic Sections",
            "Which field commonly uses conic sections to describe planetary motion?",
            "Astronomy",
            "History",
            "Grammar",
            "Biology",
            QuestionOption.A,
            "Planetary orbits are commonly modeled using conic sections, especially ellipses.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Conic Sections",
            "Satellite dishes are based primarily on which conic section?",
            "Circle",
            "Parabola",
            "Ellipse",
            "Hyperbola",
            QuestionOption.B,
            "Satellite dishes use the reflective property of parabolas to focus signals.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Conic Sections",
            "Which profession commonly uses conic sections when designing bridges, roads, and structures?",
            "Engineers",
            "Musicians",
            "Writers",
            "Chefs",
            QuestionOption.A,
            "Engineers use conic sections extensively in design and structural analysis.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Conic Sections",
            "Which technology relies on the reflective properties of parabolas?",
            "Satellite communication",
            "Word processing",
            "Spreadsheet software",
            "Text messaging",
            QuestionOption.A,
            "Parabolic reflectors are widely used in antennas, satellite dishes, and telescopes.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Conic Sections",
            "Why are conic sections important in mathematics and science?",
            "They model many natural phenomena and are widely used in engineering, astronomy, optics, and architecture.",
            "They are only useful for classroom exercises.",
            "They replace all other geometry concepts.",
            "They are only used to draw graphs.",
            QuestionOption.A,
            "Conic sections have numerous practical applications in science, engineering, physics, navigation, and technology.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Trigonometric Ratios
        // ==========================================================

        AddQuestion(
            "Introduction to Trigonometric Ratios",
            "What are trigonometric ratios used for?",
            "To measure probability",
            "To relate the angles and sides of a right-angled triangle",
            "To calculate the area of circles",
            "To solve quadratic equations",
            QuestionOption.B,
            "Trigonometric ratios describe the relationship between the sides and angles of a right-angled triangle.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Trigonometric Ratios",
            "Which trigonometric ratio is defined as opposite side divided by hypotenuse?",
            "Cosine",
            "Tangent",
            "Sine",
            "Cotangent",
            QuestionOption.C,
            "The sine of an angle is the ratio of the opposite side to the hypotenuse.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Trigonometric Ratios",
            "Which side of a right triangle is always the longest?",
            "Adjacent side",
            "Opposite side",
            "Hypotenuse",
            "Base",
            QuestionOption.C,
            "The hypotenuse is opposite the right angle and is always the longest side.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Trigonometric Ratios",
            "Which trigonometric ratio is equal to adjacent side divided by hypotenuse?",
            "Sine",
            "Cosine",
            "Tangent",
            "Secant",
            QuestionOption.B,
            "Cosine is defined as adjacent divided by hypotenuse.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Trigonometric Ratios",
            "Why are trigonometric ratios important?",
            "They help determine unknown sides and angles in right triangles.",
            "They are only useful for drawing graphs.",
            "They replace algebra completely.",
            "They are only used in geometry exams.",
            QuestionOption.A,
            "Trigonometric ratios are fundamental for solving problems involving right-angled triangles.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Understanding and Solving Trigonometric Ratios
        // ==========================================================

        AddQuestion(
            "Understanding and Solving Trigonometric Ratios",
            "The tangent of an angle is equal to:",
            "Opposite ÷ Hypotenuse",
            "Adjacent ÷ Hypotenuse",
            "Opposite ÷ Adjacent",
            "Hypotenuse ÷ Opposite",
            QuestionOption.C,
            "Tangent is the ratio of the opposite side to the adjacent side.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Understanding and Solving Trigonometric Ratios",
            "If the opposite side is 6 units and the hypotenuse is 10 units, what is sin θ?",
            "0.4",
            "0.5",
            "0.6",
            "0.8",
            QuestionOption.C,
            "sin θ = opposite ÷ hypotenuse = 6 ÷ 10 = 0.6.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Understanding and Solving Trigonometric Ratios",
            "If the adjacent side is 8 units and the hypotenuse is 10 units, what is cos θ?",
            "0.6",
            "0.8",
            "1.0",
            "0.2",
            QuestionOption.B,
            "cos θ = adjacent ÷ hypotenuse = 8 ÷ 10 = 0.8.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Understanding and Solving Trigonometric Ratios",
            "If the opposite side is 9 units and the adjacent side is 3 units, what is tan θ?",
            "2",
            "3",
            "4",
            "6",
            QuestionOption.B,
            "tan θ = opposite ÷ adjacent = 9 ÷ 3 = 3.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Understanding and Solving Trigonometric Ratios",
            "Which trigonometric ratio uses only the opposite and adjacent sides?",
            "Sine",
            "Cosine",
            "Tangent",
            "Secant",
            QuestionOption.C,
            "Tangent is calculated using the opposite and adjacent sides only.",
            DifficultyLevel.Advance,
            5);

        // PQ. 4

        // ==========================================================
        // Applications and Practice of Trigonometric Ratios
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Trigonometric Ratios",
            "Trigonometric ratios are commonly used to measure:",
            "Heights and distances",
            "Temperature",
            "Population",
            "Speed only",
            QuestionOption.A,
            "Trigonometry is widely used to calculate heights and distances that cannot be measured directly.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Trigonometric Ratios",
            "Which profession frequently uses trigonometry?",
            "Engineer",
            "Chef",
            "Novelist",
            "Singer",
            QuestionOption.A,
            "Engineers use trigonometry in surveying, construction, and structural design.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Trigonometric Ratios",
            "Navigation systems use trigonometric ratios to:",
            "Determine positions and distances",
            "Write documents",
            "Store files",
            "Create databases",
            QuestionOption.A,
            "Navigation relies on trigonometric calculations to determine locations and routes.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Trigonometric Ratios",
            "In physics, trigonometric ratios help analyze:",
            "Forces and motion",
            "Grammar",
            "Chemical names",
            "Literature",
            QuestionOption.A,
            "Physics uses trigonometry to resolve vectors and analyze motion.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Trigonometric Ratios",
            "Why are trigonometric ratios important in real life?",
            "They help solve practical problems involving heights, distances, engineering, navigation, and science.",
            "They are only useful for classroom exercises.",
            "They replace geometry completely.",
            "They are only used to draw triangles.",
            QuestionOption.A,
            "Trigonometric ratios are essential tools in engineering, architecture, surveying, navigation, physics, and many other real-world applications.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Introduction to Trigonometric Identities
        // ==========================================================

        AddQuestion(
            "Introduction to Trigonometric Identities",
            "What is a trigonometric identity?",
            "An equation true only for specific angles",
            "An equation that is true for all values where it is defined",
            "A formula used only for right triangles",
            "An equation with no solution",
            QuestionOption.B,
            "A trigonometric identity is an equation that holds true for every value of the variable for which both sides are defined.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Trigonometric Identities",
            "Which of the following is a Pythagorean identity?",
            "sin²θ + cos²θ = 1",
            "sinθ + cosθ = 1",
            "tanθ = sinθ + cosθ",
            "secθ = sinθ/cosθ",
            QuestionOption.A,
            "The identity sin²θ + cos²θ = 1 is one of the fundamental Pythagorean identities.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Trigonometric Identities",
            "Which trigonometric function is the reciprocal of cosine?",
            "Cosecant",
            "Cotangent",
            "Secant",
            "Tangent",
            QuestionOption.C,
            "Secant (sec) is the reciprocal of cosine (cos).",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Trigonometric Identities",
            "The quotient identity for tangent is:",
            "tanθ = cosθ/sinθ",
            "tanθ = sinθ/cosθ",
            "tanθ = secθ/cosecθ",
            "tanθ = sin²θ + cos²θ",
            QuestionOption.B,
            "The tangent function is defined as sinθ divided by cosθ.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Trigonometric Identities",
            "Why are trigonometric identities important?",
            "They help simplify expressions and prove mathematical relationships.",
            "They only calculate triangle areas.",
            "They replace trigonometric ratios.",
            "They are only used in geometry.",
            QuestionOption.A,
            "Trigonometric identities simplify calculations and help prove mathematical equations.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Simplifying Expressions Using Trigonometric Identities
        // ==========================================================

        AddQuestion(
            "Simplifying Expressions Using Trigonometric Identities",
            "Using identities, sin²θ + cos²θ is equal to:",
            "0",
            "1",
            "2",
            "sinθ",
            QuestionOption.B,
            "According to the Pythagorean identity, sin²θ + cos²θ = 1.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Simplifying Expressions Using Trigonometric Identities",
            "Which identity expresses sec²θ?",
            "1 + tan²θ",
            "1 - tan²θ",
            "sin²θ + cos²θ",
            "1 + cot²θ",
            QuestionOption.A,
            "The Pythagorean identity states sec²θ = 1 + tan²θ.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Simplifying Expressions Using Trigonometric Identities",
            "Which reciprocal identity is correct?",
            "sinθ = 1/secθ",
            "cosθ = 1/cosecθ",
            "cosecθ = 1/sinθ",
            "tanθ = 1/cosθ",
            QuestionOption.C,
            "Cosecant is the reciprocal of sine.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Simplifying Expressions Using Trigonometric Identities",
            "Which identity helps express cotθ in terms of sine and cosine?",
            "cotθ = sinθ/cosθ",
            "cotθ = cosθ/sinθ",
            "cotθ = secθ/cosecθ",
            "cotθ = sin²θ",
            QuestionOption.B,
            "Cotangent is equal to cosine divided by sine.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Simplifying Expressions Using Trigonometric Identities",
            "The main purpose of trigonometric identities is to:",
            "Simplify expressions and verify equations",
            "Find the area of circles",
            "Measure probability",
            "Convert units",
            QuestionOption.A,
            "Identities make complex trigonometric expressions easier to solve and verify.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Trigonometric Identities
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Trigonometric Identities",
            "Trigonometric identities are widely used in:",
            "Physics",
            "Grammar",
            "Cooking",
            "History",
            QuestionOption.A,
            "Physics frequently uses trigonometric identities in wave and motion analysis.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Trigonometric Identities",
            "Engineers use trigonometric identities mainly to:",
            "Analyze structures and signals",
            "Write essays",
            "Design books",
            "Measure rainfall",
            QuestionOption.A,
            "Engineering applications include structural analysis, electrical signals, and mechanical design.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Trigonometric Identities",
            "Which field commonly applies trigonometric identities to study sound and light waves?",
            "Physics",
            "Literature",
            "Biology",
            "Economics",
            QuestionOption.A,
            "Wave motion in physics is commonly analyzed using trigonometric identities.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Trigonometric Identities",
            "Computer graphics use trigonometric identities to:",
            "Perform rotations and animations",
            "Store files",
            "Compress images only",
            "Manage databases",
            QuestionOption.A,
            "Trigonometric identities are essential for transformations, rotations, and animations in graphics.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Trigonometric Identities",
            "Why are trigonometric identities important in mathematics and science?",
            "They simplify complex calculations and support problem-solving in engineering, physics, and technology.",
            "They are only useful in school examinations.",
            "They replace trigonometric ratios completely.",
            "They are only used to draw graphs.",
            QuestionOption.A,
            "Trigonometric identities are fundamental tools used across mathematics, engineering, computer graphics, navigation, and physics.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Compound Angles
        // ==========================================================

        AddQuestion(
            "Introduction to Compound Angles",
            "What is a compound angle?",
            "An angle greater than 360°",
            "An angle formed by adding or subtracting two angles",
            "An angle equal to 90°",
            "An angle inside a triangle",
            QuestionOption.B,
            "A compound angle is formed by adding or subtracting two angles.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Compound Angles",
            "Which operation is commonly used to form a compound angle?",
            "Multiplication only",
            "Division only",
            "Addition or subtraction",
            "Square root",
            QuestionOption.C,
            "Compound angles are created by adding or subtracting two angles.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Compound Angles",
            "Which trigonometric functions have compound angle formulas?",
            "Only sine",
            "Only cosine",
            "Only tangent",
            "Sine, cosine, and tangent",
            QuestionOption.D,
            "Compound angle formulas exist for sine, cosine, and tangent.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Compound Angles",
            "The formula sin(A + B) is used to:",
            "Find the sine of the sum of two angles",
            "Find the cosine of an angle",
            "Find the tangent of an angle",
            "Calculate the area of a triangle",
            QuestionOption.A,
            "The sine addition formula calculates the sine of the sum of two angles.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Compound Angles",
            "Why are compound angle formulas important?",
            "They simplify trigonometric calculations involving sums and differences of angles.",
            "They only measure triangle areas.",
            "They replace trigonometric identities.",
            "They are only used in geometry.",
            QuestionOption.A,
            "Compound angle formulas are essential for solving many trigonometric problems efficiently.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Solving Problems Using Compound Angle Formulas
        // ==========================================================

        AddQuestion(
            "Solving Problems Using Compound Angle Formulas",
            "Which formula correctly represents sin(A + B)?",
            "sinA cosB + cosA sinB",
            "sinA cosB - cosA sinB",
            "cosA cosB - sinA sinB",
            "tanA + tanB",
            QuestionOption.A,
            "The sine addition formula is sin(A + B) = sinA cosB + cosA sinB.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Solving Problems Using Compound Angle Formulas",
            "Which formula correctly represents cos(A + B)?",
            "cosA cosB + sinA sinB",
            "cosA cosB - sinA sinB",
            "sinA cosB + cosA sinB",
            "tanA tanB",
            QuestionOption.B,
            "The cosine addition formula is cos(A + B) = cosA cosB - sinA sinB.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Solving Problems Using Compound Angle Formulas",
            "Which formula represents tan(A + B)?",
            "(tanA + tanB)/(1 - tanA tanB)",
            "(tanA - tanB)/(1 + tanA tanB)",
            "tanA + tanB",
            "sinA + cosB",
            QuestionOption.A,
            "The tangent addition formula is (tanA + tanB)/(1 - tanA tanB).",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Solving Problems Using Compound Angle Formulas",
            "The formula sin(A - B) differs from sin(A + B) because:",
            "The second term changes from plus to minus",
            "The first term changes sign",
            "Both terms become negative",
            "There is no difference",
            QuestionOption.A,
            "The subtraction formula is sin(A - B) = sinA cosB - cosA sinB.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Solving Problems Using Compound Angle Formulas",
            "Compound angle formulas are mainly used to:",
            "Simplify expressions and solve trigonometric equations",
            "Find square roots",
            "Calculate probability",
            "Convert units",
            QuestionOption.A,
            "These formulas simplify complex trigonometric expressions and aid in solving equations.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Compound Angles
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Compound Angles",
            "Compound angle formulas are commonly used in:",
            "Physics",
            "Grammar",
            "Cooking",
            "History",
            QuestionOption.A,
            "Physics uses compound angle formulas to analyze waves, oscillations, and forces.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Compound Angles",
            "Engineers use compound angle formulas to:",
            "Analyze structures and signals",
            "Write essays",
            "Create paintings",
            "Measure rainfall",
            QuestionOption.A,
            "Engineering applications include structural analysis, electronics, and signal processing.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Compound Angles",
            "Which field commonly uses compound angle formulas to analyze wave motion?",
            "Physics",
            "Literature",
            "Economics",
            "Biology",
            QuestionOption.A,
            "Wave behavior is frequently analyzed using compound angle identities in physics.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Compound Angles",
            "Computer graphics use compound angle formulas for:",
            "Object rotation and animation",
            "Database management",
            "Text formatting",
            "File compression",
            QuestionOption.A,
            "Rotating objects and performing transformations rely on trigonometric formulas.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Compound Angles",
            "Why are compound angle formulas important in mathematics and engineering?",
            "They simplify advanced calculations involving angles and are widely used in science, engineering, and technology.",
            "They are only useful for examinations.",
            "They replace trigonometric identities.",
            "They are only used for drawing graphs.",
            QuestionOption.A,
            "Compound angle formulas are fundamental tools in mathematics, physics, engineering, computer graphics, and signal processing.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Trigonometric Equations
        // ==========================================================

        AddQuestion(
            "Introduction to Trigonometric Equations",
            "What is a trigonometric equation?",
            "An equation containing one or more trigonometric functions",
            "An equation containing only integers",
            "An equation with no variables",
            "An equation involving only logarithms",
            QuestionOption.A,
            "A trigonometric equation contains trigonometric functions such as sine, cosine, or tangent.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Trigonometric Equations",
            "Which of the following is a trigonometric function?",
            "√x",
            "sin x",
            "x²",
            "log x",
            QuestionOption.B,
            "Sine (sin) is one of the six basic trigonometric functions.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Trigonometric Equations",
            "The solution of a trigonometric equation is usually expressed in terms of:",
            "Angles",
            "Areas",
            "Volumes",
            "Lengths only",
            QuestionOption.A,
            "Trigonometric equations are generally solved to find unknown angles.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Trigonometric Equations",
            "Which trigonometric functions commonly appear in trigonometric equations?",
            "Only sine",
            "Only cosine",
            "Sine, cosine, and tangent",
            "Only tangent",
            QuestionOption.C,
            "Most trigonometric equations involve sine, cosine, tangent, or combinations of them.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Trigonometric Equations",
            "Why are trigonometric equations important?",
            "They help solve problems involving angles, waves, and periodic motion.",
            "They are only used for drawing graphs.",
            "They replace algebra completely.",
            "They are only useful in geometry.",
            QuestionOption.A,
            "Trigonometric equations are essential in mathematics, engineering, and physics.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Solving Trigonometric Equations
        // ==========================================================

        AddQuestion(
            "Solving Trigonometric Equations",
            "To solve sin x = 0, the first basic solution is:",
            "0°",
            "45°",
            "60°",
            "90°",
            QuestionOption.A,
            "The sine of 0° is equal to 0.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Solving Trigonometric Equations",
            "To solve cos x = 1, the first basic solution is:",
            "0°",
            "30°",
            "60°",
            "90°",
            QuestionOption.A,
            "The cosine of 0° is equal to 1.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Solving Trigonometric Equations",
            "Which identity is commonly used while solving trigonometric equations?",
            "sin²θ + cos²θ = 1",
            "a² + b² = c²",
            "x² + y² = r²",
            "E = mc²",
            QuestionOption.A,
            "Pythagorean identities are frequently used to simplify trigonometric equations.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Solving Trigonometric Equations",
            "A common first step in solving trigonometric equations is to:",
            "Rewrite the equation using identities",
            "Differentiate the equation",
            "Integrate the equation",
            "Multiply by zero",
            QuestionOption.A,
            "Trigonometric identities often simplify equations into solvable forms.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Solving Trigonometric Equations",
            "The objective of solving a trigonometric equation is to determine:",
            "Unknown angle values",
            "Circle radii only",
            "Triangle areas only",
            "Probability values",
            QuestionOption.A,
            "Solutions to trigonometric equations are the angle values that satisfy the equation.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Trigonometric Equations
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Trigonometric Equations",
            "Trigonometric equations are widely used in:",
            "Physics",
            "Cooking",
            "Grammar",
            "History",
            QuestionOption.A,
            "Physics frequently uses trigonometric equations to model oscillations and waves.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Trigonometric Equations",
            "Engineers use trigonometric equations to:",
            "Analyze structures and signals",
            "Write novels",
            "Paint buildings",
            "Measure rainfall",
            QuestionOption.A,
            "Engineering applications include structural analysis, electronics, and signal processing.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Trigonometric Equations",
            "Wave motion is commonly analyzed using:",
            "Trigonometric equations",
            "Only linear equations",
            "Quadratic equations only",
            "Arithmetic progression",
            QuestionOption.A,
            "Wave behavior is naturally represented by trigonometric equations.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Trigonometric Equations",
            "Computer graphics use trigonometric equations for:",
            "Rotation and animation",
            "Spell checking",
            "Database indexing",
            "Text formatting",
            QuestionOption.A,
            "Object rotation and animation rely heavily on trigonometric calculations.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Trigonometric Equations",
            "Why are trigonometric equations important in mathematics and science?",
            "They model periodic phenomena and solve real-world problems involving angles and waves.",
            "They are only useful in examinations.",
            "They replace algebra.",
            "They are only used to draw triangles.",
            QuestionOption.A,
            "Trigonometric equations are fundamental in engineering, navigation, astronomy, physics, computer graphics, and many scientific applications.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Introduction to Inverse Trigonometric Functions
        // ==========================================================

        AddQuestion(
            "Introduction to Inverse Trigonometric Functions",
            "What is the purpose of an inverse trigonometric function?",
            "To find an angle from a given trigonometric ratio",
            "To calculate the area of a triangle",
            "To measure distances",
            "To simplify algebraic expressions",
            QuestionOption.A,
            "Inverse trigonometric functions determine the angle corresponding to a given trigonometric ratio.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Inverse Trigonometric Functions",
            "Which notation represents the inverse sine function?",
            "sin²x",
            "sin⁻¹x",
            "1/sinx",
            "sinx⁻²",
            QuestionOption.B,
            "The notation sin⁻¹x (also written as arcsin x) represents the inverse sine function.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Inverse Trigonometric Functions",
            "The output of an inverse trigonometric function is usually:",
            "A side length",
            "A ratio",
            "An angle",
            "A coordinate",
            QuestionOption.C,
            "Inverse trigonometric functions return an angle whose trigonometric ratio is given.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Inverse Trigonometric Functions",
            "Why are principal values used in inverse trigonometric functions?",
            "To provide a unique angle for every valid input",
            "To increase the size of angles",
            "To avoid fractions",
            "To simplify multiplication",
            QuestionOption.A,
            "Principal values ensure each inverse trigonometric function has a unique output.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Inverse Trigonometric Functions",
            "Inverse trigonometric functions are most useful for:",
            "Finding unknown angles from known ratios",
            "Drawing circles",
            "Calculating probabilities",
            "Finding square roots",
            QuestionOption.A,
            "They are used whenever an angle must be determined from a trigonometric ratio.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Solving Problems Using Inverse Trigonometric Functions
        // ==========================================================

        AddQuestion(
            "Solving Problems Using Inverse Trigonometric Functions",
            "What is sin⁻¹(0)?",
            "0°",
            "30°",
            "45°",
            "90°",
            QuestionOption.A,
            "Since sin(0°) = 0, the principal value of sin⁻¹(0) is 0°.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Solving Problems Using Inverse Trigonometric Functions",
            "What is cos⁻¹(1)?",
            "0°",
            "45°",
            "60°",
            "90°",
            QuestionOption.A,
            "Since cos(0°) = 1, the principal value of cos⁻¹(1) is 0°.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Solving Problems Using Inverse Trigonometric Functions",
            "What is tan⁻¹(1)?",
            "30°",
            "45°",
            "60°",
            "90°",
            QuestionOption.B,
            "Since tan(45°) = 1, tan⁻¹(1) = 45°.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Solving Problems Using Inverse Trigonometric Functions",
            "Inverse trigonometric functions are commonly used to:",
            "Determine unknown angles",
            "Find the perimeter of circles",
            "Convert units",
            "Calculate factorials",
            QuestionOption.A,
            "They help determine angles when trigonometric ratios are known.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Solving Problems Using Inverse Trigonometric Functions",
            "The first step in solving many inverse trigonometric problems is to:",
            "Identify the given trigonometric ratio",
            "Find the area",
            "Square the expression",
            "Multiply by zero",
            QuestionOption.A,
            "Recognizing the given trigonometric ratio allows the appropriate inverse function to be selected.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Inverse Trigonometric Functions
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Inverse Trigonometric Functions",
            "Inverse trigonometric functions are commonly used in:",
            "Surveying",
            "Cooking",
            "Painting",
            "Grammar",
            QuestionOption.A,
            "Surveyors use inverse trigonometric functions to calculate unknown angles.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Inverse Trigonometric Functions",
            "Which profession frequently uses inverse trigonometric functions?",
            "Engineer",
            "Chef",
            "Poet",
            "Musician",
            QuestionOption.A,
            "Engineers use inverse trigonometric functions in design, analysis, and measurements.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Inverse Trigonometric Functions",
            "Navigation systems use inverse trigonometric functions to:",
            "Determine directions and angles",
            "Store data",
            "Edit documents",
            "Compress files",
            QuestionOption.A,
            "Navigation relies on inverse trigonometric functions to compute bearings and directions.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Inverse Trigonometric Functions",
            "In physics, inverse trigonometric functions are often used to calculate:",
            "Angles of forces and motion",
            "Chemical formulas",
            "Population growth",
            "Currency exchange",
            QuestionOption.A,
            "They help determine the direction of vectors and forces from known components.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Inverse Trigonometric Functions",
            "Why are inverse trigonometric functions important in mathematics and science?",
            "They allow unknown angles to be determined from known ratios in engineering, navigation, physics, and geometry.",
            "They are only useful for examinations.",
            "They replace ordinary trigonometric functions.",
            "They are only used for drawing graphs.",
            QuestionOption.A,
            "Inverse trigonometric functions are essential for solving practical problems involving unknown angles in many scientific and engineering fields.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Trigonometric Equations
        // ==========================================================

        AddQuestion(
            "Introduction to Trigonometric Equations",
            "What is a trigonometric equation?",
            "An equation containing one or more trigonometric functions",
            "An equation containing only integers",
            "An equation involving only logarithms",
            "An equation with no variables",
            QuestionOption.A,
            "A trigonometric equation contains trigonometric functions such as sine, cosine, or tangent.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Trigonometric Equations",
            "Which of the following is a trigonometric equation?",
            "sin x = 1/2",
            "x² + 4 = 0",
            "2x + 5 = 7",
            "log x = 2",
            QuestionOption.A,
            "An equation involving trigonometric functions is called a trigonometric equation.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Trigonometric Equations",
            "The solutions of a trigonometric equation are generally:",
            "Angles",
            "Areas",
            "Volumes",
            "Lengths",
            QuestionOption.A,
            "Trigonometric equations are solved to determine unknown angles.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Trigonometric Equations",
            "Which trigonometric functions commonly appear in trigonometric equations?",
            "Only sine",
            "Only cosine",
            "Only tangent",
            "Sine, cosine, and tangent",
            QuestionOption.D,
            "Most trigonometric equations involve one or more basic trigonometric functions.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Trigonometric Equations",
            "Why are trigonometric equations important?",
            "They help solve problems involving angles and periodic phenomena.",
            "They replace algebra.",
            "They are only used in geometry.",
            "They calculate probabilities.",
            QuestionOption.A,
            "Trigonometric equations are fundamental in mathematics, science, and engineering.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Solving Trigonometric Equations
        // ==========================================================

        AddQuestion(
            "Solving Trigonometric Equations",
            "What is the principal solution of sin x = 0?",
            "0°",
            "30°",
            "45°",
            "90°",
            QuestionOption.A,
            "Since sin 0° = 0, the principal solution is 0°.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Solving Trigonometric Equations",
            "What is the principal solution of cos x = 1?",
            "0°",
            "45°",
            "60°",
            "90°",
            QuestionOption.A,
            "Since cos 0° = 1, the principal solution is 0°.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Solving Trigonometric Equations",
            "Which identity is commonly used to simplify trigonometric equations?",
            "sin²θ + cos²θ = 1",
            "a² + b² = c²",
            "x² + y² = r²",
            "E = mc²",
            QuestionOption.A,
            "The Pythagorean identity is frequently used to simplify and solve trigonometric equations.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Solving Trigonometric Equations",
            "A common first step in solving a trigonometric equation is to:",
            "Rewrite it using identities",
            "Differentiate it",
            "Integrate it",
            "Multiply by zero",
            QuestionOption.A,
            "Using identities often simplifies the equation into an easier form.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Solving Trigonometric Equations",
            "The objective of solving a trigonometric equation is to determine:",
            "Unknown angle values",
            "Circle radii",
            "Triangle areas",
            "Probability values",
            QuestionOption.A,
            "The goal is to find all angle values that satisfy the equation.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Trigonometric Equations
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Trigonometric Equations",
            "Trigonometric equations are widely used in:",
            "Physics",
            "Cooking",
            "Grammar",
            "History",
            QuestionOption.A,
            "Physics uses trigonometric equations to model oscillations and waves.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Trigonometric Equations",
            "Engineers use trigonometric equations to:",
            "Analyze structures and signals",
            "Write novels",
            "Paint buildings",
            "Prepare recipes",
            QuestionOption.A,
            "Engineering applications include structural analysis, signal processing, and mechanics.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Trigonometric Equations",
            "Wave motion is commonly modeled using:",
            "Trigonometric equations",
            "Linear equations only",
            "Quadratic equations only",
            "Arithmetic sequences",
            QuestionOption.A,
            "Periodic wave motion is naturally represented by trigonometric equations.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Trigonometric Equations",
            "Computer graphics use trigonometric equations for:",
            "Rotation and animation",
            "Spell checking",
            "Database indexing",
            "Text formatting",
            QuestionOption.A,
            "Rotating and animating objects requires trigonometric calculations.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Trigonometric Equations",
            "Why are trigonometric equations important in science and engineering?",
            "They model periodic behaviour and solve real-world problems involving angles, waves, and motion.",
            "They are only useful for examinations.",
            "They replace algebra completely.",
            "They are only used for drawing triangles.",
            QuestionOption.A,
            "Trigonometric equations are fundamental in physics, engineering, astronomy, navigation, computer graphics, and many other applications.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Heights & Distances
        // ==========================================================

        AddQuestion(
            "Introduction to Heights & Distances",
            "What is the main purpose of studying heights and distances?",
            "To measure inaccessible heights and distances using trigonometry",
            "To calculate areas of circles",
            "To solve quadratic equations",
            "To draw coordinate graphs",
            QuestionOption.A,
            "Heights and distances use trigonometric ratios to find measurements that cannot be measured directly.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Heights & Distances",
            "Which mathematical concept is mainly used to solve heights and distances problems?",
            "Probability",
            "Statistics",
            "Trigonometric ratios",
            "Logarithms",
            QuestionOption.C,
            "Trigonometric ratios such as sine, cosine, and tangent are used in these problems.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Heights & Distances",
            "The angle between the horizontal and the line of sight to an object above eye level is called:",
            "Angle of depression",
            "Right angle",
            "Angle of elevation",
            "Acute angle",
            QuestionOption.C,
            "The angle of elevation is measured upward from the horizontal.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Heights & Distances",
            "The angle between the horizontal and the line of sight to an object below eye level is called:",
            "Angle of elevation",
            "Angle of depression",
            "Reflex angle",
            "Obtuse angle",
            QuestionOption.B,
            "The angle of depression is measured downward from the horizontal.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Heights & Distances",
            "Why are heights and distances important?",
            "They allow indirect measurement of objects that are difficult to reach.",
            "They replace coordinate geometry.",
            "They are only useful in classrooms.",
            "They eliminate the need for measurements.",
            QuestionOption.A,
            "They are widely used whenever direct measurement is impractical or impossible.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Solving Problems Using Heights & Distances
        // ==========================================================

        AddQuestion(
            "Solving Problems Using Heights & Distances",
            "Which trigonometric ratio is commonly used to calculate height when the opposite side and adjacent side are involved?",
            "Sine",
            "Cosine",
            "Tangent",
            "Secant",
            QuestionOption.C,
            "Tangent is equal to opposite divided by adjacent.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Solving Problems Using Heights & Distances",
            "If the angle of elevation and the horizontal distance are known, the height can usually be found using:",
            "Tangent",
            "Cosine",
            "Sine",
            "Cotangent",
            QuestionOption.A,
            "Height = Distance × tan θ in a right triangle.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Solving Problems Using Heights & Distances",
            "Before applying trigonometric ratios, a heights and distances problem is usually represented as:",
            "A right-angled triangle",
            "A circle",
            "A rectangle",
            "A parabola",
            QuestionOption.A,
            "Most problems are modeled using a right-angled triangle.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Solving Problems Using Heights & Distances",
            "Angles of elevation and depression are always measured from the:",
            "Vertical line",
            "Horizontal line",
            "Diagonal line",
            "Hypotenuse",
            QuestionOption.B,
            "Both angles are measured relative to the horizontal.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Solving Problems Using Heights & Distances",
            "The first step in solving a heights and distances problem is usually to:",
            "Draw a labelled diagram",
            "Differentiate the equation",
            "Find the area",
            "Square every value",
            QuestionOption.A,
            "Drawing a clear diagram makes it easier to identify known and unknown values.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Heights & Distances
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Heights & Distances",
            "Surveyors use heights and distances to:",
            "Measure land and building heights",
            "Write software",
            "Solve probability questions",
            "Draw pie charts",
            QuestionOption.A,
            "Surveyors use trigonometry to determine heights and distances accurately.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Heights & Distances",
            "Which profession commonly applies heights and distances in construction projects?",
            "Engineer",
            "Chef",
            "Musician",
            "Author",
            QuestionOption.A,
            "Civil and structural engineers frequently use these concepts during planning and construction.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Heights & Distances",
            "Navigation uses heights and distances to determine:",
            "Locations and positions",
            "Food recipes",
            "Book prices",
            "Grammar rules",
            QuestionOption.A,
            "Navigation relies on trigonometric calculations to estimate positions and distances.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Heights & Distances",
            "Architects use heights and distances mainly for:",
            "Planning building dimensions",
            "Writing novels",
            "Studying biology",
            "Preparing reports only",
            QuestionOption.A,
            "Architects use these calculations to design safe and accurate structures.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Heights & Distances",
            "Why are heights and distances important in real-life applications?",
            "They enable accurate indirect measurements in surveying, engineering, navigation, architecture, and construction.",
            "They are only useful in mathematics examinations.",
            "They replace ordinary measuring tools completely.",
            "They are only used to draw triangles.",
            QuestionOption.A,
            "Heights and distances provide practical methods for measuring objects that are difficult or impossible to measure directly.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Graphs of Trigonometric Functions
        // ==========================================================

        AddQuestion(
            "Introduction to Graphs of Trigonometric Functions",
            "Which trigonometric function has a wave-shaped graph starting at the origin?",
            "Cosine",
            "Sine",
            "Tangent",
            "Secant",
            QuestionOption.B,
            "The sine graph starts at the origin (0,0) and forms a smooth wave.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Graphs of Trigonometric Functions",
            "What is the amplitude of the basic sine function y = sin x?",
            "0",
            "1",
            "2",
            "π",
            QuestionOption.B,
            "The amplitude of y = sin x is 1.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Graphs of Trigonometric Functions",
            "What is the period of the basic sine function?",
            "π",
            "2π",
            "3π",
            "4π",
            QuestionOption.B,
            "The sine function repeats every 2π radians.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Graphs of Trigonometric Functions",
            "Which trigonometric graph starts at its maximum value when x = 0?",
            "Sine",
            "Tangent",
            "Cosine",
            "Cotangent",
            QuestionOption.C,
            "The cosine graph begins at y = 1 when x = 0.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Graphs of Trigonometric Functions",
            "Why are graphs of trigonometric functions important?",
            "They help visualize periodic behaviour and repeating patterns.",
            "They are only used to draw circles.",
            "They replace trigonometric identities.",
            "They are only useful for examinations.",
            QuestionOption.A,
            "Trigonometric graphs make it easier to understand periodic functions and their applications.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Understanding and Analyzing Trigonometric Graphs
        // ==========================================================

        AddQuestion(
            "Understanding and Analyzing Trigonometric Graphs",
            "Which trigonometric function has vertical asymptotes?",
            "Sine",
            "Cosine",
            "Tangent",
            "None of these",
            QuestionOption.C,
            "The tangent graph contains vertical asymptotes where the cosine function equals zero.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Understanding and Analyzing Trigonometric Graphs",
            "Changing the amplitude of a sine graph affects its:",
            "Height",
            "Period",
            "Domain",
            "Asymptotes",
            QuestionOption.A,
            "The amplitude determines the maximum height and depth of the graph.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Understanding and Analyzing Trigonometric Graphs",
            "A horizontal shift of a trigonometric graph is also called a:",
            "Phase shift",
            "Reflection",
            "Scaling",
            "Rotation",
            QuestionOption.A,
            "Moving a graph left or right is known as a phase shift.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Understanding and Analyzing Trigonometric Graphs",
            "Multiplying the input variable by a constant mainly changes the:",
            "Period",
            "Amplitude",
            "Range",
            "Maximum value",
            QuestionOption.A,
            "Changing the coefficient of x affects how quickly the graph repeats, altering its period.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Understanding and Analyzing Trigonometric Graphs",
            "Which graph repeats indefinitely in both positive and negative directions?",
            "Only the sine graph",
            "Only the cosine graph",
            "All basic trigonometric graphs",
            "None of them",
            QuestionOption.C,
            "All trigonometric functions are periodic and continue repeating over their domains.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Trigonometric Graphs
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Trigonometric Graphs",
            "Trigonometric graphs are commonly used to model:",
            "Periodic motion",
            "Population only",
            "Book sales",
            "Random numbers",
            QuestionOption.A,
            "Periodic phenomena such as waves and oscillations are modeled using trigonometric graphs.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Trigonometric Graphs",
            "Which field frequently uses trigonometric graphs to study waves?",
            "Physics",
            "History",
            "Grammar",
            "Economics",
            QuestionOption.A,
            "Physics uses trigonometric graphs to represent sound, light, and other wave motions.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Trigonometric Graphs",
            "Electrical engineers use trigonometric graphs to analyze:",
            "Alternating current (AC) signals",
            "Food recipes",
            "Book layouts",
            "Weather forecasts",
            QuestionOption.A,
            "Alternating current and voltage are commonly represented using sine waves.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Trigonometric Graphs",
            "Computer animation often uses trigonometric graphs to create:",
            "Smooth periodic motion",
            "Database queries",
            "Text formatting",
            "Image compression",
            QuestionOption.A,
            "Sine and cosine functions are used to generate natural-looking repetitive movements.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Trigonometric Graphs",
            "Why are trigonometric graphs important in science and engineering?",
            "They model repeating patterns such as waves, oscillations, signals, and rotations in many real-world systems.",
            "They are only useful in classroom exercises.",
            "They replace algebra completely.",
            "They are only used to draw curves.",
            QuestionOption.A,
            "Trigonometric graphs are fundamental in engineering, physics, signal processing, astronomy, and computer graphics because they accurately describe periodic behaviour.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Relations
        // ==========================================================

        AddQuestion(
            "Introduction to Relations",
            "What is a relation in mathematics?",
            "A connection between elements of two sets",
            "A collection of numbers only",
            "A type of equation",
            "A geometric figure",
            QuestionOption.A,
            "A relation is a set of ordered pairs that connects elements of two sets.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Relations",
            "A relation is usually represented as a set of:",
            "Matrices",
            "Ordered pairs",
            "Fractions",
            "Polynomials",
            QuestionOption.B,
            "Relations are commonly represented using ordered pairs such as (a, b).",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Relations",
            "If (2,5) belongs to a relation, then:",
            "2 is related to 5",
            "5 is always related to 2",
            "2 equals 5",
            "The relation is a function",
            QuestionOption.A,
            "The ordered pair (2,5) indicates that 2 is related to 5.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Relations",
            "Which of the following can be used to represent a relation?",
            "Ordered pairs",
            "Arrow diagrams",
            "Cartesian diagrams",
            "All of the above",
            QuestionOption.D,
            "Relations can be represented using ordered pairs, arrow diagrams, and Cartesian diagrams.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Relations",
            "Why are relations important?",
            "They describe connections between elements of sets.",
            "They only solve algebraic equations.",
            "They replace functions.",
            "They are only used in geometry.",
            QuestionOption.A,
            "Relations help describe and analyze relationships between objects in mathematics and computer science.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Types and Properties of Relations
        // ==========================================================

        AddQuestion(
            "Types and Properties of Relations",
            "A relation R on a set A is reflexive if:",
            "Every element is related to itself",
            "Every element is related to every other element",
            "No element is related to itself",
            "The relation has only one ordered pair",
            QuestionOption.A,
            "A relation is reflexive when (a,a) belongs to the relation for every element a.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Types and Properties of Relations",
            "A relation is symmetric if:",
            "Whenever (a,b) belongs to R, then (b,a) also belongs to R",
            "Every element is related to itself",
            "The relation contains only equal elements",
            "The relation is always transitive",
            QuestionOption.A,
            "A symmetric relation satisfies the property that if aRb, then bRa.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Types and Properties of Relations",
            "A relation is transitive if:",
            "Whenever aRb and bRc, then aRc",
            "aRb implies bRa",
            "Every element relates to itself",
            "Every pair is unique",
            QuestionOption.A,
            "Transitivity means the relationship continues through intermediate elements.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Types and Properties of Relations",
            "An equivalence relation must be:",
            "Only reflexive",
            "Reflexive, symmetric, and transitive",
            "Only symmetric",
            "Only transitive",
            QuestionOption.B,
            "Equivalence relations satisfy all three properties: reflexive, symmetric, and transitive.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Types and Properties of Relations",
            "Which property ensures every element is related to itself?",
            "Reflexive",
            "Symmetric",
            "Transitive",
            "Antisymmetric",
            QuestionOption.A,
            "Reflexivity requires that every element is related to itself.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Relations
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Relations",
            "Relations are commonly used in:",
            "Databases",
            "Cooking",
            "Painting",
            "Music composition",
            QuestionOption.A,
            "Database tables often model relationships between different entities.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Relations",
            "Which branch of computer science heavily uses relations?",
            "Database management",
            "Graphic design",
            "Video editing",
            "Animation only",
            QuestionOption.A,
            "Relational databases are built upon mathematical relation concepts.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Relations",
            "Relations help represent:",
            "Connections between objects",
            "Only numerical calculations",
            "Only geometric shapes",
            "Only equations",
            QuestionOption.A,
            "Relations describe associations between different entities or objects.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Relations",
            "Which real-world system commonly relies on relational concepts?",
            "Student-course databases",
            "Weather forecasting only",
            "Painting software only",
            "Word processors",
            QuestionOption.A,
            "Student-course enrollment is a common example of a many-to-many relation.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Relations",
            "Why are relations important in mathematics and computer science?",
            "They model connections between objects and form the foundation of databases, logic, graphs, and many computational systems.",
            "They are only useful for examinations.",
            "They replace functions completely.",
            "They are only used in coordinate geometry.",
            QuestionOption.A,
            "Relations provide a formal way to describe associations and are fundamental in mathematics, databases, graph theory, and logic.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Types of Functions
        // ==========================================================

        AddQuestion(
            "Introduction to Types of Functions",
            "What is a function in mathematics?",
            "A relation where each input has exactly one output",
            "A set containing only numbers",
            "A collection of equations",
            "A geometric shape",
            QuestionOption.A,
            "A function assigns exactly one output to every input in its domain.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Types of Functions",
            "Which type of function maps different elements of the domain to different elements of the codomain?",
            "One-one function",
            "Many-one function",
            "Constant function",
            "Identity function",
            QuestionOption.A,
            "A one-one (injective) function maps distinct inputs to distinct outputs.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Types of Functions",
            "In a constant function, every input maps to:",
            "A different output",
            "The same output",
            "No output",
            "Two outputs",
            QuestionOption.B,
            "A constant function assigns the same value to every element of the domain.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Types of Functions",
            "An identity function maps every element to:",
            "Its square",
            "Its inverse",
            "Itself",
            "Zero",
            QuestionOption.C,
            "For an identity function, f(x) = x for every element in the domain.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Types of Functions",
            "Why are different types of functions important?",
            "They help describe different relationships between inputs and outputs.",
            "They replace relations completely.",
            "They are only used in geometry.",
            "They are only useful in examinations.",
            QuestionOption.A,
            "Different function types model different mathematical and real-world relationships.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Understanding and Classifying Types of Functions
        // ==========================================================

        AddQuestion(
            "Understanding and Classifying Types of Functions",
            "A function is onto (surjective) if:",
            "Every element of the codomain has at least one pre-image",
            "Every input has two outputs",
            "No element is repeated",
            "The domain equals the range",
            QuestionOption.A,
            "In an onto function, every codomain element is mapped by at least one domain element.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Understanding and Classifying Types of Functions",
            "A function is into if:",
            "Some elements of the codomain are not mapped",
            "Every codomain element is mapped",
            "Every input has two outputs",
            "The domain is empty",
            QuestionOption.A,
            "In an into function, at least one codomain element has no pre-image.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Understanding and Classifying Types of Functions",
            "A function that is both one-one and onto is called:",
            "Constant function",
            "Identity function",
            "Bijective function",
            "Many-one function",
            QuestionOption.C,
            "A bijective function is both injective and surjective.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Understanding and Classifying Types of Functions",
            "An inverse function exists only if the original function is:",
            "Many-one",
            "Bijective",
            "Constant",
            "Into",
            QuestionOption.B,
            "Only bijective functions have inverses.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Understanding and Classifying Types of Functions",
            "The set of all possible outputs of a function is called its:",
            "Domain",
            "Codomain",
            "Range",
            "Relation",
            QuestionOption.C,
            "The range consists of all actual output values produced by the function.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Types of Functions
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Types of Functions",
            "Functions are widely used in:",
            "Computer science",
            "Cooking",
            "Painting",
            "Music composition",
            QuestionOption.A,
            "Functions are fundamental in algorithms, programming, and data processing.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Types of Functions",
            "Which field commonly uses functions to model supply and demand?",
            "Economics",
            "History",
            "Literature",
            "Geography",
            QuestionOption.A,
            "Economics uses functions to represent relationships between variables.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Types of Functions",
            "Engineers use functions mainly to:",
            "Model relationships between variables",
            "Write novels",
            "Draw paintings",
            "Translate languages",
            QuestionOption.A,
            "Engineering calculations frequently involve mathematical functions.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Types of Functions",
            "In computer programming, a function generally:",
            "Takes input and produces output",
            "Stores only images",
            "Creates databases only",
            "Deletes files automatically",
            QuestionOption.A,
            "Programming functions accept inputs, process them, and return outputs.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Types of Functions",
            "Why are functions important in mathematics and real-world applications?",
            "They model relationships between variables and are essential in science, engineering, economics, programming, and data analysis.",
            "They are only useful for solving textbook problems.",
            "They replace all mathematical concepts.",
            "They are only used in graph drawing.",
            QuestionOption.A,
            "Functions provide a mathematical framework for describing how one quantity depends on another across many disciplines.",
            DifficultyLevel.Advance,
            5);// ==========================================================
               // Introduction to Domain & Range
               // ==========================================================

        AddQuestion(
            "Introduction to Domain & Range",
            "What is the domain of a function?",
            "The set of all possible input values",
            "The set of all output values",
            "The graph of the function",
            "The slope of the function",
            QuestionOption.A,
            "The domain consists of all valid input values for which the function is defined.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Domain & Range",
            "What is the range of a function?",
            "The set of all possible input values",
            "The set of all possible output values",
            "The x-axis of the graph",
            "The equation of the function",
            QuestionOption.B,
            "The range is the set of all output values produced by the function.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Domain & Range",
            "In the function y = x², which variable represents the input?",
            "x",
            "y",
            "Both x and y",
            "Neither x nor y",
            QuestionOption.A,
            "The variable x is the independent variable or input.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Domain & Range",
            "Which of the following best describes the range?",
            "All values x can take",
            "All values produced by the function",
            "Only positive values",
            "Only integer values",
            QuestionOption.B,
            "The range contains every output value corresponding to the domain.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Domain & Range",
            "Why are domain and range important?",
            "They define where a function is valid and the outputs it can produce.",
            "They replace equations.",
            "They are only used for graphing.",
            "They determine the slope only.",
            QuestionOption.A,
            "Knowing the domain and range helps understand and analyze functions correctly.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Finding Domain & Range of Functions
        // ==========================================================

        AddQuestion(
            "Finding Domain & Range of Functions",
            "For a rational function, the domain excludes values that make the:",
            "Numerator zero",
            "Denominator zero",
            "Function positive",
            "Function negative",
            QuestionOption.B,
            "Division by zero is undefined, so such values are excluded from the domain.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Finding Domain & Range of Functions",
            "For an even root function such as √x, the domain is:",
            "x ≥ 0",
            "x ≤ 0",
            "All real numbers",
            "x ≠ 0",
            QuestionOption.A,
            "The expression inside an even root must be non-negative.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Finding Domain & Range of Functions",
            "The graph of a function can help determine its:",
            "Domain and range",
            "Area only",
            "Perimeter only",
            "Slope only",
            QuestionOption.A,
            "Graphs visually show the allowable inputs and resulting outputs.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Finding Domain & Range of Functions",
            "The domain of the polynomial function y = x³ is:",
            "All real numbers",
            "x ≥ 0",
            "x ≤ 0",
            "x ≠ 0",
            QuestionOption.A,
            "Polynomial functions are defined for every real number.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Finding Domain & Range of Functions",
            "When finding the domain of a function, the first step is to:",
            "Identify values that make the function undefined",
            "Find the derivative",
            "Calculate the area",
            "Find the midpoint",
            QuestionOption.A,
            "Check for restrictions such as division by zero or invalid square roots.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Domain & Range
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Domain & Range",
            "In computer programming, domain restrictions help:",
            "Validate user input",
            "Increase screen brightness",
            "Print documents",
            "Create folders",
            QuestionOption.A,
            "Input validation ensures only acceptable values are processed.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Domain & Range",
            "Engineers use domain and range to:",
            "Model practical systems with valid input and output values",
            "Write novels",
            "Compose music",
            "Edit videos",
            QuestionOption.A,
            "Engineering models require realistic input and output constraints.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Domain & Range",
            "Economists use functions with appropriate domains to represent:",
            "Realistic business conditions",
            "Chemical reactions",
            "Language grammar",
            "Painting techniques",
            QuestionOption.A,
            "Economic models use valid input values such as prices and demand.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Domain & Range",
            "In physics, domain restrictions often represent:",
            "Physically meaningful values",
            "Random values only",
            "Negative time always",
            "Impossible measurements",
            QuestionOption.A,
            "Many physical quantities have practical limitations on their values.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Domain & Range",
            "Why are domain and range essential in mathematics and real-world applications?",
            "They ensure functions are used only with valid inputs and meaningful outputs in science, engineering, economics, and computing.",
            "They are only useful for drawing graphs.",
            "They replace algebraic equations.",
            "They are only required in examinations.",
            QuestionOption.A,
            "Understanding domain and range ensures mathematical models accurately represent real-world situations.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Composite Functions
        // ==========================================================

        AddQuestion(
            "Introduction to Composite Functions",
            "What is a composite function?",
            "A function formed by applying one function to the output of another",
            "A function with two variables",
            "A constant function",
            "An inverse function",
            QuestionOption.A,
            "A composite function is created when the output of one function becomes the input of another.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Composite Functions",
            "The notation (f ∘ g)(x) means:",
            "f(g(x))",
            "g(f(x))",
            "f(x) + g(x)",
            "f(x) × g(x)",
            QuestionOption.A,
            "The composition (f ∘ g)(x) means apply g first, then apply f to the result.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Composite Functions",
            "In the composite function f(g(x)), which function is evaluated first?",
            "f",
            "g",
            "Both together",
            "Neither",
            QuestionOption.B,
            "The inner function g is evaluated first, followed by the outer function f.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Composite Functions",
            "Composite functions involve:",
            "Combining two or more functions",
            "Only quadratic equations",
            "Only trigonometric functions",
            "Only graphs",
            QuestionOption.A,
            "Function composition combines functions into a new function.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Composite Functions",
            "Why are composite functions important?",
            "They describe multi-step mathematical processes.",
            "They replace inverse functions.",
            "They are only used in geometry.",
            "They only simplify fractions.",
            QuestionOption.A,
            "Composite functions model situations where one operation follows another.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Evaluating and Solving Composite Functions
        // ==========================================================

        AddQuestion(
            "Evaluating and Solving Composite Functions",
            "To evaluate (f ∘ g)(x), you first:",
            "Find g(x)",
            "Find f(x)",
            "Find both separately",
            "Differentiate f(x)",
            QuestionOption.A,
            "Always evaluate the inner function first.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Evaluating and Solving Composite Functions",
            "If g(x) is not defined for a value of x, then f(g(x)) is:",
            "Undefined",
            "Always zero",
            "Always one",
            "Always positive",
            QuestionOption.A,
            "The composite function exists only where the inner function is defined.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Evaluating and Solving Composite Functions",
            "The domain of a composite function depends on:",
            "The domains of both functions",
            "Only the first function",
            "Only the second function",
            "Neither function",
            QuestionOption.A,
            "The input must satisfy the domain of the inner function and produce outputs valid for the outer function.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Evaluating and Solving Composite Functions",
            "Which notation represents applying g after f?",
            "(g ∘ f)(x)",
            "(f ∘ g)(x)",
            "f + g",
            "fg",
            QuestionOption.A,
            "The notation (g ∘ f)(x) means evaluate f first and then apply g.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Evaluating and Solving Composite Functions",
            "Before simplifying a composite function, you should:",
            "Substitute the inner function into the outer function",
            "Differentiate the function",
            "Find the graph",
            "Multiply both functions",
            QuestionOption.A,
            "Composition is evaluated by replacing the variable in the outer function with the inner function.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Composite Functions
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Composite Functions",
            "Composite functions are widely used in:",
            "Computer science",
            "Painting",
            "Cooking",
            "Music",
            QuestionOption.A,
            "Programming often involves applying one function after another.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Composite Functions",
            "Engineers use composite functions to:",
            "Model multi-stage systems",
            "Write novels",
            "Design paintings",
            "Translate languages",
            QuestionOption.A,
            "Engineering processes often involve several mathematical operations performed sequentially.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Composite Functions",
            "Composite functions are useful when:",
            "One process depends on the output of another",
            "Only one variable exists",
            "No calculations are required",
            "Graphs are unavailable",
            QuestionOption.A,
            "Many practical systems involve chained operations.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Composite Functions",
            "In economics, composite functions can model:",
            "Multiple dependent business processes",
            "Only population growth",
            "Only weather conditions",
            "Only geometry problems",
            QuestionOption.A,
            "Economic models often combine several functions to describe real-world behaviour.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Composite Functions",
            "Why are composite functions important in mathematics and real-world applications?",
            "They model sequences of operations used in science, engineering, programming, economics, and data analysis.",
            "They are only useful in examinations.",
            "They replace algebra completely.",
            "They are only used for graph sketching.",
            QuestionOption.A,
            "Composite functions allow complex systems to be represented by combining simpler functions, making them fundamental in many fields.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Introduction to Inverse Functions
        // ==========================================================

        AddQuestion(
            "Introduction to Inverse Functions",
            "What is the purpose of an inverse function?",
            "To reverse the effect of a function",
            "To square every input",
            "To find the derivative",
            "To graph a function",
            QuestionOption.A,
            "An inverse function reverses the mapping of the original function, taking outputs back to their corresponding inputs.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Inverse Functions",
            "The inverse of a function f is commonly denoted by:",
            "f²(x)",
            "f⁻¹(x)",
            "1/f(x)",
            "f'(x)",
            QuestionOption.B,
            "The notation f⁻¹(x) represents the inverse function, not the reciprocal or derivative.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Inverse Functions",
            "A function must be ______ to have an inverse function.",
            "One-to-one",
            "Constant",
            "Many-one",
            "Periodic",
            QuestionOption.A,
            "Only one-to-one (injective) functions have inverses over their domains.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Inverse Functions",
            "Applying a function and then its inverse results in:",
            "The original input",
            "Zero",
            "One",
            "A different output",
            QuestionOption.A,
            "For an inverse function, f⁻¹(f(x)) = x.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Inverse Functions",
            "Why are inverse functions important?",
            "They allow original input values to be recovered from outputs.",
            "They replace composite functions.",
            "They are only used in graphing.",
            "They are only useful in geometry.",
            QuestionOption.A,
            "Inverse functions help reverse mathematical processes and solve equations.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Finding and Verifying Inverse Functions
        // ==========================================================

        AddQuestion(
            "Finding and Verifying Inverse Functions",
            "The first step in finding the inverse of a function is to:",
            "Replace f(x) with y",
            "Differentiate the function",
            "Find the graph",
            "Square the function",
            QuestionOption.A,
            "The process begins by writing the function as y = f(x).",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Finding and Verifying Inverse Functions",
            "After interchanging x and y, the next step is to:",
            "Solve for y",
            "Find the derivative",
            "Multiply by x",
            "Draw the graph",
            QuestionOption.A,
            "Solving for y gives the inverse function.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Finding and Verifying Inverse Functions",
            "How can two functions be verified as inverses?",
            "Their composition equals the identity function",
            "Their graphs never intersect",
            "They have the same equation",
            "They have different domains",
            QuestionOption.A,
            "If f(g(x)) = x and g(f(x)) = x, the functions are inverses.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Finding and Verifying Inverse Functions",
            "Which composition confirms that f⁻¹ is the inverse of f?",
            "f(f⁻¹(x)) = x",
            "f(x) + f⁻¹(x) = 0",
            "f(x) = f⁻¹(x)",
            "f(x) × f⁻¹(x) = 1",
            QuestionOption.A,
            "A composition resulting in x confirms the inverse relationship.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Finding and Verifying Inverse Functions",
            "A many-one function generally:",
            "Does not have an inverse function",
            "Always has an inverse",
            "Is always constant",
            "Is always onto",
            QuestionOption.A,
            "Multiple inputs producing the same output prevent a unique inverse.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Inverse Functions
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Inverse Functions",
            "Inverse functions are commonly used in:",
            "Computer science",
            "Painting",
            "Cooking",
            "Music",
            QuestionOption.A,
            "Many algorithms use inverse operations to recover original data.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Inverse Functions",
            "Which field uses inverse functions for encoding and decoding information?",
            "Cryptography",
            "Agriculture",
            "Literature",
            "Botany",
            QuestionOption.A,
            "Cryptography relies on inverse mathematical operations for encryption and decryption.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Inverse Functions",
            "Engineers use inverse functions mainly to:",
            "Recover unknown input values from outputs",
            "Write reports",
            "Create animations only",
            "Draw geometric figures",
            QuestionOption.A,
            "Inverse functions help determine original values in engineering models.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Inverse Functions",
            "Computer graphics often use inverse functions to:",
            "Reverse transformations",
            "Delete files",
            "Compress text",
            "Store databases",
            QuestionOption.A,
            "Inverse transformations are essential in image processing and graphics.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Inverse Functions",
            "Why are inverse functions important in mathematics and real-world applications?",
            "They reverse mathematical operations and are widely used in science, engineering, cryptography, computer graphics, and data analysis.",
            "They are only useful in examinations.",
            "They replace all other functions.",
            "They are only used in geometry.",
            QuestionOption.A,
            "Inverse functions are fundamental for recovering original values and reversing processes across many scientific and technological fields.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Introduction to Graphing Functions
        // ==========================================================

        AddQuestion(
            "Introduction to Graphing Functions",
            "What is the graph of a function?",
            "A visual representation of the relationship between inputs and outputs",
            "A table of numbers only",
            "A mathematical proof",
            "A geometric construction",
            QuestionOption.A,
            "A graph shows how the output of a function changes with different input values.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Graphing Functions",
            "Functions are commonly graphed on the:",
            "Number line",
            "Cartesian plane",
            "Pie chart",
            "Bar graph",
            QuestionOption.B,
            "The Cartesian plane uses x and y axes to plot functions.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Graphing Functions",
            "The horizontal axis on a graph is called the:",
            "y-axis",
            "x-axis",
            "Origin",
            "Quadrant",
            QuestionOption.B,
            "The x-axis represents the independent variable.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Graphing Functions",
            "A point on a graph is represented as:",
            "An ordered pair (x, y)",
            "A fraction",
            "A matrix",
            "A vector only",
            QuestionOption.A,
            "Each point on a graph is written as an ordered pair (x, y).",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Graphing Functions",
            "Why are function graphs useful?",
            "They help visualize relationships between variables.",
            "They replace equations completely.",
            "They are only used in geometry.",
            "They eliminate calculations.",
            QuestionOption.A,
            "Graphs make it easier to understand patterns and trends in functions.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Analyzing and Sketching Function Graphs
        // ==========================================================

        AddQuestion(
            "Analyzing and Sketching Function Graphs",
            "The graph of a linear function is a:",
            "Circle",
            "Straight line",
            "Parabola",
            "Hyperbola",
            QuestionOption.B,
            "Linear functions always produce straight-line graphs.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Analyzing and Sketching Function Graphs",
            "The graph of a quadratic function is called a:",
            "Circle",
            "Ellipse",
            "Parabola",
            "Straight line",
            QuestionOption.C,
            "Quadratic functions produce parabolic graphs.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Analyzing and Sketching Function Graphs",
            "To sketch a graph accurately, it is helpful to first:",
            "Plot key points",
            "Find the area",
            "Calculate the midpoint",
            "Differentiate the equation",
            QuestionOption.A,
            "Plotting important points helps determine the shape of the graph.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Analyzing and Sketching Function Graphs",
            "The point where a graph crosses the y-axis is called the:",
            "x-intercept",
            "Vertex",
            "y-intercept",
            "Origin",
            QuestionOption.C,
            "The y-intercept occurs where x = 0.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Analyzing and Sketching Function Graphs",
            "When analyzing a graph, intercepts help determine:",
            "Where the graph crosses the axes",
            "Only the slope",
            "Only the domain",
            "Only the range",
            QuestionOption.A,
            "Intercepts provide important information about the behaviour of the function.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Graphing Functions
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Graphing Functions",
            "Graphing functions is widely used in:",
            "Science and engineering",
            "Cooking",
            "Painting",
            "Poetry",
            QuestionOption.A,
            "Graphs help visualize and analyze scientific and engineering data.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Graphing Functions",
            "Economists use graphs mainly to:",
            "Analyze trends and relationships",
            "Draw geometric figures",
            "Write programs",
            "Measure angles",
            QuestionOption.A,
            "Graphs help economists study growth, demand, and other trends.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Graphing Functions",
            "Engineers often use graphs to:",
            "Interpret experimental and system data",
            "Write novels",
            "Translate languages",
            "Compose music",
            QuestionOption.A,
            "Engineering relies on graphs to understand and optimize system performance.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Graphing Functions",
            "Computer graphics use function graphs to:",
            "Model curves and animations",
            "Prepare recipes",
            "Store passwords",
            "Print documents",
            QuestionOption.A,
            "Functions are used to generate smooth curves and animations in computer graphics.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Graphing Functions",
            "Why is graphing functions important in mathematics and real-world applications?",
            "It provides a visual understanding of relationships between variables and supports analysis in science, engineering, economics, and data modelling.",
            "It is only useful for examinations.",
            "It replaces algebra completely.",
            "It is only used in coordinate geometry.",
            QuestionOption.A,
            "Graphing functions helps interpret data, identify patterns, make predictions, and solve practical problems across many disciplines.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Introduction to Piecewise Functions
        // ==========================================================

        AddQuestion(
            "Introduction to Piecewise Functions",
            "What is a piecewise function?",
            "A function defined by different rules on different intervals",
            "A function with only one equation",
            "A constant function",
            "A quadratic function",
            QuestionOption.A,
            "A piecewise function uses different formulas depending on the value of the input.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Piecewise Functions",
            "In a piecewise function, the applicable rule depends on the:",
            "Input value",
            "Output value",
            "Graph colour",
            "Equation number",
            QuestionOption.A,
            "The interval containing the input determines which rule is used.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Piecewise Functions",
            "A piecewise function may contain:",
            "Multiple equations",
            "Only one equation",
            "Only constants",
            "No variables",
            QuestionOption.A,
            "Each interval of the domain can have its own equation.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Piecewise Functions",
            "The intervals in a piecewise function are usually determined using:",
            "Conditions on x",
            "Conditions on y",
            "Only positive numbers",
            "Only negative numbers",
            QuestionOption.A,
            "Conditions such as x < 0 or x ≥ 2 determine which formula applies.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Piecewise Functions",
            "Why are piecewise functions useful?",
            "They model situations where different rules apply in different cases.",
            "They replace all other functions.",
            "They are only used in geometry.",
            "They eliminate the need for graphs.",
            QuestionOption.A,
            "Many real-world situations require different formulas over different intervals.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Evaluating and Graphing Piecewise Functions
        // ==========================================================

        AddQuestion(
            "Evaluating and Graphing Piecewise Functions",
            "To evaluate a piecewise function, you first:",
            "Determine which interval contains the input",
            "Find the derivative",
            "Calculate the midpoint",
            "Square the input",
            QuestionOption.A,
            "The correct formula depends on the interval containing the given input.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Evaluating and Graphing Piecewise Functions",
            "When graphing a piecewise function, each equation is drawn over:",
            "Its specified interval",
            "The entire x-axis",
            "Only positive values",
            "Only negative values",
            QuestionOption.A,
            "Each rule is graphed only where its condition is satisfied.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Evaluating and Graphing Piecewise Functions",
            "An open circle on a graph indicates that the endpoint is:",
            "Not included",
            "Included",
            "The highest point",
            "The origin",
            QuestionOption.A,
            "An open circle means the endpoint does not belong to that interval.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Evaluating and Graphing Piecewise Functions",
            "A closed circle on a graph indicates that the endpoint is:",
            "Included",
            "Not included",
            "Always positive",
            "Always negative",
            QuestionOption.A,
            "A closed circle shows the endpoint is part of the graph.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Evaluating and Graphing Piecewise Functions",
            "When analyzing a piecewise function, continuity depends on:",
            "How the function behaves at interval boundaries",
            "The graph colour",
            "The number of equations",
            "The slope only",
            QuestionOption.A,
            "A function is continuous if the pieces connect correctly at their boundaries.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Piecewise Functions
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Piecewise Functions",
            "Piecewise functions are commonly used to model:",
            "Tax brackets",
            "Planet orbits only",
            "Prime numbers only",
            "Circle geometry only",
            QuestionOption.A,
            "Tax systems often use different rates for different income ranges.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Piecewise Functions",
            "Shipping companies often use piecewise functions because:",
            "Different charges apply to different weight ranges",
            "All parcels cost the same",
            "Only distance matters",
            "Weight is ignored",
            QuestionOption.A,
            "Shipping fees frequently change according to weight intervals.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Piecewise Functions",
            "Utility companies use piecewise functions to calculate:",
            "Electricity or water bills",
            "Triangle areas",
            "Circle radii",
            "Square roots",
            QuestionOption.A,
            "Many utility providers charge different rates for different levels of usage.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Piecewise Functions",
            "Signal processing often uses piecewise functions to model:",
            "Changing signal behaviour",
            "Constant temperatures only",
            "Only straight lines",
            "Only quadratic curves",
            QuestionOption.A,
            "Signals may follow different equations over different time intervals.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Piecewise Functions",
            "Why are piecewise functions important in mathematics and real-world applications?",
            "They model situations where different mathematical rules apply over different intervals, making them useful in economics, engineering, computing, and data analysis.",
            "They are only useful in examinations.",
            "They replace all algebraic functions.",
            "They are only used for graph sketching.",
            QuestionOption.A,
            "Piecewise functions accurately represent systems whose behaviour changes under different conditions.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Transformations of Functions
        // ==========================================================

        AddQuestion(
            "Introduction to Transformations of Functions",
            "What is a transformation of a function?",
            "A change in the position, size, or orientation of its graph",
            "A method of solving equations",
            "A way to find derivatives",
            "A type of inverse function",
            QuestionOption.A,
            "Function transformations modify the appearance of a graph without changing its basic shape.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Transformations of Functions",
            "Which transformation moves a graph without changing its shape?",
            "Translation",
            "Reflection",
            "Stretch",
            "Compression",
            QuestionOption.A,
            "A translation shifts a graph horizontally or vertically while preserving its shape.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Transformations of Functions",
            "Reflecting a graph across the x-axis changes:",
            "The sign of the y-values",
            "The sign of the x-values",
            "The domain",
            "The range only",
            QuestionOption.A,
            "Reflection across the x-axis changes every y-value to its opposite.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Transformations of Functions",
            "A vertical stretch makes a graph appear:",
            "Taller",
            "Shorter",
            "Wider",
            "Unchanged",
            QuestionOption.A,
            "A vertical stretch increases the distance of points from the x-axis.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Transformations of Functions",
            "Why are function transformations important?",
            "They help generate and analyse new graphs from existing functions.",
            "They replace graphing completely.",
            "They are only used in geometry.",
            "They remove the need for equations.",
            QuestionOption.A,
            "Transformations make it easy to understand relationships between different functions.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Graphing and Analyzing Function Transformations
        // ==========================================================

        AddQuestion(
            "Graphing and Analyzing Function Transformations",
            "Adding a constant to f(x), as in f(x) + c, causes a:",
            "Vertical shift",
            "Horizontal shift",
            "Reflection",
            "Rotation",
            QuestionOption.A,
            "Adding a constant moves the graph up or down.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Graphing and Analyzing Function Transformations",
            "Replacing x with x - c in f(x) causes a:",
            "Shift to the right",
            "Shift to the left",
            "Reflection across the x-axis",
            "Vertical stretch",
            QuestionOption.A,
            "Replacing x with x - c shifts the graph c units to the right.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Graphing and Analyzing Function Transformations",
            "Multiplying f(x) by a number greater than 1 results in a:",
            "Vertical stretch",
            "Horizontal compression",
            "Reflection",
            "Translation",
            QuestionOption.A,
            "Multiplying the output enlarges the graph vertically.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Graphing and Analyzing Function Transformations",
            "The graph of y = -f(x) is obtained by reflecting the graph across the:",
            "x-axis",
            "y-axis",
            "Origin",
            "Line y = x",
            QuestionOption.A,
            "Multiplying the output by -1 reflects the graph across the x-axis.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Graphing and Analyzing Function Transformations",
            "Understanding transformations helps you:",
            "Predict graph changes without plotting every point",
            "Eliminate equations",
            "Ignore domains and ranges",
            "Replace coordinate geometry",
            QuestionOption.A,
            "Transformation rules allow quick sketching and analysis of graphs.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Function Transformations
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Function Transformations",
            "Function transformations are widely used in:",
            "Computer graphics",
            "Cooking",
            "Poetry",
            "History",
            QuestionOption.A,
            "Computer graphics rely on transformations to move and resize objects.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Function Transformations",
            "Engineers use function transformations to:",
            "Model changing systems",
            "Write stories",
            "Translate languages",
            "Draw maps only",
            QuestionOption.A,
            "Engineering models often require shifting and scaling mathematical functions.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Function Transformations",
            "In physics, graph transformations help describe:",
            "Changing motion and wave behaviour",
            "Grammar rules",
            "Historical events",
            "Book classifications",
            QuestionOption.A,
            "Physical phenomena often involve translated or scaled mathematical functions.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Function Transformations",
            "Animation software uses transformations to:",
            "Move and resize objects smoothly",
            "Store databases",
            "Solve equations only",
            "Generate passwords",
            QuestionOption.A,
            "Graphical transformations are fundamental in animation and game development.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Function Transformations",
            "Why are function transformations important in mathematics and real-world applications?",
            "They allow existing mathematical models to be shifted, reflected, stretched, or compressed, making them useful in graphics, engineering, physics, animation, and data modelling.",
            "They are only useful in examinations.",
            "They replace all graphing techniques.",
            "They are only used for quadratic functions.",
            QuestionOption.A,
            "Function transformations provide an efficient way to analyse and model changing relationships across many scientific and technological fields.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Introduction to Arithmetic Progression
        // ==========================================================

        AddQuestion(
            "Introduction to Arithmetic Progression",
            "What is an arithmetic progression (AP)?",
            "A sequence with a common ratio",
            "A sequence where each term differs from the previous by a constant value",
            "A random sequence of numbers",
            "A sequence of prime numbers",
            QuestionOption.B,
            "An arithmetic progression is a sequence in which the difference between consecutive terms is constant.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Arithmetic Progression",
            "The fixed value added or subtracted in an AP is called the:",
            "First term",
            "Last term",
            "Common difference",
            "Common ratio",
            QuestionOption.C,
            "The common difference is the constant difference between consecutive terms.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Arithmetic Progression",
            "Which of the following is an arithmetic progression?",
            "2, 4, 8, 16",
            "5, 8, 11, 14",
            "1, 4, 9, 16",
            "3, 6, 12, 24",
            QuestionOption.B,
            "Each term increases by 3, making it an arithmetic progression.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Arithmetic Progression",
            "In the AP 10, 15, 20, 25, the common difference is:",
            "10",
            "15",
            "20",
            "5",
            QuestionOption.D,
            "Each consecutive term differs by 5.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Arithmetic Progression",
            "Why are arithmetic progressions important?",
            "They help study patterns with equal differences.",
            "They are only used in geometry.",
            "They replace algebra.",
            "They are only useful in statistics.",
            QuestionOption.A,
            "Arithmetic progressions model regularly increasing or decreasing patterns.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Finding Terms and Sum of Arithmetic Progression
        // ==========================================================

        AddQuestion(
            "Finding Terms and Sum of Arithmetic Progression",
            "The nth term of an AP is found using:",
            "a + (n - 1)d",
            "a × d",
            "a + nd²",
            "n(a + d)",
            QuestionOption.A,
            "The formula for the nth term is a + (n - 1)d.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Finding Terms and Sum of Arithmetic Progression",
            "The symbol 'a' in an AP formula represents the:",
            "Common difference",
            "First term",
            "Last term",
            "Number of terms",
            QuestionOption.B,
            "The first term of the arithmetic progression is denoted by 'a'.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Finding Terms and Sum of Arithmetic Progression",
            "Which formula gives the sum of the first n terms of an AP?",
            "S = nd",
            "S = a + d",
            "S = n/2 [2a + (n - 1)d]",
            "S = a² + d²",
            QuestionOption.C,
            "This is the standard formula for the sum of an arithmetic progression.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Finding Terms and Sum of Arithmetic Progression",
            "If the first term is 3 and the common difference is 4, what is the 5th term?",
            "15",
            "19",
            "20",
            "23",
            QuestionOption.B,
            "a₅ = 3 + (5 - 1) × 4 = 19.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Finding Terms and Sum of Arithmetic Progression",
            "Before finding the nth term of an AP, you must know:",
            "Only the last term",
            "Only the number of terms",
            "The first term and common difference",
            "Only the sum",
            QuestionOption.C,
            "Both the first term and common difference are required.",
            DifficultyLevel.Advance,
            5);

// PQ. 6
        // ==========================================================
        // Applications and Practice of Arithmetic Progression
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Arithmetic Progression",
            "Arithmetic progressions are commonly used in:",
            "Finance and budgeting",
            "Painting only",
            "Cooking only",
            "Music composition only",
            QuestionOption.A,
            "Financial calculations often involve regular increases or decreases.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Arithmetic Progression",
            "A staircase with each step increasing by the same height is an example of:",
            "Geometric progression",
            "Arithmetic progression",
            "Random sequence",
            "Quadratic sequence",
            QuestionOption.B,
            "Equal increments form an arithmetic progression.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Arithmetic Progression",
            "Engineers use arithmetic progressions to model:",
            "Regularly changing measurements",
            "Only circular motion",
            "Random events",
            "Chemical formulas only",
            QuestionOption.A,
            "APs help describe evenly changing values.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Arithmetic Progression",
            "Scheduling tasks at equal intervals is an application of:",
            "Arithmetic progression",
            "Logarithms",
            "Probability",
            "Matrices",
            QuestionOption.A,
            "Equal intervals naturally follow an arithmetic progression.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Arithmetic Progression",
            "Why is arithmetic progression important in mathematics and real-world applications?",
            "It models situations involving constant increases or decreases, making it useful in finance, engineering, scheduling, and pattern analysis.",
            "It is only useful in examinations.",
            "It replaces algebra completely.",
            "It is only used for number puzzles.",
            QuestionOption.A,
            "Arithmetic progressions provide a simple mathematical model for uniformly changing quantities across many practical applications.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Introduction to Geometric Progression
        // ==========================================================

        AddQuestion(
            "Introduction to Geometric Progression",
            "What is a geometric progression (GP)?",
            "A sequence with a constant difference",
            "A sequence of prime numbers",
            "A sequence where each term is obtained by multiplying the previous term by a constant",
            "A sequence of consecutive integers",
            QuestionOption.C,
            "In a geometric progression, each term is obtained by multiplying the previous term by a fixed number called the common ratio.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Geometric Progression",
            "The fixed number used to multiply consecutive terms in a GP is called the:",
            "Common difference",
            "Common ratio",
            "First term",
            "Factorial",
            QuestionOption.B,
            "The constant multiplier in a geometric progression is called the common ratio.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Geometric Progression",
            "Which of the following is a geometric progression?",
            "2, 5, 8, 11",
            "3, 6, 12, 24",
            "1, 4, 9, 16",
            "5, 10, 15, 20",
            QuestionOption.B,
            "Each term is multiplied by 2 to obtain the next term.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Geometric Progression",
            "What is the common ratio of the GP 4, 12, 36, 108?",
            "2",
            "4",
            "6",
            "3",
            QuestionOption.D,
            "Each term is multiplied by 3 to obtain the next term.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Geometric Progression",
            "Why are geometric progressions important?",
            "They model situations involving repeated multiplication or exponential growth.",
            "They are only used in geometry.",
            "They replace algebraic equations.",
            "They are only useful in statistics.",
            QuestionOption.A,
            "Geometric progressions describe many real-world situations involving exponential change.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Finding Terms and Sum of Geometric Progression
        // ==========================================================

        AddQuestion(
            "Finding Terms and Sum of Geometric Progression",
            "The nth term of a GP is given by:",
            "a + (n - 1)d",
            "arⁿ",
            "ar^(n - 1)",
            "a(n + r)",
            QuestionOption.C,
            "The nth term formula for a geometric progression is a × r^(n - 1).",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Finding Terms and Sum of Geometric Progression",
            "In a GP, the symbol 'r' represents the:",
            "Range",
            "Ratio",
            "Radius",
            "Remainder",
            QuestionOption.B,
            "The symbol r denotes the common ratio.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Finding Terms and Sum of Geometric Progression",
            "Which formula gives the sum of the first n terms of a GP (r ≠ 1)?",
            "S = a + nr",
            "S = a(1 - rⁿ)/(1 - r)",
            "S = n/2[2a + (n - 1)d]",
            "S = arⁿ",
            QuestionOption.B,
            "This is the standard formula for the finite sum of a geometric progression.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Finding Terms and Sum of Geometric Progression",
            "The sum to infinity of a GP exists only when:",
            "r > 1",
            "r = 1",
            "|r| < 1",
            "r = 0",
            QuestionOption.C,
            "An infinite geometric series converges only when the absolute value of the common ratio is less than 1.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Finding Terms and Sum of Geometric Progression",
            "Before finding the nth term of a GP, you must know:",
            "Only the last term",
            "The first term and the common ratio",
            "Only the number of terms",
            "Only the sum",
            QuestionOption.B,
            "Both the first term and common ratio are required to determine any term.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Geometric Progression
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Geometric Progression",
            "Compound interest calculations are based on:",
            "Arithmetic progression",
            "Linear equations",
            "Geometric progression",
            "Quadratic equations",
            QuestionOption.C,
            "Compound interest grows by repeated multiplication, making it a geometric progression.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Geometric Progression",
            "Population growth under a constant growth rate is commonly modelled using:",
            "Geometric progression",
            "Arithmetic progression",
            "Probability",
            "Matrices",
            QuestionOption.A,
            "Population growth often follows exponential patterns represented by geometric progressions.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Geometric Progression",
            "Computer science uses geometric progressions in:",
            "Memory allocation and algorithm analysis",
            "Grammar checking",
            "Weather forecasting only",
            "Drawing circles only",
            QuestionOption.A,
            "Many algorithms and data structures involve exponential growth or reduction.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Geometric Progression",
            "Which real-world situation best represents a geometric progression?",
            "Salary increasing by ₹500 every month",
            "Tree height increasing by 2 cm every year",
            "Money doubling every year",
            "Temperature decreasing by 1°C every hour",
            QuestionOption.C,
            "Doubling is repeated multiplication, which forms a geometric progression.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Geometric Progression",
            "Why is geometric progression important in mathematics and real-world applications?",
            "It models repeated multiplication and exponential change, making it valuable in finance, population studies, computer science, engineering, and scientific modelling.",
            "It is only useful in examinations.",
            "It replaces arithmetic progression completely.",
            "It is only used for sequences.",
            QuestionOption.A,
            "Geometric progressions are fundamental for understanding exponential growth and decay across many disciplines.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Harmonic Progression
        // ==========================================================

        AddQuestion(
            "Introduction to Harmonic Progression",
            "What is a harmonic progression (HP)?",
            "A sequence with a common ratio",
            "A sequence whose reciprocals form an arithmetic progression",
            "A sequence with a common difference",
            "A sequence of prime numbers",
            QuestionOption.B,
            "A harmonic progression is formed by taking the reciprocals of the terms of an arithmetic progression.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Harmonic Progression",
            "The reciprocals of the terms in a harmonic progression form a:",
            "Geometric progression",
            "Fibonacci sequence",
            "Arithmetic progression",
            "Quadratic sequence",
            QuestionOption.C,
            "The defining property of a harmonic progression is that its reciprocals form an arithmetic progression.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Harmonic Progression",
            "Which of the following is a harmonic progression?",
            "1, 2, 3, 4",
            "1, 1/2, 1/3, 1/4",
            "2, 4, 8, 16",
            "3, 6, 9, 12",
            QuestionOption.B,
            "The reciprocals are 1, 2, 3, 4, which form an arithmetic progression.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Harmonic Progression",
            "A harmonic progression is closely related to:",
            "Arithmetic progression",
            "Probability",
            "Matrices",
            "Vectors",
            QuestionOption.A,
            "The reciprocals of a harmonic progression always form an arithmetic progression.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Harmonic Progression",
            "Why is harmonic progression important?",
            "It helps solve problems involving reciprocal quantities and rates.",
            "It is only used in algebra.",
            "It replaces arithmetic progression.",
            "It is only useful for graphing.",
            QuestionOption.A,
            "Harmonic progressions are useful when working with rates, speeds, and reciprocal relationships.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Solving Problems Using Harmonic Progression
        // ==========================================================

        AddQuestion(
            "Solving Problems Using Harmonic Progression",
            "To determine whether a sequence is an HP, you should first:",
            "Find its sum",
            "Take the reciprocal of each term",
            "Multiply every term by 2",
            "Find the square of each term",
            QuestionOption.B,
            "If the reciprocals form an arithmetic progression, then the sequence is a harmonic progression.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Solving Problems Using Harmonic Progression",
            "If the reciprocals of a sequence have a common difference, then the sequence is a:",
            "Geometric progression",
            "Random sequence",
            "Harmonic progression",
            "Quadratic progression",
            QuestionOption.C,
            "This is the defining property of a harmonic progression.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Solving Problems Using Harmonic Progression",
            "The terms of a harmonic progression are generally found by:",
            "Taking the reciprocals of an arithmetic progression",
            "Adding a constant value",
            "Multiplying by a common ratio",
            "Squaring each term",
            QuestionOption.A,
            "An HP is obtained by taking reciprocals of an AP.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Solving Problems Using Harmonic Progression",
            "Which concept is most important when solving HP problems?",
            "Differentiation",
            "Reciprocal values",
            "Matrices",
            "Logarithms",
            QuestionOption.B,
            "Most HP problems involve converting terms into their reciprocals.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Solving Problems Using Harmonic Progression",
            "Before solving a harmonic progression problem, you should identify:",
            "Whether the reciprocals form an arithmetic progression",
            "The graph of the sequence",
            "The determinant",
            "The derivative",
            QuestionOption.A,
            "Checking the reciprocal sequence is the first step in solving HP problems.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Harmonic Progression
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Harmonic Progression",
            "Harmonic progression is commonly used in:",
            "Rate and speed calculations",
            "Drawing circles",
            "Painting",
            "Prime factorization",
            QuestionOption.A,
            "Many rate-based problems naturally involve reciprocal relationships.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Harmonic Progression",
            "Which field commonly uses harmonic progression in the study of sound?",
            "Astronomy",
            "Acoustics",
            "Botany",
            "History",
            QuestionOption.B,
            "Acoustics frequently uses harmonic relationships in the study of sound waves.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Harmonic Progression",
            "Engineers use harmonic progression when analysing:",
            "Reciprocal relationships and rates",
            "Only geometric shapes",
            "Historical records",
            "Literary texts",
            QuestionOption.A,
            "Engineering calculations often involve reciprocal quantities such as resistance and flow rates.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Harmonic Progression",
            "Optics frequently uses harmonic progression concepts when studying:",
            "Light-related measurements",
            "Population growth",
            "Tax calculations",
            "Matrices",
            QuestionOption.A,
            "Some optical calculations involve reciprocal relationships.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Harmonic Progression",
            "Why is harmonic progression important in mathematics and real-world applications?",
            "It helps analyse reciprocal quantities and is widely used in physics, engineering, acoustics, optics, and rate-based calculations.",
            "It is only useful for examinations.",
            "It replaces arithmetic progression completely.",
            "It is only used for number sequences.",
            QuestionOption.A,
            "Harmonic progression provides an effective model for solving problems involving reciprocal values and varying rates.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Sigma Notation
        // ==========================================================

        AddQuestion(
            "Introduction to Sigma Notation",
            "What is sigma notation used for?",
            "To represent multiplication",
            "To represent the sum of a sequence of terms",
            "To solve equations only",
            "To represent division",
            QuestionOption.B,
            "Sigma notation provides a compact way to write the sum of a sequence of numbers.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Sigma Notation",
            "The Greek letter used for summation is:",
            "π",
            "Δ",
            "Σ",
            "θ",
            QuestionOption.C,
            "The uppercase Greek letter Sigma (Σ) denotes summation.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Sigma Notation",
            "In Σ(i = 1 to 5) i, what is the starting value of the index?",
            "0",
            "1",
            "5",
            "10",
            QuestionOption.B,
            "The summation begins with i = 1.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Sigma Notation",
            "In sigma notation, the variable that changes during the summation is called the:",
            "Coefficient",
            "Constant",
            "Index of summation",
            "Exponent",
            QuestionOption.C,
            "The index of summation takes each value from the lower limit to the upper limit.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Sigma Notation",
            "Why is sigma notation useful?",
            "It simplifies the representation of long sums.",
            "It replaces algebra completely.",
            "It is only used in geometry.",
            "It is only useful for calculators.",
            QuestionOption.A,
            "Sigma notation makes lengthy summations concise and easier to understand.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Evaluating Expressions Using Sigma Notation
        // ==========================================================

        AddQuestion(
            "Evaluating Expressions Using Sigma Notation",
            "What is the value of Σ(i = 1 to 4) i?",
            "8",
            "10",
            "12",
            "16",
            QuestionOption.B,
            "1 + 2 + 3 + 4 = 10.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Evaluating Expressions Using Sigma Notation",
            "To evaluate a sigma expression, you should:",
            "Replace the index with each value in the given range and add the results.",
            "Multiply all terms together.",
            "Square each term.",
            "Divide every term by the upper limit.",
            QuestionOption.A,
            "Each value of the index is substituted into the expression and the results are added.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Evaluating Expressions Using Sigma Notation",
            "What is the value of Σ(i = 1 to 3) 2i?",
            "10",
            "14",
            "12",
            "18",
            QuestionOption.C,
            "2(1) + 2(2) + 2(3) = 2 + 4 + 6 = 12.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Evaluating Expressions Using Sigma Notation",
            "The upper number in sigma notation indicates the:",
            "First value of the index",
            "Coefficient",
            "Final value of the index",
            "Answer of the summation",
            QuestionOption.C,
            "The upper limit tells where the summation ends.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Evaluating Expressions Using Sigma Notation",
            "Summation formulas are mainly used to:",
            "Evaluate long sums efficiently",
            "Draw graphs",
            "Solve quadratic equations",
            "Find derivatives only",
            QuestionOption.A,
            "Summation formulas save time when evaluating large series.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Sigma Notation
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Sigma Notation",
            "Sigma notation is widely used in:",
            "Statistics",
            "Painting",
            "Music only",
            "Sports only",
            QuestionOption.A,
            "Statistics frequently uses summations to calculate averages, variances, and other measures.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Sigma Notation",
            "Calculus uses sigma notation primarily to:",
            "Represent finite and infinite sums",
            "Solve grammar problems",
            "Draw triangles",
            "Measure temperature",
            QuestionOption.A,
            "Sigma notation is fundamental in defining series and integrals.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Sigma Notation",
            "Computer science uses sigma notation for:",
            "Analysing algorithms and mathematical computations",
            "Painting graphics manually",
            "Creating maps only",
            "Studying grammar",
            QuestionOption.A,
            "Summation notation is common in algorithm analysis and computational mathematics.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Sigma Notation",
            "Finance commonly uses sigma notation to:",
            "Calculate accumulated values and financial totals",
            "Find square roots only",
            "Draw circles",
            "Measure speed",
            QuestionOption.A,
            "Many financial formulas involve summing payments, investments, or returns.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Sigma Notation",
            "Why is sigma notation important in mathematics and real-world applications?",
            "It provides a compact and efficient way to represent summations used in statistics, calculus, computer science, finance, and scientific computations.",
            "It is only useful for examinations.",
            "It replaces algebra entirely.",
            "It is only used for sequences.",
            QuestionOption.A,
            "Sigma notation is a standard mathematical tool for expressing and evaluating sums across many disciplines.",
            DifficultyLevel.Advance,
            5);// ==========================================================
               // Introduction to Finite Series
               // ==========================================================

        AddQuestion(
            "Introduction to Finite Series",
            "What is a finite series?",
            "A sum with infinitely many terms",
            "A sequence with no end",
            "A sum containing a fixed number of terms",
            "A sequence of prime numbers",
            QuestionOption.C,
            "A finite series consists of a fixed and limited number of terms added together.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Finite Series",
            "A finite series is formed by:",
            "Adding the terms of a sequence",
            "Multiplying all terms together",
            "Finding the average of numbers",
            "Squaring every term",
            QuestionOption.A,
            "A series is obtained by adding the terms of a sequence.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Finite Series",
            "Which of the following is a finite series?",
            "1 + 2 + 3 + 4",
            "1 + 2 + 3 + ...",
            "2, 4, 6, 8",
            "3, 9, 27, 81",
            QuestionOption.A,
            "The sum has only four terms, so it is finite.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Finite Series",
            "The main characteristic of a finite series is that it has:",
            "No first term",
            "An unlimited number of terms",
            "Exactly one term",
            "A limited number of terms",
            QuestionOption.D,
            "A finite series always contains a fixed number of terms.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Finite Series",
            "Why are finite series important?",
            "They help calculate totals from a limited number of values.",
            "They replace algebra completely.",
            "They are only used in geometry.",
            "They are only useful in examinations.",
            QuestionOption.A,
            "Finite series are widely used to calculate totals efficiently in mathematics and real-life applications.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Evaluating and Solving Finite Series
        // ==========================================================

        AddQuestion(
            "Evaluating and Solving Finite Series",
            "To evaluate a finite series, you generally:",
            "Subtract all the terms",
            "Add all the terms together",
            "Multiply every term",
            "Square each term",
            QuestionOption.B,
            "A finite series is evaluated by adding its terms.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Evaluating and Solving Finite Series",
            "Which type of progression commonly has a finite sum formula?",
            "Arithmetic progression",
            "Random sequence",
            "Prime numbers",
            "Matrices",
            QuestionOption.A,
            "Arithmetic progressions have standard formulas for finite sums.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Evaluating and Solving Finite Series",
            "The sum of a finite geometric series depends on:",
            "The first term, common ratio, and number of terms",
            "Only the last term",
            "Only the common ratio",
            "Only the number of terms",
            QuestionOption.A,
            "All three values are required to calculate the sum of a finite geometric series.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Evaluating and Solving Finite Series",
            "Which mathematical tool is commonly used to represent finite sums compactly?",
            "Vectors",
            "Sigma notation",
            "Matrices",
            "Logarithms",
            QuestionOption.B,
            "Sigma notation provides a concise way to write finite summations.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Evaluating and Solving Finite Series",
            "Using formulas to evaluate finite series is helpful because it:",
            "Avoids adding every term individually",
            "Changes the sequence into a graph",
            "Removes the first term",
            "Converts the series into a matrix",
            QuestionOption.A,
            "Summation formulas make calculations much faster and more efficient.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Finite Series
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Finite Series",
            "Finite series are commonly used in:",
            "Finance",
            "Painting",
            "Music only",
            "Sports only",
            QuestionOption.A,
            "Finance uses finite series to calculate payments, investments, and savings.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Finite Series",
            "Engineers use finite series to:",
            "Perform mathematical calculations and modelling",
            "Write essays",
            "Study languages",
            "Design clothing",
            QuestionOption.A,
            "Finite series help engineers solve practical computational problems.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Finite Series",
            "Statistics often uses finite series to:",
            "Calculate totals and averages",
            "Draw circles",
            "Measure temperature",
            "Find square roots only",
            QuestionOption.A,
            "Many statistical formulas involve summing a finite number of observations.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Finite Series",
            "Computer science applies finite series in:",
            "Algorithm analysis and computational calculations",
            "Painting graphics manually",
            "History research",
            "Language translation only",
            QuestionOption.A,
            "Finite summations frequently appear in algorithm design and analysis.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Finite Series",
            "Why are finite series important in mathematics and real-world applications?",
            "They provide efficient methods for calculating finite totals used in finance, engineering, statistics, computer science, and scientific computations.",
            "They are only useful in examinations.",
            "They replace arithmetic progression.",
            "They are only used for algebra homework.",
            QuestionOption.A,
            "Finite series are essential whenever a limited collection of values must be summed efficiently.",
            DifficultyLevel.Advance,
            5);// ==========================================================
               // Introduction to Infinite Series
               // ==========================================================

        AddQuestion(
            "Introduction to Infinite Series",
            "What is an infinite series?",
            "A sum containing exactly 100 terms",
            "A sum containing a finite number of terms",
            "A sum of infinitely many terms",
            "A sequence of prime numbers",
            QuestionOption.C,
            "An infinite series is formed by adding infinitely many terms of a sequence.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Infinite Series",
            "An infinite series may either:",
            "Be increasing only",
            "Converge or diverge",
            "Contain negative numbers only",
            "Be arithmetic only",
            QuestionOption.B,
            "Infinite series are classified based on whether they approach a finite value (converge) or not (diverge).",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Infinite Series",
            "A convergent infinite series is one that:",
            "Has infinitely many terms",
            "Approaches a finite value",
            "Always equals zero",
            "Has only positive terms",
            QuestionOption.B,
            "A convergent series has a finite sum even though it contains infinitely many terms.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Infinite Series",
            "Which of the following is an example of an infinite series?",
            "1 + 2 + 3 + 4",
            "2 + 4 + 6",
            "1 + 1/2 + 1/4 + 1/8 + ...",
            "5 + 10",
            QuestionOption.C,
            "The ellipsis (...) indicates that the terms continue forever.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Infinite Series",
            "Why are infinite series important?",
            "They help model continuous processes and approximate complex mathematical expressions.",
            "They replace algebra completely.",
            "They are only useful for examinations.",
            "They are only used in geometry.",
            QuestionOption.A,
            "Infinite series are fundamental in higher mathematics, especially calculus and analysis.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Convergence and Evaluation of Infinite Series
        // ==========================================================

        AddQuestion(
            "Convergence and Evaluation of Infinite Series",
            "A series is said to converge if:",
            "Its terms become larger forever",
            "Its partial sums approach a finite value",
            "Its first term is zero",
            "It contains infinitely many positive numbers",
            QuestionOption.B,
            "Convergence depends on the behaviour of the partial sums.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Convergence and Evaluation of Infinite Series",
            "A series that does not approach a finite value is called:",
            "Arithmetic",
            "Finite",
            "Divergent",
            "Geometric",
            QuestionOption.C,
            "A divergent series has no finite sum.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Convergence and Evaluation of Infinite Series",
            "The infinite geometric series a + ar + ar² + ... converges only when:",
            "r > 1",
            "|r| < 1",
            "r = 1",
            "r > 0",
            QuestionOption.B,
            "An infinite geometric series converges only if the absolute value of the common ratio is less than 1.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Convergence and Evaluation of Infinite Series",
            "Which mathematical concept is commonly used to determine convergence?",
            "Convergence tests",
            "Prime factorization",
            "Matrix multiplication",
            "Coordinate geometry",
            QuestionOption.A,
            "Various convergence tests help determine whether an infinite series converges or diverges.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Convergence and Evaluation of Infinite Series",
            "Why are convergence tests important?",
            "They determine whether an infinite series has a finite sum.",
            "They find the square root of numbers.",
            "They convert equations into graphs.",
            "They calculate determinants.",
            QuestionOption.A,
            "Convergence tests are essential for analysing infinite series.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Infinite Series
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Infinite Series",
            "Infinite series are widely used in:",
            "Calculus",
            "Painting",
            "History",
            "Grammar",
            QuestionOption.A,
            "Calculus frequently uses infinite series for approximations and function expansions.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Infinite Series",
            "Physicists use infinite series to:",
            "Model waves and physical phenomena",
            "Write essays",
            "Draw maps",
            "Create databases",
            QuestionOption.A,
            "Many physical models rely on infinite series expansions.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Infinite Series",
            "Infinite series are useful in computer science for:",
            "Numerical algorithms and approximations",
            "Painting graphics manually",
            "Studying literature",
            "Designing buildings only",
            QuestionOption.A,
            "Numerical methods and algorithm analysis often involve infinite series.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Infinite Series",
            "Engineers frequently use infinite series to:",
            "Approximate complex functions",
            "Measure rainfall only",
            "Classify animals",
            "Write legal documents",
            QuestionOption.A,
            "Series expansions simplify complicated engineering calculations.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Infinite Series",
            "Why are infinite series important in mathematics and real-world applications?",
            "They provide powerful tools for approximating functions and solving problems in calculus, physics, engineering, computer science, and numerical analysis.",
            "They are only useful for examinations.",
            "They replace finite series completely.",
            "They are only used in geometry.",
            QuestionOption.A,
            "Infinite series are essential for modelling continuous systems and solving advanced mathematical problems.",
            DifficultyLevel.Advance,
            5);// ==========================================================
               // Introduction to Binomial Expansion
               // ==========================================================

        AddQuestion(
            "Introduction to Binomial Expansion",
            "What is the purpose of the binomial theorem?",
            "To solve quadratic equations",
            "To expand powers of a binomial expression",
            "To find square roots",
            "To simplify fractions",
            QuestionOption.B,
            "The binomial theorem provides a systematic method for expanding expressions like (a + b)ⁿ.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Binomial Expansion",
            "A binomial expression contains:",
            "One term",
            "Two terms",
            "Three terms",
            "Four terms",
            QuestionOption.B,
            "A binomial is an algebraic expression consisting of exactly two terms.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Binomial Expansion",
            "Which of the following is a binomial?",
            "x²",
            "x + 5",
            "3xyz",
            "7",
            QuestionOption.B,
            "The expression x + 5 contains exactly two terms.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Binomial Expansion",
            "The coefficients in a binomial expansion are called:",
            "Arithmetic coefficients",
            "Polynomial factors",
            "Binomial coefficients",
            "Common ratios",
            QuestionOption.C,
            "The numbers appearing in the expansion are known as binomial coefficients.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Binomial Expansion",
            "Why is binomial expansion important?",
            "It provides an efficient way to expand powers of binomial expressions.",
            "It replaces algebra completely.",
            "It is only used in geometry.",
            "It is only useful for examinations.",
            QuestionOption.A,
            "Binomial expansion simplifies calculations involving powers of algebraic expressions.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applying the Binomial Theorem
        // ==========================================================

        AddQuestion(
            "Applying the Binomial Theorem",
            "Which triangle is commonly used to determine binomial coefficients?",
            "Pascal's Triangle",
            "Bermuda Triangle",
            "Right Triangle",
            "Equilateral Triangle",
            QuestionOption.A,
            "Pascal's Triangle provides the coefficients used in binomial expansions.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applying the Binomial Theorem",
            "The expansion of (a + b)² is:",
            "a² + b²",
            "a² + 2ab + b²",
            "a² - 2ab + b²",
            "2a + 2b",
            QuestionOption.B,
            "Applying the binomial theorem gives a² + 2ab + b².",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applying the Binomial Theorem",
            "The general term in a binomial expansion contains:",
            "A binomial coefficient",
            "Only variables",
            "Only constants",
            "Only exponents",
            QuestionOption.A,
            "Each term contains an appropriate binomial coefficient along with powers of the variables.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applying the Binomial Theorem",
            "Pascal's Triangle helps to:",
            "Find derivatives",
            "Determine binomial coefficients",
            "Calculate logarithms",
            "Solve matrices",
            QuestionOption.B,
            "Each row of Pascal's Triangle gives the coefficients for a binomial expansion.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applying the Binomial Theorem",
            "The binomial theorem makes expanding large powers easier because it:",
            "Provides a direct expansion formula",
            "Uses graph plotting",
            "Converts equations into matrices",
            "Finds square roots automatically",
            QuestionOption.A,
            "The theorem eliminates repeated multiplication by providing a direct formula.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Binomial Expansion
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Binomial Expansion",
            "Binomial expansion is commonly used in:",
            "Probability",
            "Painting",
            "History",
            "Music",
            QuestionOption.A,
            "Binomial coefficients are widely used in probability calculations.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Binomial Expansion",
            "Calculus often uses binomial expansion to:",
            "Approximate algebraic expressions",
            "Measure distances",
            "Draw circles",
            "Calculate averages only",
            QuestionOption.A,
            "Binomial expansion is useful for approximating functions in calculus.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Binomial Expansion",
            "Computer science applies binomial expansion in:",
            "Algorithm analysis and computational mathematics",
            "Writing essays",
            "Painting graphics manually",
            "Weather forecasting only",
            QuestionOption.A,
            "Many computational algorithms use combinatorial concepts based on binomial coefficients.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Binomial Expansion",
            "Engineers use binomial expansion to:",
            "Simplify mathematical models and approximations",
            "Study literature",
            "Translate languages",
            "Design clothing",
            QuestionOption.A,
            "Engineering calculations often involve algebraic approximations using binomial expansion.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Binomial Expansion",
            "Why is binomial expansion important in mathematics and real-world applications?",
            "It simplifies algebraic calculations and is widely used in probability, calculus, computer science, engineering, and scientific modelling.",
            "It is only useful in examinations.",
            "It replaces algebra completely.",
            "It is only used for polynomials of degree two.",
            QuestionOption.A,
            "The binomial theorem is a powerful mathematical tool with applications across many scientific disciplines.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Mathematical Induction
        // ==========================================================

        AddQuestion(
            "Introduction to Mathematical Induction",
            "What is the primary purpose of mathematical induction?",
            "To solve quadratic equations",
            "To prove statements involving natural numbers",
            "To find derivatives",
            "To simplify fractions",
            QuestionOption.B,
            "Mathematical induction is a proof technique used to establish that a statement is true for all natural numbers.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Mathematical Induction",
            "The first step in mathematical induction is called the:",
            "Inductive hypothesis",
            "Final proof",
            "Base case",
            "Generalization",
            QuestionOption.C,
            "The base case verifies that the statement is true for the initial value, usually n = 1.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Mathematical Induction",
            "After proving the base case, the next step is to:",
            "Draw a graph",
            "Assume the statement is true for n = k",
            "Differentiate the equation",
            "Find the inverse",
            QuestionOption.B,
            "This assumption is called the inductive hypothesis.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Mathematical Induction",
            "The inductive step proves the statement for:",
            "n = 0 only",
            "n = k",
            "n = k + 1",
            "All even numbers only",
            QuestionOption.C,
            "The goal is to show that if the statement is true for n = k, then it is also true for n = k + 1.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Mathematical Induction",
            "Why is mathematical induction important?",
            "It provides a systematic way to prove statements for all natural numbers.",
            "It replaces algebra completely.",
            "It is only useful for geometry.",
            "It is only used in examinations.",
            QuestionOption.A,
            "Mathematical induction is one of the most important proof techniques in mathematics.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Proving Statements Using Mathematical Induction
        // ==========================================================

        AddQuestion(
            "Proving Statements Using Mathematical Induction",
            "What assumption is made during the inductive hypothesis?",
            "The statement is true for n = k",
            "The statement is false for n = k",
            "The statement is true only for n = 1",
            "The statement is true for all real numbers",
            QuestionOption.A,
            "The inductive hypothesis assumes the statement holds for an arbitrary positive integer k.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Proving Statements Using Mathematical Induction",
            "The final goal of the inductive step is to prove the statement for:",
            "n = k²",
            "n = k + 1",
            "n = 2k",
            "n = k − 1",
            QuestionOption.B,
            "Showing the statement is true for k + 1 completes the induction step.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Proving Statements Using Mathematical Induction",
            "Mathematical induction is commonly used to prove:",
            "Algebraic identities",
            "Weather forecasts",
            "Chemical reactions",
            "Historical facts",
            QuestionOption.A,
            "Induction is frequently applied to algebraic identities and sequence formulas.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Proving Statements Using Mathematical Induction",
            "Which property can also be proved using mathematical induction?",
            "Divisibility",
            "Colour combinations",
            "Population statistics only",
            "Temperature conversions",
            QuestionOption.A,
            "Many divisibility results are naturally proved using induction.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Proving Statements Using Mathematical Induction",
            "A proof by mathematical induction is complete only after:",
            "The base case and inductive step are both proved",
            "Only the base case is proved",
            "Only the inductive hypothesis is written",
            "A graph is drawn",
            QuestionOption.A,
            "Both the base case and inductive step are essential for a valid induction proof.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Mathematical Induction
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Mathematical Induction",
            "Mathematical induction is widely used in:",
            "Computer science",
            "Painting",
            "Music theory",
            "Photography",
            QuestionOption.A,
            "Many algorithms and recursive structures are proved correct using induction.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Mathematical Induction",
            "In mathematics, induction is commonly used to prove:",
            "Theorems involving natural numbers",
            "Chemical formulas",
            "Geographical maps",
            "Language grammar",
            QuestionOption.A,
            "Induction is designed for proving propositions involving positive integers.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Mathematical Induction",
            "Algorithm correctness is often established using:",
            "Mathematical induction",
            "Probability only",
            "Coordinate geometry",
            "Matrices only",
            QuestionOption.A,
            "Recursive algorithms are commonly proved correct through induction.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Mathematical Induction",
            "Mathematical induction is an important topic in:",
            "Discrete mathematics",
            "Painting",
            "Architecture only",
            "Physical education",
            QuestionOption.A,
            "Discrete mathematics makes extensive use of induction proofs.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Mathematical Induction",
            "Why is mathematical induction important in mathematics and real-world applications?",
            "It provides a rigorous proof technique used in mathematics, computer science, algorithms, and discrete structures to verify statements that hold for all natural numbers.",
            "It is only useful for examinations.",
            "It replaces all other proof methods.",
            "It is only used for algebraic equations.",
            QuestionOption.A,
            "Mathematical induction is a fundamental proof technique with applications in theoretical and practical fields.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Matrix Basics
        // ==========================================================

        AddQuestion(
            "Introduction to Matrix Basics",
            "A matrix is best described as:",
            "A single number",
            "A collection of equations",
            "A rectangular arrangement of numbers in rows and columns",
            "A geometric figure",
            QuestionOption.C,
            "A matrix is a rectangular array of numbers arranged in rows and columns.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Matrix Basics",
            "The order of a matrix is written as:",
            "Columns × Rows",
            "Rows × Columns",
            "Rows + Columns",
            "Rows − Columns",
            QuestionOption.B,
            "The order of a matrix is expressed as the number of rows × the number of columns.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Matrix Basics",
            "A matrix with 3 rows and 2 columns has the order:",
            "2 × 3",
            "3 × 2",
            "5 × 1",
            "6 × 2",
            QuestionOption.B,
            "The matrix has 3 rows and 2 columns, so its order is 3 × 2.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Matrix Basics",
            "Rows in a matrix are arranged:",
            "Vertically",
            "Diagonally",
            "Randomly",
            "Horizontally",
            QuestionOption.D,
            "Rows extend horizontally across a matrix.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Matrix Basics",
            "Matrices are primarily used to:",
            "Organize and manipulate numerical data",
            "Measure physical distances",
            "Calculate probabilities only",
            "Draw geometric figures",
            QuestionOption.A,
            "Matrices provide an efficient way to organize and perform operations on numerical data.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Elements and Representation of Matrices
        // ==========================================================

        AddQuestion(
            "Elements and Representation of Matrices",
            "An individual value inside a matrix is called a:",
            "Variable",
            "Element",
            "Coefficient",
            "Factor",
            QuestionOption.B,
            "Each number inside a matrix is known as an element.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Elements and Representation of Matrices",
            "The element a₂₃ is located in:",
            "Row 2, Column 3",
            "Row 3, Column 2",
            "Column 2 only",
            "Row 1, Column 3",
            QuestionOption.A,
            "The first subscript represents the row, and the second represents the column.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Elements and Representation of Matrices",
            "A matrix with the same number of rows and columns is called a:",
            "Diagonal matrix",
            "Identity matrix",
            "Square matrix",
            "Column matrix",
            QuestionOption.C,
            "A square matrix has an equal number of rows and columns.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Elements and Representation of Matrices",
            "How many elements are in a 2 × 4 matrix?",
            "4",
            "6",
            "8",
            "10",
            QuestionOption.C,
            "A 2 × 4 matrix contains 2 × 4 = 8 elements.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Elements and Representation of Matrices",
            "Matrices are classified based on:",
            "Their size and structure",
            "Their colour",
            "Their position on paper",
            "Their age",
            QuestionOption.A,
            "Matrices are classified by their dimensions and structural properties.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Matrix Basics
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Matrix Basics",
            "Matrices are widely used in:",
            "Computer graphics",
            "Cooking",
            "Photography",
            "Literature",
            QuestionOption.A,
            "Matrices are fundamental in computer graphics for transformations and rendering.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Matrix Basics",
            "Which field commonly uses matrices for handling datasets?",
            "Data science",
            "History",
            "Music",
            "Linguistics",
            QuestionOption.A,
            "Data science uses matrices to organize and process large amounts of numerical data.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Matrix Basics",
            "Machine learning algorithms often represent data using:",
            "Matrices",
            "Circles",
            "Triangles",
            "Fractions only",
            QuestionOption.A,
            "Matrices efficiently store and manipulate training data in machine learning.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Matrix Basics",
            "Engineers use matrices to:",
            "Solve systems of equations and model problems",
            "Write novels",
            "Compose music",
            "Study grammar",
            QuestionOption.A,
            "Matrices are widely used in engineering calculations and modelling.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Matrix Basics",
            "Why are matrices important in modern mathematics and technology?",
            "They organize data efficiently and support applications in computer graphics, engineering, data science, and machine learning.",
            "They are only useful in school mathematics.",
            "They replace all algebraic methods.",
            "They are only used to store numbers.",
            QuestionOption.A,
            "Matrices form the foundation of many computational and scientific applications.",
            DifficultyLevel.Advance,
            5);// ==========================================================
               // Introduction to Types of Matrices
               // ==========================================================

        AddQuestion(
            "Introduction to Types of Matrices",
            "A matrix having only one row is called a:",
            "Column matrix",
            "Square matrix",
            "Row matrix",
            "Diagonal matrix",
            QuestionOption.C,
            "A row matrix consists of exactly one row.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Types of Matrices",
            "A matrix having only one column is called a:",
            "Identity matrix",
            "Column matrix",
            "Rectangular matrix",
            "Zero matrix",
            QuestionOption.B,
            "A column matrix consists of exactly one column.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Types of Matrices",
            "A square matrix has:",
            "Equal rows and columns",
            "Only one row",
            "More rows than columns",
            "More columns than rows",
            QuestionOption.A,
            "A square matrix has the same number of rows and columns.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Types of Matrices",
            "Which matrix has all of its elements equal to zero?",
            "Identity matrix",
            "Scalar matrix",
            "Diagonal matrix",
            "Zero matrix",
            QuestionOption.D,
            "Every element of a zero matrix is 0.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Types of Matrices",
            "An identity matrix has:",
            "1s on the main diagonal and 0s elsewhere",
            "All elements equal to 1",
            "Only diagonal elements equal to 2",
            "No diagonal elements",
            QuestionOption.A,
            "In an identity matrix, diagonal entries are 1 while all other entries are 0.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Properties and Classification of Matrices
        // ==========================================================

        AddQuestion(
            "Properties and Classification of Matrices",
            "A rectangular matrix is one in which:",
            "Rows and columns are unequal",
            "Rows and columns are equal",
            "All elements are zero",
            "All diagonal elements are one",
            QuestionOption.A,
            "A rectangular matrix has a different number of rows and columns.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Properties and Classification of Matrices",
            "A diagonal matrix is a square matrix in which:",
            "Only diagonal elements may be non-zero",
            "Every element is non-zero",
            "All rows are identical",
            "All columns are identical",
            QuestionOption.A,
            "All off-diagonal elements of a diagonal matrix are zero.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Properties and Classification of Matrices",
            "A scalar matrix is a:",
            "Diagonal matrix with equal diagonal elements",
            "Zero matrix",
            "Rectangular matrix",
            "Column matrix",
            QuestionOption.A,
            "A scalar matrix is a diagonal matrix whose diagonal entries are all equal.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Properties and Classification of Matrices",
            "Which of the following is always a square matrix?",
            "Identity matrix",
            "Row matrix",
            "Column matrix",
            "Rectangular matrix",
            QuestionOption.A,
            "Identity matrices are defined only for square matrices.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Properties and Classification of Matrices",
            "Matrices are classified mainly according to:",
            "Their dimensions and element arrangement",
            "Their colour",
            "Their age",
            "Their notation style",
            QuestionOption.A,
            "The number of rows, columns, and arrangement of elements determine the type of matrix.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Types of Matrices
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Types of Matrices",
            "Identity matrices are commonly used in:",
            "Matrix multiplication",
            "Drawing graphs",
            "Probability only",
            "Geometry only",
            QuestionOption.A,
            "The identity matrix acts as the multiplicative identity in matrix multiplication.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Types of Matrices",
            "Diagonal matrices simplify calculations because:",
            "Most off-diagonal elements are zero",
            "They have no rows",
            "Every element is one",
            "They are rectangular",
            QuestionOption.A,
            "Having zeros outside the main diagonal makes many computations easier.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Types of Matrices",
            "Which field commonly uses matrices to represent image transformations?",
            "Computer graphics",
            "Literature",
            "Music",
            "Biology",
            QuestionOption.A,
            "Transformation matrices are widely used in computer graphics.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Types of Matrices",
            "Matrices play an important role in:",
            "Machine learning and scientific computing",
            "Painting only",
            "Poetry",
            "Sports statistics only",
            QuestionOption.A,
            "Matrices are fundamental in machine learning, simulations, and scientific computations.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Types of Matrices",
            "Why is it important to understand different types of matrices?",
            "Different matrix types have unique properties that make them useful in engineering, graphics, cryptography, machine learning, and mathematical computations.",
            "They are only useful for examinations.",
            "All matrices behave exactly the same.",
            "Only square matrices have practical applications.",
            QuestionOption.A,
            "Choosing the appropriate matrix type simplifies computations and enables many real-world applications.",
            DifficultyLevel.Advance,
            5);// ==========================================================
               // Introduction to Matrix Operations
               // ==========================================================

        AddQuestion(
            "Introduction to Matrix Operations",
            "Which operation can only be performed on matrices of the same order?",
            "Matrix multiplication",
            "Matrix addition",
            "Scalar multiplication",
            "Transpose",
            QuestionOption.B,
            "Matrices must have the same dimensions to be added or subtracted.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Matrix Operations",
            "Scalar multiplication means:",
            "Multiplying a matrix by a single number",
            "Adding two matrices",
            "Multiplying two matrices",
            "Finding the determinant",
            QuestionOption.A,
            "In scalar multiplication, every element of the matrix is multiplied by the same number.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Matrix Operations",
            "Which operation is generally NOT commutative?",
            "Matrix addition",
            "Scalar multiplication",
            "Matrix multiplication",
            "Adding zero matrices",
            QuestionOption.C,
            "In general, AB ≠ BA for matrices.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Matrix Operations",
            "If A is a 2×3 matrix and B is a 3×4 matrix, the product AB has order:",
            "2 × 4",
            "3 × 3",
            "2 × 3",
            "4 × 2",
            QuestionOption.A,
            "The resulting matrix has the rows of A and columns of B.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Matrix Operations",
            "Matrix operations are important because they:",
            "Provide efficient methods for solving mathematical and computational problems",
            "Can only be used in geometry",
            "Replace algebra completely",
            "Are only useful in examinations",
            QuestionOption.A,
            "Matrix operations are fundamental in mathematics, engineering, and computer science.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Performing Matrix Operations
        // ==========================================================

        AddQuestion(
            "Performing Matrix Operations",
            "Two matrices can be added only if they have:",
            "The same order",
            "The same determinant",
            "The same trace",
            "The same transpose",
            QuestionOption.A,
            "Addition and subtraction require both matrices to have identical dimensions.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Performing Matrix Operations",
            "For the product AB to exist, the number of columns of A must equal:",
            "The number of rows of B",
            "The number of columns of B",
            "The number of rows of A",
            "The determinant of B",
            QuestionOption.A,
            "This is the compatibility condition for matrix multiplication.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Performing Matrix Operations",
            "Which property is always true for matrix addition?",
            "A + B = B + A",
            "AB = BA",
            "A - B = B - A",
            "AB = A + B",
            QuestionOption.A,
            "Matrix addition satisfies the commutative property.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Performing Matrix Operations",
            "Multiplying every element of a matrix by 5 is called:",
            "Scalar multiplication",
            "Matrix multiplication",
            "Transpose",
            "Matrix inversion",
            QuestionOption.A,
            "A scalar multiplies every element of the matrix.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Performing Matrix Operations",
            "When performing matrix multiplication, each element is obtained by:",
            "Adding corresponding elements",
            "Multiplying corresponding rows only",
            "Taking the dot product of a row and a column",
            "Subtracting corresponding columns",
            QuestionOption.C,
            "Each entry is found by multiplying corresponding row and column elements and summing the products.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Matrix Operations
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Matrix Operations",
            "Matrix multiplication is widely used in:",
            "Computer graphics",
            "Cooking",
            "Literature",
            "Poetry",
            QuestionOption.A,
            "Transformations such as rotation and scaling are performed using matrix multiplication.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Matrix Operations",
            "Robots use matrix operations to:",
            "Represent movement and position",
            "Write essays",
            "Create music",
            "Cook food",
            QuestionOption.A,
            "Matrices are used to model robotic motion and coordinate transformations.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Matrix Operations",
            "Machine learning algorithms commonly perform:",
            "Large-scale matrix operations",
            "Only scalar multiplication",
            "Only subtraction",
            "Only determinants",
            QuestionOption.A,
            "Machine learning relies heavily on matrix computations for handling data and model parameters.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Matrix Operations",
            "Scientific computing frequently uses matrix operations to:",
            "Solve systems of equations and numerical models",
            "Translate languages",
            "Study history",
            "Write poems",
            QuestionOption.A,
            "Matrices are essential in simulations, modelling, and solving linear systems.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Matrix Operations",
            "Why are matrix operations important in modern technology?",
            "They enable efficient computations used in engineering, robotics, graphics, machine learning, and scientific computing.",
            "They are only useful in classroom exercises.",
            "They replace all mathematical formulas.",
            "They are only used for square matrices.",
            QuestionOption.A,
            "Matrix operations form the mathematical foundation of many modern computational systems.",
            DifficultyLevel.Advance,
            5);// ==========================================================
               // Introduction to Determinants
               // ==========================================================

        AddQuestion(
            "Introduction to Determinants",
            "A determinant is defined only for:",
            "Rectangular matrices",
            "Square matrices",
            "Row matrices",
            "Column matrices",
            QuestionOption.B,
            "Determinants are defined only for square matrices.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Determinants",
            "The determinant of a 2 × 2 matrix [a b; c d] is:",
            "ad + bc",
            "ab - cd",
            "ad - bc",
            "ac - bd",
            QuestionOption.C,
            "For a 2 × 2 matrix, the determinant is calculated as ad - bc.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Determinants",
            "A determinant is commonly represented by:",
            "|A|",
            "A²",
            "A⁻¹",
            "Aᵀ",
            QuestionOption.A,
            "The notation |A| is commonly used to represent the determinant of matrix A.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Determinants",
            "If the determinant of a square matrix is zero, then the matrix is:",
            "Identity",
            "Diagonal",
            "Singular",
            "Symmetric",
            QuestionOption.C,
            "A matrix with determinant zero is called a singular matrix.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Determinants",
            "Determinants are mainly used to:",
            "Analyse square matrices and solve linear systems",
            "Draw geometric figures",
            "Find percentages",
            "Convert fractions",
            QuestionOption.A,
            "Determinants help determine matrix properties and solve systems of equations.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Properties and Evaluation of Determinants
        // ==========================================================

        AddQuestion(
            "Properties and Evaluation of Determinants",
            "A minor of an element is obtained by:",
            "Deleting its row and column",
            "Multiplying the row by 2",
            "Adding all elements",
            "Finding the transpose",
            QuestionOption.A,
            "A minor is obtained by removing the row and column containing the selected element.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Properties and Evaluation of Determinants",
            "A cofactor differs from a minor because it:",
            "Includes a positive or negative sign",
            "Always equals zero",
            "Uses only diagonal elements",
            "Can only be found for 2 × 2 matrices",
            QuestionOption.A,
            "A cofactor is the minor multiplied by (-1)^(i+j).",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Properties and Evaluation of Determinants",
            "Which method is commonly used to evaluate a 3 × 3 determinant?",
            "Expansion by cofactors",
            "Long division",
            "Integration",
            "Factorization only",
            QuestionOption.A,
            "Expansion by cofactors is a standard method for evaluating 3 × 3 determinants.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Properties and Evaluation of Determinants",
            "Interchanging two rows of a determinant:",
            "Leaves it unchanged",
            "Multiplies it by -1",
            "Makes it zero",
            "Doubles its value",
            QuestionOption.B,
            "Swapping two rows changes the sign of the determinant.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Properties and Evaluation of Determinants",
            "A determinant having two identical rows is always:",
            "One",
            "Negative",
            "Twice its value",
            "Zero",
            QuestionOption.D,
            "If two rows (or columns) are identical, the determinant equals zero.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Determinants
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Determinants",
            "Determinants are commonly used to:",
            "Solve systems of linear equations",
            "Write essays",
            "Draw pie charts",
            "Calculate averages only",
            QuestionOption.A,
            "Determinants are used in methods such as Cramer's Rule for solving linear systems.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Determinants",
            "In geometry, determinants can be used to calculate:",
            "Area",
            "Temperature",
            "Population",
            "Speed only",
            QuestionOption.A,
            "Determinants help compute the area of triangles and other geometric figures.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Determinants",
            "Engineers use determinants in:",
            "Structural analysis and system modelling",
            "Language translation",
            "Music composition",
            "Cooking recipes",
            QuestionOption.A,
            "Determinants appear in many engineering calculations involving matrices.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Determinants",
            "Computer graphics use determinants for:",
            "Coordinate transformations",
            "Grammar checking",
            "Audio recording",
            "Essay writing",
            QuestionOption.A,
            "Determinants help determine scaling, orientation, and transformations in graphics.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Determinants",
            "Why are determinants important in mathematics and technology?",
            "They help solve linear systems, analyse matrices, and support applications in geometry, engineering, physics, and computer graphics.",
            "They are only useful in examinations.",
            "They replace all matrix operations.",
            "They are only used with 2 × 2 matrices.",
            QuestionOption.A,
            "Determinants are fundamental tools with applications across mathematics, science, and engineering.",
            DifficultyLevel.Advance,
            5);// ==========================================================
               // Introduction to Inverse Matrix
               // ==========================================================

        AddQuestion(
            "Introduction to Inverse Matrix",
            "An inverse matrix exists only for:",
            "Rectangular matrices",
            "Square non-singular matrices",
            "Row matrices",
            "Zero matrices",
            QuestionOption.B,
            "Only square matrices with a non-zero determinant have an inverse.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Inverse Matrix",
            "If a matrix A has an inverse, then:",
            "AA⁻¹ = I",
            "AA⁻¹ = 0",
            "AA⁻¹ = A",
            "AA⁻¹ = A²",
            QuestionOption.A,
            "Multiplying a matrix by its inverse gives the identity matrix.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Inverse Matrix",
            "A matrix with determinant zero is:",
            "Invertible",
            "Orthogonal",
            "Singular",
            "Identity",
            QuestionOption.C,
            "A singular matrix has no inverse because its determinant is zero.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Inverse Matrix",
            "The inverse of a matrix is represented by:",
            "A²",
            "Aᵀ",
            "A⁻¹",
            "|A|",
            QuestionOption.C,
            "The notation A⁻¹ represents the inverse of matrix A.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Inverse Matrix",
            "Inverse matrices are mainly used to:",
            "Solve matrix equations and systems of linear equations",
            "Calculate percentages",
            "Find graph areas",
            "Convert fractions",
            QuestionOption.A,
            "Inverse matrices provide an efficient way to solve equations such as AX = B.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Finding and Verifying Inverse Matrices
        // ==========================================================

        AddQuestion(
            "Finding and Verifying Inverse Matrices",
            "Which method can be used to find the inverse of a matrix?",
            "Using determinants and adjoints",
            "Long division",
            "Integration",
            "Prime factorization",
            QuestionOption.A,
            "The adjoint method is a standard technique for finding matrix inverses.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Finding and Verifying Inverse Matrices",
            "Another method for finding an inverse matrix is:",
            "Elementary row operations",
            "Differentiation",
            "Graph plotting",
            "Polynomial division",
            QuestionOption.A,
            "The Gauss-Jordan elimination method uses elementary row operations.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Finding and Verifying Inverse Matrices",
            "To verify that B is the inverse of A, you should check whether:",
            "AB = I",
            "AB = A",
            "AB = 0",
            "AB = B",
            QuestionOption.A,
            "If the product of A and B is the identity matrix, then B is the inverse of A.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Finding and Verifying Inverse Matrices",
            "Before finding the inverse of a matrix, you should first verify that:",
            "Its determinant is non-zero",
            "It has equal rows",
            "It is rectangular",
            "Its trace is zero",
            QuestionOption.A,
            "Only matrices with non-zero determinants are invertible.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Finding and Verifying Inverse Matrices",
            "If |A| = 0, then:",
            "The inverse of A exists",
            "The inverse of A does not exist",
            "A is an identity matrix",
            "A is a scalar matrix",
            QuestionOption.B,
            "A zero determinant indicates that the matrix is singular and has no inverse.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Applications and Practice of Inverse Matrices
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Inverse Matrices",
            "Inverse matrices are commonly used to:",
            "Solve systems of linear equations",
            "Draw circles",
            "Calculate percentages",
            "Measure distances",
            QuestionOption.A,
            "Many matrix equations are solved by multiplying both sides by the inverse matrix.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Inverse Matrices",
            "Which field uses inverse matrices for transformations?",
            "Computer graphics",
            "Literature",
            "Music",
            "Cooking",
            QuestionOption.A,
            "Inverse transformations are widely used in computer graphics and image processing.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Inverse Matrices",
            "Inverse matrices are important in:",
            "Cryptography",
            "Painting",
            "Poetry",
            "Journalism",
            QuestionOption.A,
            "Many encryption algorithms rely on invertible matrices.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Inverse Matrices",
            "Machine learning algorithms often use inverse matrices in:",
            "Linear regression and optimization",
            "Grammar correction",
            "Photo editing only",
            "Sound recording",
            QuestionOption.A,
            "Inverse matrices appear in several machine learning algorithms and numerical methods.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Inverse Matrices",
            "Why are inverse matrices important in mathematics and technology?",
            "They help solve matrix equations and support applications in engineering, graphics, cryptography, machine learning, and scientific computing.",
            "They are only useful in examinations.",
            "They replace determinants completely.",
            "They are only used with 2 × 2 matrices.",
            QuestionOption.A,
            "Inverse matrices are fundamental tools for solving many mathematical and computational problems.",
            DifficultyLevel.Advance,
            5);

        // ==========================
        // Introduction to Rank of Matrix
        // ==========================

        AddQuestion(
            "Introduction to Rank of Matrix",
            "What does the rank of a matrix represent?",
            "The determinant of the matrix.",
            "The number of linearly independent rows or columns.",
            "The total number of elements.",
            "The trace of the matrix.",
            QuestionOption.B,
            "The rank of a matrix is the maximum number of linearly independent rows or columns.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Rank of Matrix",
            "What is the maximum possible rank of a 3 × 5 matrix?",
            "8",
            "5",
            "3",
            "15",
            QuestionOption.C,
            "The maximum rank of a matrix is the smaller of the number of rows and columns.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Rank of Matrix",
            "What is the rank of a zero matrix?",
            "0",
            "1",
            "Equal to the number of rows",
            "Cannot be determined",
            QuestionOption.A,
            "A zero matrix has no linearly independent rows or columns, so its rank is 0.",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Rank of Matrix",
            "Matrix rank is defined for:",
            "Only square matrices.",
            "Only invertible matrices.",
            "Only diagonal matrices.",
            "All matrices.",
            QuestionOption.D,
            "Every matrix has a rank regardless of its dimensions.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Rank of Matrix",
            "If all rows of a matrix are linearly independent, then its rank is:",
            "Equal to the number of rows.",
            "Always 1.",
            "Always equal to the number of columns.",
            "0",
            QuestionOption.A,
            "The rank equals the number of linearly independent rows.",
            DifficultyLevel.Begineer,
            5);

        // ==========================
        // Finding the Rank of a Matrix
        // ==========================

        AddQuestion(
            "Finding the Rank of a Matrix",
            "Which method is commonly used to determine the rank of a matrix?",
            "Differentiation",
            "Integration",
            "Row reduction to echelon form",
            "Factorisation",
            QuestionOption.C,
            "Row reduction converts a matrix into echelon form, making the rank easy to determine.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Finding the Rank of a Matrix",
            "The rank of a matrix is equal to the number of:",
            "Diagonal elements",
            "Non-zero rows in row echelon form",
            "Columns",
            "Zero elements",
            QuestionOption.B,
            "After row reduction, the number of non-zero rows equals the rank.",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Finding the Rank of a Matrix",
            "If a 4 × 4 matrix reduces to three non-zero rows, its rank is:",
            "2",
            "4",
            "1",
            "3",
            QuestionOption.D,
            "The rank equals the number of non-zero rows after row reduction.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Finding the Rank of a Matrix",
            "Which of the following can also be used to determine the rank of a matrix?",
            "Eigenvalues only",
            "Matrix trace",
            "Minors",
            "Transpose",
            QuestionOption.C,
            "The highest-order non-zero minor determines the rank of a matrix.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Finding the Rank of a Matrix",
            "Elementary row operations:",
            "Always change the rank.",
            "Always increase the rank.",
            "Always decrease the rank.",
            "Preserve the rank of the matrix.",
            QuestionOption.D,
            "Elementary row operations do not affect the rank of a matrix.",
            DifficultyLevel.Intermediate,
            5);

        // ==========================
        // Applications and Practice of Matrix Rank
        // ==========================

        AddQuestion(
            "Applications and Practice of Matrix Rank",
            "Matrix rank is used to determine:",
            "The colour of a graph.",
            "The consistency of a system of linear equations.",
            "The transpose of a matrix.",
            "The sum of matrix elements.",
            QuestionOption.B,
            "The ranks of the coefficient and augmented matrices help determine whether a system has no solution, one solution, or infinitely many solutions.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Matrix Rank",
            "In machine learning, matrix rank is useful for:",
            "Generating random numbers.",
            "Data compression and feature analysis.",
            "Changing image colours.",
            "Sorting arrays.",
            QuestionOption.B,
            "Rank helps identify redundant information and reduce data dimensions.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Matrix Rank",
            "If the rank equals the number of variables in a consistent system, the system has:",
            "Infinitely many solutions.",
            "No solution.",
            "A unique solution.",
            "Exactly two solutions.",
            QuestionOption.C,
            "A consistent system with full rank has a unique solution.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Matrix Rank",
            "Which field commonly applies matrix rank?",
            "Engineering",
            "Computer graphics",
            "Data science",
            "All of the above",
            QuestionOption.D,
            "Matrix rank is widely used in engineering, graphics, machine learning, and data science.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Matrix Rank",
            "Why is matrix rank important in mathematics and technology?",
            "It is only useful for solving examination questions.",
            "It replaces determinants completely.",
            "It helps analyse linear systems and supports applications in engineering, graphics, machine learning, and scientific computing.",
            "It is only used for square matrices.",
            QuestionOption.C,
            "Matrix rank is fundamental in solving linear systems and analysing data across many scientific and technological fields.",
            DifficultyLevel.Advance,
            5);// ==========================================================
               // Introduction to Systems of Linear Equations
               // ==========================================================

        AddQuestion(
            "Introduction to Systems of Linear Equations",
            "What is a system of linear equations?",
            "A collection of two or more linear equations involving the same variables.",
            "A single quadratic equation.",
            "A set of unrelated algebraic expressions.",
            "A polynomial with only one variable.",
            QuestionOption.A,
            "A system of linear equations consists of multiple linear equations that are solved together.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Systems of Linear Equations",
            "How are systems of linear equations commonly represented graphically?",
            "As intersecting, parallel, or coincident lines on a coordinate plane.",
            "As circles with different radii.",
            "As parabolas only.",
            "As exponential curves.",
            QuestionOption.A,
            "Each linear equation represents a line, and the solution depends on how the lines intersect.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Systems of Linear Equations",
            "What does the solution of a system of linear equations represent?",
            "The point that satisfies all equations simultaneously.",
            "The largest coefficient in the equations.",
            "The slope of every equation.",
            "The constant term of each equation.",
            QuestionOption.A,
            "A solution must satisfy every equation in the system.",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Systems of Linear Equations",
            "Which type of graph indicates that a system has no solution?",
            "Parallel lines.",
            "Intersecting lines.",
            "Coincident lines.",
            "Perpendicular lines.",
            QuestionOption.A,
            "Parallel lines never meet, so there is no common solution.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Systems of Linear Equations",
            "What is the main purpose of studying systems of linear equations?",
            "To analyse relationships between multiple variables simultaneously.",
            "To memorise multiplication tables.",
            "To replace algebra completely.",
            "To avoid using graphs.",
            QuestionOption.A,
            "Systems of equations model relationships involving multiple unknown quantities.",
            DifficultyLevel.Begineer,
            5);

        // ==========================================================
        // Solving Systems of Linear Equations
        // ==========================================================

        AddQuestion(
            "Solving Systems of Linear Equations",
            "Which method solves a system by replacing one variable with an equivalent expression?",
            "Substitution method.",
            "Differentiation.",
            "Factorisation.",
            "Integration.",
            QuestionOption.A,
            "The substitution method replaces one variable using an expression from another equation.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Solving Systems of Linear Equations",
            "Which method eliminates a variable by adding or subtracting equations?",
            "Elimination method.",
            "Completing the square.",
            "Long division.",
            "Graph colouring.",
            QuestionOption.A,
            "The elimination method removes one variable to simplify solving the system.",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Solving Systems of Linear Equations",
            "Which matrix-based method can be used to solve systems of linear equations?",
            "Cramer's Rule.",
            "Pascal's Triangle.",
            "Binomial Expansion.",
            "Newton's Method.",
            QuestionOption.A,
            "Cramer's Rule uses determinants to solve systems with a unique solution.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Solving Systems of Linear Equations",
            "What does it mean if two equations represent the same line?",
            "The system has infinitely many solutions.",
            "The system has no solution.",
            "The system has exactly two solutions.",
            "The variables cannot be determined.",
            QuestionOption.A,
            "Coincident lines overlap completely, producing infinitely many common solutions.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Solving Systems of Linear Equations",
            "Which method is especially useful for solving large systems using matrices?",
            "Matrix methods such as row reduction.",
            "Prime factorisation.",
            "Synthetic division.",
            "Trial and error only.",
            QuestionOption.A,
            "Matrix methods efficiently solve larger systems of linear equations.",
            DifficultyLevel.Intermediate,
            5);

        // ==========================================================
        // Applications and Practice of Systems of Linear Equations
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Systems of Linear Equations",
            "Where are systems of linear equations commonly used?",
            "Economics, engineering, operations research, computer science, and data analysis.",
            "Only in geometry classes.",
            "Only in music theory.",
            "Only in language studies.",
            QuestionOption.A,
            "Systems of equations model many real-world situations across numerous disciplines.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Systems of Linear Equations",
            "Why are systems of linear equations important in engineering?",
            "They help model and solve interconnected engineering problems.",
            "They eliminate the need for measurements.",
            "They replace calculus entirely.",
            "They are only used for drawing graphs.",
            QuestionOption.A,
            "Many engineering systems involve multiple variables that must satisfy several equations.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Systems of Linear Equations",
            "How are systems of linear equations used in data analysis?",
            "To model relationships among multiple variables and datasets.",
            "To generate random colours.",
            "To compress image files only.",
            "To create web page layouts.",
            QuestionOption.A,
            "Linear systems are fundamental in statistical models and numerical computations.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Systems of Linear Equations",
            "What role do systems of linear equations play in operations research?",
            "They help optimise resource allocation and decision-making.",
            "They replace probability completely.",
            "They are used only for geometry proofs.",
            "They are limited to classroom exercises.",
            QuestionOption.A,
            "Operations research relies heavily on solving systems of equations to optimise processes.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Systems of Linear Equations",
            "Why are systems of linear equations fundamental in computer science?",
            "They are used in graphics, machine learning, optimisation, and scientific computing.",
            "They are only used to print text.",
            "They only calculate simple averages.",
            "They are useful only for calculators.",
            QuestionOption.A,
            "Many computational algorithms depend on efficiently solving systems of linear equations.",
            DifficultyLevel.Advance,
            5);// ==========================================================
               // Introduction to Eigenvalues
               // ==========================================================

        AddQuestion(
            "Introduction to Eigenvalues",
            "What is an eigenvalue of a matrix?",
            "A scalar that satisfies the equation Av = λv for a non-zero vector.",
            "A row of a matrix.",
            "The determinant of any matrix.",
            "The sum of all matrix elements.",
            QuestionOption.A,
            "An eigenvalue is a scalar that scales an eigenvector during a linear transformation.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Eigenvalues",
            "What is an eigenvector?",
            "A non-zero vector whose direction remains unchanged after a matrix transformation.",
            "Any row of a matrix.",
            "A vector with all zero entries.",
            "A determinant of a square matrix.",
            QuestionOption.B,
            "An eigenvector changes only in magnitude, not direction, when transformed by a matrix.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Eigenvalues",
            "Which type of matrices have eigenvalues?",
            "Square matrices.",
            "Only rectangular matrices.",
            "Only identity matrices.",
            "Only diagonal matrices.",
            QuestionOption.C,
            "Eigenvalues are defined only for square matrices.",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Eigenvalues",
            "Eigenvalues are mainly used to study what?",
            "Properties of matrix transformations and linear systems.",
            "Only arithmetic progressions.",
            "Prime factorisation.",
            "Circle geometry.",
            QuestionOption.D,
            "Eigenvalues reveal important characteristics of linear transformations.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Eigenvalues",
            "What does the symbol λ commonly represent?",
            "An eigenvalue.",
            "A determinant.",
            "A matrix rank.",
            "A vector dimension.",
            QuestionOption.A,
            "The Greek letter λ is the standard notation for an eigenvalue.",
            DifficultyLevel.Begineer,
            5);

        // ==========================================================
        // Finding Eigenvalues and Eigenvectors
        // ==========================================================

        AddQuestion(
            "Finding Eigenvalues and Eigenvectors",
            "Which equation is solved to find the eigenvalues of a matrix?",
            "Characteristic equation.",
            "Quadratic formula.",
            "Binomial theorem.",
            "Distance formula.",
            QuestionOption.B,
            "Eigenvalues are obtained by solving the characteristic equation det(A − λI) = 0.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Finding Eigenvalues and Eigenvectors",
            "After finding the eigenvalues, what is the next step?",
            "Find the corresponding eigenvectors.",
            "Compute the matrix rank.",
            "Find the inverse matrix only.",
            "Calculate the trace repeatedly.",
            QuestionOption.D,
            "Each eigenvalue has one or more corresponding eigenvectors.",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Finding Eigenvalues and Eigenvectors",
            "What does the characteristic equation involve?",
            "The determinant of A − λI.",
            "The inverse of every matrix.",
            "The transpose only.",
            "The matrix trace only.",
            QuestionOption.A,
            "The characteristic polynomial is obtained from det(A − λI).",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Finding Eigenvalues and Eigenvectors",
            "What equation is solved to determine an eigenvector after finding λ?",
            "(A − λI)v = 0.",
            "A + I = λ.",
            "det(A) = 1.",
            "A² = λ.",
            QuestionOption.C,
            "Substituting an eigenvalue into (A − λI)v = 0 gives the corresponding eigenvector.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Finding Eigenvalues and Eigenvectors",
            "Why are eigenvectors paired with eigenvalues?",
            "They describe the directions preserved by the transformation.",
            "They determine matrix dimensions.",
            "They replace determinants.",
            "They calculate matrix addition.",
            QuestionOption.B,
            "Eigenvectors identify invariant directions associated with each eigenvalue.",
            DifficultyLevel.Intermediate,
            5);

        // ==========================================================
        // Applications and Practice of Eigenvalues
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Eigenvalues",
            "In which field are eigenvalues commonly used for dimensionality reduction?",
            "Machine learning.",
            "Basic arithmetic.",
            "Grammar analysis.",
            "Probability tables only.",
            QuestionOption.C,
            "Techniques such as Principal Component Analysis rely on eigenvalues and eigenvectors.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Eigenvalues",
            "How are eigenvalues used in computer graphics?",
            "To analyse geometric transformations and scaling.",
            "To replace image files.",
            "To create web pages.",
            "To perform text formatting.",
            QuestionOption.A,
            "Eigenvalues help analyse transformations such as scaling and rotation.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Eigenvalues",
            "Why are eigenvalues important in vibration analysis?",
            "They help determine natural frequencies of vibrating systems.",
            "They measure electrical resistance only.",
            "They calculate prime numbers.",
            "They replace calculus.",
            QuestionOption.D,
            "Engineers use eigenvalues to study vibration modes and natural frequencies.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Eigenvalues",
            "Which branch of physics makes extensive use of eigenvalues?",
            "Quantum mechanics.",
            "Classical grammar.",
            "Number naming.",
            "Simple bookkeeping.",
            QuestionOption.B,
            "Quantum mechanics models many physical quantities using eigenvalues and eigenvectors.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Eigenvalues",
            "Why are eigenvalues valuable in data science and engineering?",
            "They help analyse transformations, optimise models, and solve complex computational problems.",
            "They are only used for matrix addition.",
            "They eliminate the need for vectors.",
            "They are useful only for theoretical proofs.",
            QuestionOption.C,
            "Eigenvalues are fundamental tools in modern scientific computing and data analysis.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Eigenvectors
        // ==========================================================

        AddQuestion(
            "Introduction to Eigenvectors",
            "What is an eigenvector?",
            "A non-zero vector whose direction remains unchanged under a matrix transformation.",
            "A row of a matrix.",
            "The determinant of a matrix.",
            "A vector containing only zeros.",
            QuestionOption.A,
            "An eigenvector changes only in magnitude, not direction, when multiplied by a matrix.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Eigenvectors",
            "What happens to an eigenvector after a matrix transformation?",
            "Its direction remains the same while its magnitude may change.",
            "Its direction always changes.",
            "It becomes a scalar.",
            "It becomes a determinant.",
            QuestionOption.B,
            "Eigenvectors retain their direction, although they may be scaled by an eigenvalue.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Eigenvectors",
            "Eigenvectors are associated with which mathematical concept?",
            "Eigenvalues.",
            "Binomial coefficients.",
            "Arithmetic progressions.",
            "Logarithms.",
            QuestionOption.C,
            "Each eigenvector corresponds to an eigenvalue of a square matrix.",
            DifficultyLevel.Begineer,
            3);

        AddQuestion(
            "Introduction to Eigenvectors",
            "For which type of matrices are eigenvectors defined?",
            "Square matrices.",
            "Only diagonal matrices.",
            "Only rectangular matrices.",
            "Only identity matrices.",
            QuestionOption.D,
            "Eigenvectors are defined only for square matrices.",
            DifficultyLevel.Begineer,
            4);

        AddQuestion(
            "Introduction to Eigenvectors",
            "Why are eigenvectors important?",
            "They describe invariant directions in linear transformations.",
            "They replace matrix multiplication.",
            "They eliminate the need for determinants.",
            "They calculate matrix dimensions.",
            QuestionOption.A,
            "Eigenvectors reveal directions that remain unchanged under matrix transformations.",
            DifficultyLevel.Begineer,
            5);

        // ==========================================================
        // Finding and Analyzing Eigenvectors
        // ==========================================================

        AddQuestion(
            "Finding and Analyzing Eigenvectors",
            "To find an eigenvector, which equation is solved after obtaining an eigenvalue?",
            "(A − λI)v = 0.",
            "det(A) = 0.",
            "A + I = λ.",
            "A² = λ.",
            QuestionOption.C,
            "Eigenvectors are found by solving the homogeneous equation (A − λI)v = 0.",
            DifficultyLevel.Intermediate,
            1);

        AddQuestion(
            "Finding and Analyzing Eigenvectors",
            "What must an eigenvector never be?",
            "The zero vector.",
            "A column vector.",
            "A real-valued vector.",
            "A unit vector.",
            QuestionOption.A,
            "The zero vector is excluded because it satisfies every homogeneous equation trivially.",
            DifficultyLevel.Intermediate,
            2);

        AddQuestion(
            "Finding and Analyzing Eigenvectors",
            "How can an eigenvector be verified?",
            "By checking whether Av = λv.",
            "By finding the determinant only.",
            "By computing the matrix trace.",
            "By adding all matrix elements.",
            QuestionOption.D,
            "A valid eigenvector satisfies the defining equation Av = λv.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Finding and Analyzing Eigenvectors",
            "What do eigenvectors represent geometrically?",
            "Directions preserved during a linear transformation.",
            "Areas enclosed by matrices.",
            "Matrix dimensions.",
            "Random vectors in space.",
            QuestionOption.B,
            "Geometrically, eigenvectors indicate invariant directions under transformation.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Finding and Analyzing Eigenvectors",
            "What is required before finding an eigenvector?",
            "The corresponding eigenvalue.",
            "The inverse matrix only.",
            "The rank of the matrix.",
            "The determinant alone.",
            QuestionOption.A,
            "Eigenvectors are determined after first calculating the corresponding eigenvalue.",
            DifficultyLevel.Intermediate,
            5);

        // ==========================================================
        // Applications and Practice of Eigenvectors
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Eigenvectors",
            "Which machine learning technique heavily relies on eigenvectors?",
            "Principal Component Analysis (PCA).",
            "Bubble Sort.",
            "Binary Search.",
            "Linear Search.",
            QuestionOption.D,
            "PCA uses eigenvectors to identify the directions of maximum variance in data.",
            DifficultyLevel.Advance,
            1);

        AddQuestion(
            "Applications and Practice of Eigenvectors",
            "How are eigenvectors used in facial recognition?",
            "They help represent important facial features using eigenfaces.",
            "They generate random passwords.",
            "They compress text files.",
            "They sort database records.",
            QuestionOption.A,
            "Eigenvectors are used to create eigenfaces for efficient facial recognition systems.",
            DifficultyLevel.Advance,
            2);

        AddQuestion(
            "Applications and Practice of Eigenvectors",
            "Why are eigenvectors important in computer graphics?",
            "They help analyse transformations such as scaling and rotation.",
            "They replace image editing software.",
            "They calculate internet speed.",
            "They only store image files.",
            QuestionOption.C,
            "Eigenvectors provide insight into the behaviour of graphical transformations.",
            DifficultyLevel.Advance,
            3);

        AddQuestion(
            "Applications and Practice of Eigenvectors",
            "In engineering, eigenvectors are commonly used to study what?",
            "Structural vibrations and dynamic systems.",
            "Alphabetical sorting.",
            "Currency conversion.",
            "Word processing.",
            QuestionOption.B,
            "Engineers use eigenvectors to analyse vibration modes and system behaviour.",
            DifficultyLevel.Advance,
            4);

        AddQuestion(
            "Applications and Practice of Eigenvectors",
            "Why are eigenvectors valuable in modern science and technology?",
            "They support data analysis, machine learning, computer graphics, engineering, and quantum physics.",
            "They are useful only in classroom exercises.",
            "They replace every numerical method.",
            "They are only used to solve determinants.",
            QuestionOption.A,
            "Eigenvectors have broad applications across mathematics, science, and engineering.",
            DifficultyLevel.Advance,
            5);
        // ------------------------------------------------------------
        // Introduction to Vector Basics
        // ------------------------------------------------------------

        AddQuestion(
            "Introduction to Vector Basics",
            "Which of the following quantities has both magnitude and direction?",
            "Mass",
            "Temperature",
            "Velocity",
            "Time",
            QuestionOption.C,
            "Velocity is a vector because it has both magnitude (speed) and direction.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Vector Basics",
            "Which of the following is a scalar quantity?",
            "Force",
            "Displacement",
            "Acceleration",
            "Distance",
            QuestionOption.D,
            "Distance has only magnitude and no direction, making it a scalar quantity.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Vector Basics",
            "A vector is completely described by:",
            "Magnitude only",
            "Direction only",
            "Magnitude and direction",
            "Size and colour",
            QuestionOption.C,
            "A vector always contains both magnitude and direction.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Vector Basics",
            "Which of the following is NOT a vector?",
            "Momentum",
            "Force",
            "Speed",
            "Weight",
            QuestionOption.C,
            "Speed tells only how fast something moves. It does not include direction.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Vector Basics",
            "Why are vectors important in navigation?",
            "They measure colour.",
            "They show both distance and direction.",
            "They measure temperature.",
            "They calculate time only.",
            QuestionOption.B,
            "Navigation requires knowing both how far and in which direction to travel.",
            DifficultyLevel.Advance,
            5);


        // ------------------------------------------------------------
        // Representation and Components of Vectors
        // ------------------------------------------------------------

        AddQuestion(
            "Representation and Components of Vectors",
            "Vectors are commonly represented by:",
            "A square",
            "An arrow",
            "A circle",
            "A rectangle",
            QuestionOption.B,
            "The arrow length represents magnitude while the arrow head represents direction.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Representation and Components of Vectors",
            "Resolving a vector means:",
            "Increasing its magnitude",
            "Breaking it into components",
            "Changing its direction",
            "Removing its magnitude",
            QuestionOption.B,
            "Vector resolution breaks a vector into horizontal and vertical components.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Representation and Components of Vectors",
            "Which axis usually represents the horizontal component?",
            "Y-axis",
            "Z-axis",
            "X-axis",
            "Origin",
            QuestionOption.C,
            "The X-axis is generally used for horizontal movement.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Representation and Components of Vectors",
            "Why do we use vector components?",
            "To make calculations easier",
            "To increase vector size",
            "To remove direction",
            "To convert vectors into scalars",
            QuestionOption.A,
            "Breaking vectors into components simplifies mathematical calculations.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Representation and Components of Vectors",
            "Game developers use vector components mainly to:",
            "Store images",
            "Calculate movement in different directions",
            "Increase screen brightness",
            "Compress files",
            QuestionOption.B,
            "Game engines calculate character movement using vector components.",
            DifficultyLevel.Advance,
            5);


        // ------------------------------------------------------------
        // Applications and Practice of Vector Basics
        // ------------------------------------------------------------

        AddQuestion(
            "Applications and Practice of Vector Basics",
            "Which profession frequently uses vectors to calculate forces?",
            "Chef",
            "Engineer",
            "Singer",
            "Photographer",
            QuestionOption.B,
            "Engineers use vectors to analyse forces, structures, and motion.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Vector Basics",
            "Robots use vectors to:",
            "Cook food",
            "Move accurately in different directions",
            "Store electricity",
            "Generate sound",
            QuestionOption.B,
            "Robotic systems calculate movement using vectors.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Vector Basics",
            "Aircraft navigation depends on vectors because they describe:",
            "Colour",
            "Temperature",
            "Direction and speed",
            "Fuel consumption",
            QuestionOption.C,
            "Pilots use vectors to determine flight paths and wind direction.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Vector Basics",
            "Which technology uses vectors extensively?",
            "Artificial Intelligence",
            "Computer Graphics",
            "GPS Navigation",
            "All of the above",
            QuestionOption.D,
            "Vectors are fundamental in AI, graphics, robotics, simulations, and navigation.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Vector Basics",
            "Learning vectors is valuable because they are used in:",
            "Only mathematics",
            "Only physics",
            "Only engineering",
            "Science, engineering, AI, games, and navigation",
            QuestionOption.D,
            "Vectors are one of the most important mathematical tools across many modern technologies.",
            DifficultyLevel.Advance,
            5);

        // ==========================================================
        // Introduction to Vector Operations
        // ==========================================================

        AddQuestion(
            "Introduction to Vector Operations",
            "Which operation combines two vectors into a single vector?",
            "Vector Addition",
            "Scalar Multiplication",
            "Vector Division",
            "Vector Rotation",
            QuestionOption.A,
            "Vector addition combines two vectors into one resulting vector.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Vector Operations",
            "Subtracting one vector from another helps determine:",
            "The average vector",
            "The difference in magnitude and direction",
            "The colour of the vector",
            "The speed only",
            QuestionOption.B,
            "Vector subtraction finds the difference between two vectors.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Vector Operations",
            "What happens when a vector is multiplied by a scalar greater than 1?",
            "Its direction changes",
            "Its magnitude increases",
            "It becomes a scalar",
            "It disappears",
            QuestionOption.B,
            "Scalar multiplication changes the magnitude while keeping the direction the same (if the scalar is positive).",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Vector Operations",
            "A negative scalar multiplication will:",
            "Keep the same direction",
            "Reverse the vector's direction",
            "Remove the vector",
            "Double its magnitude only",
            QuestionOption.B,
            "A negative scalar reverses the vector's direction.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Vector Operations",
            "Vector operations are widely used in:",
            "Physics and Engineering",
            "Computer Graphics",
            "Robotics and Artificial Intelligence",
            "All of the above",
            QuestionOption.D,
            "Vector operations are fundamental in science, engineering, AI, games, and robotics.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Performing Vector Operations
        // ==========================================================

        AddQuestion(
            "Performing Vector Operations",
            "Which graphical method is commonly used for vector addition?",
            "Pie Chart Method",
            "Head-to-Tail Method",
            "Bar Graph Method",
            "Circle Method",
            QuestionOption.B,
            "The Head-to-Tail method places one vector after another to find the resultant.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Performing Vector Operations",
            "When adding vectors using components, which components are added together?",
            "Only magnitudes",
            "Horizontal with horizontal and vertical with vertical",
            "Horizontal with vertical",
            "Directions only",
            QuestionOption.B,
            "Each corresponding component is added independently.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Performing Vector Operations",
            "Scalar multiplication affects which property of a vector?",
            "Magnitude",
            "Colour",
            "Position",
            "Shape",
            QuestionOption.A,
            "Scalar multiplication changes the vector's magnitude while preserving direction if the scalar is positive.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Performing Vector Operations",
            "The resultant vector represents:",
            "The final vector after performing operations",
            "The largest vector",
            "The shortest vector",
            "The average vector",
            QuestionOption.A,
            "The resultant is the single vector equivalent to multiple vector operations.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Performing Vector Operations",
            "Why do engineers often perform vector operations using components?",
            "It makes calculations more accurate and simpler",
            "It removes direction",
            "It converts vectors into scalars",
            "It increases vector size",
            QuestionOption.A,
            "Resolving vectors into components simplifies complex engineering calculations.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Applications and Practice of Vector Operations
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Vector Operations",
            "Which field frequently uses vector addition to calculate forces?",
            "Physics",
            "Cooking",
            "History",
            "Music",
            QuestionOption.A,
            "Physics combines multiple forces using vector addition.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Vector Operations",
            "In robotics, vector operations help robots:",
            "Play music",
            "Move accurately and calculate paths",
            "Store files",
            "Print documents",
            QuestionOption.B,
            "Robots rely on vector calculations for movement and navigation.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Vector Operations",
            "Computer graphics uses vector operations mainly to:",
            "Move and rotate objects",
            "Store passwords",
            "Compress videos",
            "Generate internet signals",
            QuestionOption.A,
            "Vectors control object movement, transformations, and animation.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Vector Operations",
            "GPS navigation uses vector operations to:",
            "Calculate routes and directions",
            "Measure humidity",
            "Record sound",
            "Display advertisements",
            QuestionOption.A,
            "GPS systems calculate routes using vector mathematics.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Vector Operations",
            "Artificial Intelligence uses vector operations for:",
            "Representing and comparing data mathematically",
            "Cooking recipes",
            "Charging batteries",
            "Printing books",
            QuestionOption.A,
            "Modern AI represents text, images, and knowledge as vectors to perform similarity search and machine learning.",
            DifficultyLevel.Advance,
            5);// ==========================================================
               // Introduction to Dot Product
               // ==========================================================

        AddQuestion(
            "Introduction to Dot Product",
            "The dot product of two vectors always produces:",
            "Another vector",
            "A scalar",
            "A matrix",
            "A graph",
            QuestionOption.B,
            "Unlike vector addition, the dot product always results in a scalar value.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Dot Product",
            "The dot product helps measure the:",
            "Similarity of two vectors",
            "Colour of a vector",
            "Speed of a vector",
            "Shape of a vector",
            QuestionOption.A,
            "The dot product tells how closely two vectors point in the same direction.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Dot Product",
            "If two vectors point in the same direction, their dot product is generally:",
            "Positive",
            "Negative",
            "Always zero",
            "Undefined",
            QuestionOption.A,
            "Vectors pointing in similar directions produce a positive dot product.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Dot Product",
            "If two vectors are perpendicular, their dot product is:",
            "1",
            "-1",
            "0",
            "Infinity",
            QuestionOption.C,
            "Perpendicular vectors have a dot product of zero.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Dot Product",
            "Which field commonly uses the dot product?",
            "Computer Graphics",
            "Machine Learning",
            "Physics",
            "All of the above",
            QuestionOption.D,
            "The dot product is widely used across science, graphics, robotics, AI, and engineering.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Calculating and Interpreting Dot Product
        // ==========================================================

        AddQuestion(
            "Calculating and Interpreting Dot Product",
            "The dot product can be calculated using:",
            "Vector components",
            "Angles between vectors",
            "Both vector components and angles",
            "Neither",
            QuestionOption.C,
            "Both the component formula and angle formula can be used to calculate the dot product.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Calculating and Interpreting Dot Product",
            "The angle between perpendicular vectors is:",
            "45°",
            "60°",
            "90°",
            "180°",
            QuestionOption.C,
            "Perpendicular vectors always meet at 90 degrees.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Calculating and Interpreting Dot Product",
            "A positive dot product indicates:",
            "Vectors point in roughly the same direction",
            "Vectors are perpendicular",
            "Vectors point in opposite directions",
            "The vectors are equal",
            QuestionOption.A,
            "Positive values mean the vectors have a similar direction.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Calculating and Interpreting Dot Product",
            "A negative dot product usually means:",
            "Vectors point in opposite directions",
            "Vectors are equal",
            "Vectors are perpendicular",
            "The vectors disappear",
            QuestionOption.A,
            "Opposite directions produce a negative dot product.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Calculating and Interpreting Dot Product",
            "The dot product is useful for checking whether vectors are:",
            "Parallel or perpendicular",
            "Circular",
            "Random",
            "Curved",
            QuestionOption.A,
            "The dot product helps determine angular relationships between vectors.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Applications and Practice of Dot Product
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Dot Product",
            "In physics, the dot product is commonly used to calculate:",
            "Work Done",
            "Temperature",
            "Mass",
            "Pressure",
            QuestionOption.A,
            "Work is calculated using the dot product of force and displacement.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Dot Product",
            "Computer graphics uses the dot product mainly for:",
            "Lighting calculations",
            "Playing sound",
            "Saving files",
            "Compressing images",
            QuestionOption.A,
            "Lighting and shading depend heavily on the dot product.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Dot Product",
            "Machine Learning uses the dot product to:",
            "Measure similarity between vectors",
            "Draw circles",
            "Create databases",
            "Print documents",
            QuestionOption.A,
            "Embeddings and similarity search rely heavily on the dot product.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Dot Product",
            "Robotics uses the dot product to:",
            "Analyse movement and orientation",
            "Store electricity",
            "Generate heat",
            "Measure rainfall",
            QuestionOption.A,
            "Robotic systems use vector mathematics to understand movement and positioning.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Dot Product",
            "Why is the dot product important in modern AI systems?",
            "It compares embedding vectors efficiently",
            "It increases processor speed",
            "It compresses videos",
            "It stores passwords",
            QuestionOption.A,
            "Modern AI models compare text and image embeddings using the dot product or cosine similarity.",
            DifficultyLevel.Advance,
            5);// ==========================================================
               // Calculating and Interpreting Cross Product
               // ==========================================================

        AddQuestion(
            "Calculating and Interpreting Cross Product",
            "The cross product of two vectors always results in:",
            "A scalar",
            "Another vector",
            "A matrix",
            "A number line",
            QuestionOption.B,
            "Unlike the dot product, the cross product always produces another vector.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Calculating and Interpreting Cross Product",
            "Which rule is commonly used to determine the direction of the cross product?",
            "Left-Hand Rule",
            "Clock Rule",
            "Right-Hand Rule",
            "Compass Rule",
            QuestionOption.C,
            "The Right-Hand Rule determines the direction of the resulting vector.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Calculating and Interpreting Cross Product",
            "If two vectors are parallel, their cross product is:",
            "Positive",
            "Negative",
            "Zero",
            "Undefined",
            QuestionOption.C,
            "Parallel vectors produce a cross product of zero because the angle between them is 0° or 180°.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Calculating and Interpreting Cross Product",
            "The magnitude of the cross product depends on:",
            "Only the magnitudes of the vectors",
            "Only the angle between vectors",
            "Both the magnitudes and the angle",
            "Neither",
            QuestionOption.C,
            "The magnitude depends on both vector lengths and the sine of the angle between them.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Calculating and Interpreting Cross Product",
            "The cross product is mainly useful because it finds:",
            "A vector perpendicular to both vectors",
            "The average vector",
            "The smallest vector",
            "The scalar projection",
            QuestionOption.A,
            "The resulting vector is always perpendicular to the two original vectors.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Applications and Practice of Cross Product
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Cross Product",
            "The cross product is commonly used to calculate:",
            "Area of a parallelogram",
            "Temperature",
            "Mass",
            "Density",
            QuestionOption.A,
            "The magnitude of the cross product gives the area of the parallelogram formed by two vectors.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Cross Product",
            "In physics, the cross product is used to calculate:",
            "Torque",
            "Distance",
            "Pressure",
            "Volume",
            QuestionOption.A,
            "Torque is calculated using the cross product of position and force vectors.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Cross Product",
            "Computer graphics uses the cross product to:",
            "Find surface normals",
            "Store files",
            "Compress images",
            "Increase brightness",
            QuestionOption.A,
            "Surface normals are calculated using the cross product for lighting and rendering.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Cross Product",
            "Robotics uses the cross product mainly for:",
            "Motion and rotational calculations",
            "Saving data",
            "Measuring humidity",
            "Generating sound",
            QuestionOption.A,
            "Robotic systems use the cross product when calculating rotations and orientations.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Cross Product",
            "Which modern field relies heavily on the cross product for 3D calculations?",
            "3D Game Development and Engineering",
            "Accounting",
            "Cooking",
            "Writing",
            QuestionOption.A,
            "3D graphics, game engines, CAD software, robotics, and engineering all depend on cross product calculations.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Vector Projection
        // ==========================================================

        AddQuestion(
            "Introduction to Vector Projection",
            "Vector projection is used to:",
            "Find how much one vector lies in the direction of another",
            "Multiply two vectors",
            "Rotate a vector",
            "Reverse a vector",
            QuestionOption.A,
            "Projection measures the part of one vector that acts in the direction of another vector.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Vector Projection",
            "Vector projection is based primarily on which vector operation?",
            "Cross Product",
            "Dot Product",
            "Vector Addition",
            "Vector Subtraction",
            QuestionOption.B,
            "The dot product is used to calculate both scalar and vector projections.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Vector Projection",
            "The projection of one vector onto another represents:",
            "The perpendicular distance",
            "The component along the second vector",
            "The average of two vectors",
            "The angle only",
            QuestionOption.B,
            "Projection gives the component of one vector in the direction of another.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Vector Projection",
            "If two vectors are perpendicular, their projection is:",
            "Maximum",
            "Minimum",
            "Zero",
            "Infinite",
            QuestionOption.C,
            "Perpendicular vectors have a dot product of zero, so the projection is also zero.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Vector Projection",
            "Vector projection is useful because it tells us:",
            "How much one vector contributes in another's direction",
            "How to rotate vectors",
            "How to change vector colours",
            "How to find vector volume",
            QuestionOption.A,
            "Projection isolates the useful component of a vector along a chosen direction.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Calculating Vector Projection
        // ==========================================================

        AddQuestion(
            "Calculating Vector Projection",
            "Scalar projection gives:",
            "A vector",
            "A scalar value",
            "A matrix",
            "An angle",
            QuestionOption.B,
            "Scalar projection measures the length of the projected component.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Calculating Vector Projection",
            "Vector projection gives:",
            "Only a number",
            "A vector in the direction of another vector",
            "A matrix",
            "A graph",
            QuestionOption.B,
            "Vector projection returns the projected vector itself.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Calculating Vector Projection",
            "Which operation is required when calculating vector projection?",
            "Dot Product",
            "Cross Product",
            "Division",
            "Matrix Multiplication",
            QuestionOption.A,
            "Vector projection is calculated using the dot product formula.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Calculating Vector Projection",
            "The projected vector always points:",
            "Perpendicular to the reference vector",
            "In the same or opposite direction as the reference vector",
            "Randomly",
            "At 45 degrees",
            QuestionOption.B,
            "The projected vector lies along the reference vector's line.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Calculating Vector Projection",
            "Why do engineers calculate vector projections?",
            "To simplify force and motion calculations",
            "To change vector colours",
            "To create animations only",
            "To measure temperature",
            QuestionOption.A,
            "Projection allows engineers to isolate forces and motion along specific directions.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Applications and Practice of Vector Projection
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Vector Projection",
            "In physics, vector projection is commonly used to:",
            "Resolve forces into components",
            "Calculate temperature",
            "Measure density",
            "Find pressure only",
            QuestionOption.A,
            "Projection helps separate forces acting in different directions.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Vector Projection",
            "Navigation systems use vector projection to:",
            "Determine movement along a chosen path",
            "Increase internet speed",
            "Compress maps",
            "Store coordinates",
            QuestionOption.A,
            "Projection determines how much movement occurs toward the destination.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Vector Projection",
            "Computer graphics uses vector projection mainly for:",
            "Lighting and shadow calculations",
            "Playing music",
            "Saving files",
            "Printing images",
            QuestionOption.A,
            "Projection is used in lighting models to calculate how light falls on surfaces.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Vector Projection",
            "Robotics uses vector projection to:",
            "Calculate motion along specific directions",
            "Increase battery life",
            "Store programs",
            "Generate sound",
            QuestionOption.A,
            "Robots project movement and forces along desired directions for precise control.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Vector Projection",
            "Machine Learning uses vector projection to:",
            "Compare high-dimensional embeddings and extract useful information",
            "Print documents",
            "Charge processors",
            "Store passwords",
            QuestionOption.A,
            "Projection is widely used in embeddings, dimensionality reduction, similarity search, and recommendation systems.",
            DifficultyLevel.Advance,
            5);// ==========================================================
               // Introduction to Direction Cosines
               // ==========================================================

        AddQuestion(
            "Introduction to Direction Cosines",
            "Direction cosines describe the:",
            "Magnitude of a vector",
            "Orientation of a vector in 3D space",
            "Length of a line",
            "Area of a surface",
            QuestionOption.B,
            "Direction cosines describe how a vector is oriented with respect to the x, y, and z axes.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Direction Cosines",
            "Direction cosines are the cosines of the angles a vector makes with the:",
            "Coordinate axes",
            "Coordinate planes",
            "Origin only",
            "Diagonal line",
            QuestionOption.A,
            "They are the cosines of the angles formed with the x-, y-, and z-axes.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Direction Cosines",
            "How many direction cosines does a vector in 3D space have?",
            "One",
            "Two",
            "Three",
            "Four",
            QuestionOption.C,
            "A three-dimensional vector has one direction cosine for each coordinate axis.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Direction Cosines",
            "Direction cosines mainly help us understand a vector's:",
            "Weight",
            "Direction",
            "Temperature",
            "Colour",
            QuestionOption.B,
            "They describe the orientation of the vector rather than its magnitude.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Direction Cosines",
            "Direction cosines are especially useful when working in:",
            "One-dimensional geometry",
            "Two-dimensional geometry",
            "Three-dimensional geometry",
            "Circular geometry",
            QuestionOption.C,
            "They are fundamental for describing vectors in three-dimensional space.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Calculating Direction Cosines and Ratios
        // ==========================================================

        AddQuestion(
            "Calculating Direction Cosines and Ratios",
            "Direction ratios represent:",
            "Numbers proportional to the components of a vector",
            "Only the magnitude of a vector",
            "The area of a vector",
            "The angle between vectors",
            QuestionOption.A,
            "Direction ratios are values proportional to the vector's x, y, and z components.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Calculating Direction Cosines and Ratios",
            "Direction cosines are obtained by dividing each vector component by its:",
            "Area",
            "Magnitude",
            "Angle",
            "Length of the x-axis",
            QuestionOption.B,
            "Each component is divided by the vector's magnitude to obtain its direction cosine.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Calculating Direction Cosines and Ratios",
            "The sum of the squares of the direction cosines is always:",
            "0",
            "1",
            "2",
            "3",
            QuestionOption.B,
            "Direction cosines satisfy the identity l² + m² + n² = 1.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Calculating Direction Cosines and Ratios",
            "Direction ratios can be converted into direction cosines by:",
            "Multiplying by the magnitude",
            "Dividing by the vector's magnitude",
            "Adding all components",
            "Subtracting the largest component",
            QuestionOption.B,
            "Normalising the direction ratios gives the direction cosines.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Calculating Direction Cosines and Ratios",
            "Why are direction ratios useful?",
            "They simplify describing vector directions before normalization",
            "They calculate vector area",
            "They measure temperature",
            "They determine speed",
            QuestionOption.A,
            "Direction ratios provide a convenient way to represent vector directions before converting them into unit values.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Applications and Practice of Direction Cosines
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Direction Cosines",
            "Direction cosines are widely used in:",
            "Three-dimensional geometry",
            "Cooking",
            "Painting",
            "Music",
            QuestionOption.A,
            "They are essential for solving problems involving vectors in 3D space.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Direction Cosines",
            "Engineers use direction cosines mainly to:",
            "Describe the orientation of forces and structures",
            "Calculate food recipes",
            "Store electrical energy",
            "Measure rainfall",
            QuestionOption.A,
            "Direction cosines help engineers describe directions accurately in three dimensions.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Direction Cosines",
            "Robotics uses direction cosines to:",
            "Determine the orientation of robotic arms",
            "Print documents",
            "Compress images",
            "Store files",
            QuestionOption.A,
            "Robotic systems rely on orientation calculations for accurate movement.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Direction Cosines",
            "Aircraft and spacecraft navigation use direction cosines to:",
            "Track orientation in 3D space",
            "Increase fuel capacity",
            "Generate electricity",
            "Reduce gravity",
            QuestionOption.A,
            "Navigation systems constantly calculate orientation using direction information.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Direction Cosines",
            "Modern computer graphics uses direction cosines to:",
            "Represent object orientation, camera movement, and lighting calculations",
            "Store databases",
            "Compress videos",
            "Generate passwords",
            QuestionOption.A,
            "3D graphics engines use direction information for rendering, animation, lighting, and camera control.",
            DifficultyLevel.Advance,
            5);
        // ==========================================================
        // Introduction to Lines in Space
        // ==========================================================

        AddQuestion(
            "Introduction to Lines in Space",
            "A line in three-dimensional space extends:",
            "In one direction only",
            "Infinitely in both directions",
            "Only between two points",
            "Around a circle",
            QuestionOption.B,
            "Like a line in 2D, a line in 3D extends infinitely in both directions.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Lines in Space",
            "Which equation is commonly used to represent a line in 3D space?",
            "Vector equation",
            "Quadratic equation",
            "Circle equation",
            "Linear inequality",
            QuestionOption.A,
            "The vector equation is one of the standard ways to represent a line in three-dimensional space.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Lines in Space",
            "A line in space requires a point and a:",
            "Radius",
            "Direction vector",
            "Plane",
            "Matrix",
            QuestionOption.B,
            "A point and a direction vector uniquely determine a line in space.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Lines in Space",
            "A direction vector determines the line's:",
            "Length",
            "Orientation",
            "Area",
            "Volume",
            QuestionOption.B,
            "The direction vector tells us the direction in which the line extends.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Lines in Space",
            "Studying lines in space is important for:",
            "Understanding three-dimensional geometry",
            "Learning fractions",
            "Drawing circles only",
            "Measuring temperature",
            QuestionOption.A,
            "Lines in space form the foundation of 3D geometry and engineering applications.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Equations and Relationships of Lines in Space
        // ==========================================================

        AddQuestion(
            "Equations and Relationships of Lines in Space",
            "Which form expresses a line using a point and a direction vector?",
            "Vector equation",
            "Quadratic equation",
            "Exponential equation",
            "Logarithmic equation",
            QuestionOption.A,
            "The vector equation represents a line using a position vector and a direction vector.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Equations and Relationships of Lines in Space",
            "Parallel lines have:",
            "The same direction",
            "The same starting point only",
            "The same length",
            "The same magnitude",
            QuestionOption.A,
            "Parallel lines have proportional direction vectors.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Equations and Relationships of Lines in Space",
            "Skew lines are lines that:",
            "Intersect each other",
            "Are parallel",
            "Neither intersect nor are parallel",
            "Always lie in the same plane",
            QuestionOption.C,
            "Skew lines exist only in three dimensions and never meet.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Relationships of Lines in Space",
            "The angle between two lines is determined using their:",
            "Direction vectors",
            "Lengths",
            "Areas",
            "Starting points",
            QuestionOption.A,
            "The angle between lines is calculated from the angle between their direction vectors.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Relationships of Lines in Space",
            "Parametric equations are useful because they:",
            "Represent every point on a line using a parameter",
            "Calculate only line length",
            "Find circle areas",
            "Measure speed",
            QuestionOption.A,
            "Changing the parameter generates every point lying on the line.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Applications and Practice of Lines in Space
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Lines in Space",
            "Architects use lines in space mainly to:",
            "Design buildings and structures",
            "Cook food",
            "Edit videos",
            "Write books",
            QuestionOption.A,
            "Three-dimensional lines help architects accurately model buildings.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Lines in Space",
            "Navigation systems use lines in space to:",
            "Calculate movement paths",
            "Increase internet speed",
            "Generate electricity",
            "Compress files",
            QuestionOption.A,
            "Navigation software models routes and movement using spatial geometry.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Lines in Space",
            "Robotics uses lines in space to:",
            "Plan robotic arm movement",
            "Store batteries",
            "Generate music",
            "Measure rainfall",
            QuestionOption.A,
            "Robotic motion planning relies on three-dimensional line geometry.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Lines in Space",
            "Computer graphics uses lines in space for:",
            "3D modelling and rendering",
            "Cooking recipes",
            "Printing documents",
            "Weather forecasting",
            QuestionOption.A,
            "Every 3D object is built using points, lines, and surfaces.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Lines in Space",
            "Engineers and physicists study lines in space because they help model:",
            "Motion, structures, trajectories, and three-dimensional systems",
            "Food nutrition",
            "Music composition",
            "Plant growth",
            QuestionOption.A,
            "Modern engineering, aerospace, robotics, CAD software, and physics all rely heavily on three-dimensional line geometry.",
            DifficultyLevel.Advance,
            5);// ==========================================================
               // Introduction to Planes
               // ==========================================================

        AddQuestion(
            "Introduction to Planes",
            "A plane is a:",
            "One-dimensional figure",
            "Two-dimensional flat surface",
            "Three-dimensional solid",
            "Curved surface",
            QuestionOption.B,
            "A plane is a flat surface that extends infinitely in all directions within two dimensions.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Introduction to Planes",
            "A plane extends infinitely in:",
            "One direction",
            "Two dimensions",
            "Three dimensions",
            "Four dimensions",
            QuestionOption.B,
            "A plane has length and width, but no thickness.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Introduction to Planes",
            "A plane can be uniquely determined by:",
            "Three non-collinear points",
            "One point",
            "Two parallel lines only",
            "A single vector",
            QuestionOption.A,
            "Three points that do not lie on the same line uniquely define a plane.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Introduction to Planes",
            "Which vector is perpendicular to a plane?",
            "Direction vector",
            "Unit vector",
            "Normal vector",
            "Position vector",
            QuestionOption.C,
            "The normal vector is always perpendicular to the plane.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Introduction to Planes",
            "Studying planes helps us understand:",
            "Three-dimensional geometry",
            "Only arithmetic",
            "Only circles",
            "Only graphs",
            QuestionOption.A,
            "Planes form the basis of many concepts in 3D geometry, engineering, and graphics.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Equations and Properties of Planes
        // ==========================================================

        AddQuestion(
            "Equations and Properties of Planes",
            "Which vector is essential when writing the equation of a plane?",
            "Normal vector",
            "Velocity vector",
            "Force vector",
            "Position vector only",
            QuestionOption.A,
            "A normal vector determines the orientation of the plane.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Equations and Properties of Planes",
            "Two planes are parallel if their:",
            "Normal vectors are parallel",
            "Areas are equal",
            "Points are identical",
            "Distances are zero",
            QuestionOption.A,
            "Parallel planes have proportional normal vectors.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Equations and Properties of Planes",
            "The angle between two planes is determined by the angle between their:",
            "Edges",
            "Normal vectors",
            "Areas",
            "Lengths",
            QuestionOption.B,
            "The angle between planes equals the angle between their normal vectors.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Equations and Properties of Planes",
            "A line is perpendicular to a plane if it is parallel to the plane's:",
            "Direction vector",
            "Normal vector",
            "Position vector",
            "Unit vector",
            QuestionOption.B,
            "The line follows the same direction as the plane's normal vector.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Equations and Properties of Planes",
            "Cartesian equations of planes are mainly used to:",
            "Represent planes algebraically",
            "Calculate circle areas",
            "Measure temperature",
            "Draw graphs only",
            QuestionOption.A,
            "Cartesian equations allow planes to be represented and solved mathematically.",
            DifficultyLevel.Advance,
            5);


        // ==========================================================
        // Applications and Practice of Planes
        // ==========================================================

        AddQuestion(
            "Applications and Practice of Planes",
            "Architects use planes to:",
            "Design walls, floors, and roofs",
            "Measure rainfall",
            "Write software",
            "Generate music",
            QuestionOption.A,
            "Buildings are designed using planes to represent flat surfaces.",
            DifficultyLevel.Begineer,
            1);

        AddQuestion(
            "Applications and Practice of Planes",
            "Computer graphics uses planes for:",
            "Representing surfaces of 3D objects",
            "Compressing files",
            "Sending emails",
            "Printing books",
            QuestionOption.A,
            "3D models are built from many flat surfaces called planes.",
            DifficultyLevel.Begineer,
            2);

        AddQuestion(
            "Applications and Practice of Planes",
            "Engineers use planes when designing:",
            "Machines and structures",
            "Recipes",
            "Music players",
            "Paintings",
            QuestionOption.A,
            "Engineering drawings rely heavily on plane geometry.",
            DifficultyLevel.Intermediate,
            3);

        AddQuestion(
            "Applications and Practice of Planes",
            "Robotics uses planes to:",
            "Understand object orientation and movement",
            "Store batteries",
            "Generate electricity",
            "Measure rainfall",
            QuestionOption.A,
            "Robots use plane geometry for navigation, vision, and object manipulation.",
            DifficultyLevel.Intermediate,
            4);

        AddQuestion(
            "Applications and Practice of Planes",
            "Modern aerospace, CAD software, computer graphics, and physics all rely on planes because they help model:",
            "Real-world three-dimensional surfaces and environments",
            "Only two-dimensional drawings",
            "Food recipes",
            "Internet connections",
            QuestionOption.A,
            "Plane geometry is fundamental for modelling aircraft, buildings, robots, simulations, games, and scientific systems.",
            DifficultyLevel.Advance,
            5);





















        context.PracticeQuestions.AddRange(questions);
        await context.SaveChangesAsync();
    }
}