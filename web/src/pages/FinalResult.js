import React, { useState, useEffect } from 'react';

import api from '../services/api'

import Header from '../components/Header';
import '../styles/pages/finalResult.css';


function MovieSelection(props) {
  const [cupResult, setCupResult] = useState([]);
  const params = props.location.state.selectedMovies;

  useEffect(() => {
      api.post('cup', {'movies': params}).then(response => { 
      setCupResult(response.data);
    })
  }, []);
  return (
    <div id="page-movie-selection">
      <Header
        title="Campeonato de Filmes"
        subtitle="Resultado de Final"
        description="
              Veja o resultado dfinal do Campeonato de filmes de forma simples e rápida
            "
        goBack={true} />
      <div>
        <main>
          { cupResult.map(movie => {
            return(
              <p>{movie.titulo}</p>
            )
          })}
        </main>
      </div>
    </div>
  );
}


export default MovieSelection;