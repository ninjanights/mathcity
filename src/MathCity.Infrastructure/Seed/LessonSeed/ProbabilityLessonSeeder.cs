using MathCity.Domain.Entities;
using MathCity.Domain.Enums;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MathCity.Infrastructure.Seed.Lessons;

public static class ProbabilityLessonSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        var topics = await context.Topics
            .ToDictionaryAsync(t => t.Title);

        var lessons = new List<Lesson>
        {
            // ==========================================================
// Basic Probability
// ==========================================================

new Lesson
{
    TopicId = topics["Basic Probability"].Id,
    Title = "Introduction to Basic Probability",
    Slug = "introduction-to-basic-probability",
    Summary = "Learn the fundamentals of probability, understand events, outcomes, sample spaces, and how probability measures the likelihood of an event occurring.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Basic Probability"].Id,
    Title = "Calculating Basic Probability",
    Slug = "calculating-basic-probability",
    Summary = "Explore probability formulas, solve problems involving simple events, sample spaces, and equally likely outcomes through step-by-step examples.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Basic Probability"].Id,
    Title = "Applications and Practice of Basic Probability",
    Slug = "applications-and-practice-of-basic-probability",
    Summary = "Apply probability concepts to solve real-world problems involving games, weather prediction, finance, medicine, artificial intelligence, and decision-making.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Conditional Probability
// ==========================================================

new Lesson
{
    TopicId = topics["Conditional Probability"].Id,
    Title = "Introduction to Conditional Probability",
    Slug = "introduction-to-conditional-probability",
    Summary = "Learn the fundamentals of conditional probability and understand how the probability of an event changes when another event is already known to have occurred.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Conditional Probability"].Id,
    Title = "Calculating Conditional Probability",
    Slug = "calculating-conditional-probability",
    Summary = "Explore the conditional probability formula, solve problems involving dependent events, and interpret probability using Venn diagrams and sample spaces.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Conditional Probability"].Id,
    Title = "Applications and Practice of Conditional Probability",
    Slug = "applications-and-practice-of-conditional-probability",
    Summary = "Apply conditional probability concepts to solve advanced problems and explore applications in medicine, artificial intelligence, data science, finance, risk analysis, and decision-making.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},
// ==========================================================
// Bayes' Theorem
// ==========================================================

new Lesson
{
    TopicId = topics["Bayes' Theorem"].Id,
    Title = "Introduction to Bayes' Theorem",
    Slug = "introduction-to-bayes-theorem",
    Summary = "Learn the fundamentals of Bayes' Theorem and understand how probabilities are updated when new evidence becomes available.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Bayes' Theorem"].Id,
    Title = "Applying Bayes' Theorem",
    Slug = "applying-bayes-theorem",
    Summary = "Explore the Bayes' Theorem formula, solve conditional probability problems, and interpret posterior, prior, and likelihood probabilities through worked examples.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Bayes' Theorem"].Id,
    Title = "Applications and Practice of Bayes' Theorem",
    Slug = "applications-and-practice-of-bayes-theorem",
    Summary = "Apply Bayes' Theorem to solve advanced probability problems and explore applications in artificial intelligence, medical diagnosis, spam filtering, finance, machine learning, and decision-making.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},
// ==========================================================
// Random Variables
// ==========================================================

new Lesson
{
    TopicId = topics["Random Variables"].Id,
    Title = "Introduction to Random Variables",
    Slug = "introduction-to-random-variables",
    Summary = "Learn the fundamentals of random variables, understand the difference between discrete and continuous random variables, and explore how they model uncertain outcomes.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Random Variables"].Id,
    Title = "Types and Probability Distributions of Random Variables",
    Slug = "types-and-probability-distributions-of-random-variables",
    Summary = "Explore discrete and continuous random variables, probability mass functions, probability density functions, and solve problems involving probability distributions.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Random Variables"].Id,
    Title = "Applications and Practice of Random Variables",
    Slug = "applications-and-practice-of-random-variables",
    Summary = "Apply random variable concepts to solve advanced probability problems and explore applications in statistics, machine learning, finance, artificial intelligence, engineering, and scientific research.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},
// ==========================================================
// Probability Distributions
// ==========================================================

new Lesson
{
    TopicId = topics["Probability Distributions"].Id,
    Title = "Introduction to Probability Distributions",
    Slug = "introduction-to-probability-distributions",
    Summary = "Learn the fundamentals of probability distributions, understand how probabilities are assigned to random variables, and explore discrete and continuous distributions.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Probability Distributions"].Id,
    Title = "Types and Properties of Probability Distributions",
    Slug = "types-and-properties-of-probability-distributions",
    Summary = "Explore probability mass functions, probability density functions, cumulative distribution functions, and analyze the characteristics of common probability distributions.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Probability Distributions"].Id,
    Title = "Applications and Practice of Probability Distributions",
    Slug = "applications-and-practice-of-probability-distributions",
    Summary = "Apply probability distribution concepts to solve advanced statistical problems and explore applications in finance, artificial intelligence, machine learning, quality control, engineering, and scientific research.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Expected Value
// ==========================================================

new Lesson
{
    TopicId = topics["Expected Value"].Id,
    Title = "Introduction to Expected Value",
    Slug = "introduction-to-expected-value",
    Summary = "Learn the fundamentals of expected value, understand how it represents the average outcome of a random process, and explore its significance in probability.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Expected Value"].Id,
    Title = "Calculating Expected Value",
    Slug = "calculating-expected-value",
    Summary = "Explore formulas for calculating expected value from probability distributions, solve numerical problems, and understand its relationship with random variables.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Expected Value"].Id,
    Title = "Applications and Practice of Expected Value",
    Slug = "applications-and-practice-of-expected-value",
    Summary = "Apply expected value concepts to solve advanced probability problems and explore applications in finance, insurance, economics, machine learning, artificial intelligence, and decision-making.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Binomial Distribution
// ==========================================================

new Lesson
{
    TopicId = topics["Binomial Distribution"].Id,
    Title = "Introduction to Binomial Distribution",
    Slug = "introduction-to-binomial-distribution",
    Summary = "Learn the fundamentals of the binomial distribution, understand Bernoulli trials, and explore how it models the probability of repeated independent events.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Binomial Distribution"].Id,
    Title = "Calculating Binomial Probabilities",
    Slug = "calculating-binomial-probabilities",
    Summary = "Explore the binomial probability formula, calculate probabilities for a fixed number of trials, and solve practical problems involving discrete random variables.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Binomial Distribution"].Id,
    Title = "Applications and Practice of Binomial Distribution",
    Slug = "applications-and-practice-of-binomial-distribution",
    Summary = "Apply binomial distribution concepts to solve advanced probability problems and explore applications in quality control, genetics, finance, machine learning, medicine, and statistical analysis.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},// ==========================================================
// Normal Distribution
// ==========================================================

new Lesson
{
    TopicId = topics["Normal Distribution"].Id,
    Title = "Introduction to Normal Distribution",
    Slug = "introduction-to-normal-distribution",
    Summary = "Learn the fundamentals of the normal distribution, understand the bell-shaped curve, and explore why it is one of the most important probability distributions in statistics.",
    Content = "",
    Difficulty = DifficultyLevel.Begineer,
    ReadingTimeMinutes = 10,
    IsPublished = true,
    DisplayOrder = 1,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Normal Distribution"].Id,
    Title = "Properties and Calculations of Normal Distribution",
    Slug = "properties-and-calculations-of-normal-distribution",
    Summary = "Explore the properties of the normal distribution, standard normal distribution, z-scores, and solve probability problems using distribution tables.",
    Content = "",
    Difficulty = DifficultyLevel.Intermediate,
    ReadingTimeMinutes = 15,
    IsPublished = true,
    DisplayOrder = 2,
    ThumbnailUrl = ""
},

new Lesson
{
    TopicId = topics["Normal Distribution"].Id,
    Title = "Applications and Practice of Normal Distribution",
    Slug = "applications-and-practice-of-normal-distribution",
    Summary = "Apply normal distribution concepts to solve advanced statistical problems and explore applications in finance, quality control, medicine, artificial intelligence, machine learning, and scientific research.",
    Content = "",
    Difficulty = DifficultyLevel.Advance,
    ReadingTimeMinutes = 20,
    IsPublished = true,
    DisplayOrder = 3,
    ThumbnailUrl = ""
},













        };

        await context.Lessons.AddRangeAsync(lessons);
        await context.SaveChangesAsync();
    }
}