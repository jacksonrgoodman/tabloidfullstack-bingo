import React from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import Login from "./Login";
import Register from "./Register";
import Hello from "./Hello";
import TagList from "./tag/TagList";

import UserProfileList from "./UserProfileList";
import CategoryList from "./CategoryList";
import PostList from "./PostList";
import CommentList from "./CommentList";


export default function ApplicationViews({ isLoggedIn }) {

  return (

    <main>
      <Switch>
        <Route path="/" exact>
          {isLoggedIn ? <PostList /> : <Redirect to="/login" />}
        </Route>

        <Route path="/categories">
          {isLoggedIn ? <CategoryList /> : <Redirect to="/login" />}
        </Route>
        {/* <Route path="/posts">
          <PostList />
        </Route> */}

        <Route path="/comments">
          {isLoggedIn ? <CommentList /> : <Redirect to="/login" />}
        </Route>
        <Route path="/UserProfiles">
          {isLoggedIn ? <UserProfileList /> : <Redirect to="/login" />}
        </Route>

        <Route path="/login">
          <Login />
        </Route>

        <Route path="/register">
          <Register />
        </Route>

        <Route path="/tag">
          <TagList />
        </Route>

      </Switch>
    </main>

  );
};
