import React, { Component } from "react";
import { getArticles } from "../services/articlesService";

class Articles extends Component {
  state = {
    articles: getArticles(),
  };

  handleContinue = (article) => {
    console.log(article);
  };

  render() {
    return (
      <table className="table" dir="rtl">
        <thead>
          <tr>
            <td>عنوان مقاله</td>
            <td>دسته بندی مقاله</td>
            <td>محتوای مقاله</td>
            <td></td>
          </tr>
        </thead>
        <tbody>
          {this.state.articles.map((article) => (
            <tr key={article.id}>
              <td>{article.title}</td>
              <td>{article.category}</td>
              <td>{article.content}</td>
              <td>
                <button
                  onClick={() => this.handleContinue(article)}
                  className="btn btn-info btn sm"
                >
                  ادامه مقاله
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }
}

export default Articles;
