import React, { Component } from "react";
import Navigation from "./components/Navigation";
import "./App.css";

function App() {
  return (
    <main className="container">
      {/* <div>
        <a href="/">Index</a>
        <span class="mx-2">|</span>
        <a href="/articles">Articles</a>
      </div>
      <Switch>
        <Route path="/" component={Index} />
        <Route path="/articles" component={Articles} />
        <Route path="/articles/:id" component={ArticleDetail} />
      </Switch> */}
      <Navigation></Navigation>
    </main>
  );
}

export default App;
