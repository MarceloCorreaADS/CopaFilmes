import React from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';

import MoviesSelection from './pages/MoviesSelection';
import FinalResult from './pages/FinalResult';

function Routes(){
    return(
        <BrowserRouter>
            <Switch>
                <Route path="/" exact component={MoviesSelection} />
                <Route path="/finalResult" exact component={FinalResult} />
            </Switch>
        </BrowserRouter>
    );
}

export default Routes;