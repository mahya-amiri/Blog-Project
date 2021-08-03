import React, { Component } from "react";
import { getArticles } from "../services/articlesService";
import Pagination from "./common/pagination";
import { paginate } from "../utils/paginate";

class Articles extends Component {
  state = {
    articles: getArticles(),
    pageSize: 3,
    currentPage: 1,
  };

  handleContinue = (article) => {
    console.log(article);
  };

  handlePageChange = (page) => {
    this.setState({ currentPage: page });
  };

  render() {
    const { length: count } = this.state.articles;
    const { pageSize, currentPage, articles: allArticles } = this.state;
    const articles = paginate(allArticles, currentPage, pageSize);

    return (
      <React.Fragment>
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
            {articles.map((article) => (
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
        <Pagination
          itemsCount={count}
          pageSize={pageSize}
          currentPage={currentPage}
          onPageChange={this.handlePageChange}
        ></Pagination>
      </React.Fragment>
    );
  }
}

export default Articles;
