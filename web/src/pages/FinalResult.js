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
    }).catch(error => { alert("Erro no servidor, por favor tente novamente mais tarde!") });
  }, []);
  return (
    <div id="page-final-result">
      <Header
        title="Campeonato de Filmes"
        subtitle="Resultado Final"
        description="
              Veja o resultado final do Campeonato de filmes de forma simples e rápida
            "
        goBack={true} />
      <div>
        <main>
          { cupResult.map((movie, index) => {
            return(
              <div key={movie.id} className="movie-result-box">
                <div className="positionResult">
                  <span>{index+1}º</span>
                </div>
                <div className="titleResult">
                  <span>{movie.titulo}</span>
                </div>
              </div>
            )
          })}
        </main>
      </div>
    </div>
  );
}


export default MovieSelection;