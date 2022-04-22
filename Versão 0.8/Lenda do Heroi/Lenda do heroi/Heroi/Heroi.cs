﻿using System;

namespace Lenda_do_heroi
{
    internal class Heroi
    {
        private string nome { get; set; }
        private int idade { get; set; }
        private int level { get; set; }
        private string classe { get; set; }
        private Armas arma { get; set; }
        public Status status;
        private Corpo corpo { get; set; }
        public string getNome()
        {
            return nome;
        }
        public void setNome(string nome)
        {
            this.nome = nome;
        }
        public int getIdade()
        {
            return idade;
        }
        public void setIdade(int idade)
        {
            this.idade = idade;
        }
        public int getLv()
        {
            return level;
        }
        public void setLv(int Lv)
        {
            this.level = Lv;
        }

        public string getClasse()
        {
            return this.classe;
        }
        public void setClasse(string classe)
        {
            this.classe = classe;
        }
        public void setStatus(Status status)
        {
            this.status = status;
        }
        public string getArmas()
        {
            return this.arma.getNomeArmas();
        }
        public void setArmas(Armas arma)
        {
            this.arma = arma;
        }
        public void setCorpo(Corpo corpo)
        {
            this.corpo = corpo;
        }
        public void equiparArma(Armas arma)
        {
            if (this.corpo.maosbool == false)
                if (this.getClasse() == arma.getClasse())
                {
                    this.setArmas(arma);
                    Console.WriteLine("Equipada em {0}: {1}", this.corpo.maos, this.arma.getNomeArmas());
                    this.status.setVida(this.status.getVida() + this.arma.atributos.vida);
                    this.status.forca = this.status.forca + this.arma.atributos.forca;
                    this.status.agilidade = this.status.agilidade + this.arma.atributos.agilidade;
                    this.corpo.maosbool = true;
                    this.mostarCorpo();
                    this.MostraStatus();
                }
                else
                {
                    Console.WriteLine("Você não pertence a classe {0}", arma.getClasse());
                }
            else Console.WriteLine("Você possui um item equipado! {0} : {1}", this.corpo.maos,this.getArmas());
        }
        public void Desequipar(Armas arma)
        {
            if (this.corpo.maosbool == true)
            {
                Console.WriteLine("Desequipada em {0}: {1}", this.corpo.maos, this.arma.getNomeArmas());
                this.status.setVida(this.status.getVida() - this.arma.atributos.vida);
                this.status.forca = this.status.forca - this.arma.atributos.forca;
                this.status.agilidade = this.status.agilidade - this.arma.atributos.agilidade;
                this.corpo.maosbool = false;
            }
            else Console.WriteLine("Não há armas equipadas");
        }
        public void mostarCorpo()
        {
            Console.WriteLine("\n======{0}======\n{1}\n{2}\n{3}:{4}\n{5}\n{6}\n================\n",
                this.nome, this.corpo.cabeca, this.corpo.torso, this.corpo.maos, this.arma.getNomeArmas(), this.corpo.pernas, this.corpo.pes);
        }
        public void MostraStatus()
        {
            Console.WriteLine("\n======{0}======\nClasse:{1}\nVida:{2}\nMana:{3}\nForça:{4}\nDefesa:{5}\nAgilidade:{6}\nSorte:{7}\n================\n",
                this.nome,this.getClasse(),this.status.getVida(), this.status.mana, this.status.forca, this.status.defesa, this.status.agilidade, this.status.sorte);
        }
        public float ataque()
        {
            float dano = (this.status.forca + this.status.agilidade) * 1 + (new Random(DateTime.Now.Millisecond).Next(0, this.status.agilidade));
            Console.WriteLine("{0}", dano);
            return dano;
        }
        public void recebeDano(float dano)
        {
            float recebe = this.defesa() - dano;
            if (recebe < 0)
            {
                this.status.setVida(this.status.getVida() + recebe);
            }
        }
    }

}
