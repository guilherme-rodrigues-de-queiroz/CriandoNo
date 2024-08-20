using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace criandoNo
{
    public partial class Form1 : Form
    {
        No noCabeca;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            //nó cabeça está vazio?
            if(noCabeca == null)
            {
                //criando nó
                noCabeca = new No();
                //colocando valor dentro do nó
                noCabeca.Valor = numValor.Value;
                AtualizarListBox();
                return;
            }

            //criando novo nó
            No novoNo = new No();
            //colocando valor dentro do nó
            novoNo.Valor = numValor.Value;
            //cópia do nó cabeça para não perder a referência
            No proximoNo = noCabeca;

            while (true)
            {
                if(proximoNo.Proximo == null)
                {
                    //apontando um nó para outro
                    proximoNo.Proximo = novoNo;
                    //chamando função atualizarListBox
                    AtualizarListBox();
					break;
                }

                //nó cabeça (proximoNo) vai ser o proximo do nó cabeça (proximoNo)
                proximoNo = proximoNo.Proximo;
            }
        }

        //função para atualizar o listbox
		private void AtualizarListBox()
		{
            listBox1.Items.Clear();
			No proximoNo = noCabeca;
            while (proximoNo != null)
            {
				// Adiciona o valor do nó atual ('proximoNo.Valor') à lista de itens do 'ListBox'
				listBox1.Items.Add(proximoNo.Valor);
				// Avança para o próximo nó da lista
				proximoNo = proximoNo.Proximo;
            }
			numValor.Value = 0;
			numValor.Focus();
		}

		private void btnExcluir_Click(object sender, EventArgs e)
		{
            decimal delValor = numValor.Value;

            No noAtual = noCabeca;
            No noAnterior = null;

            while (noAtual != null)
            {
                // Verifica se o nó atual é igual o valor a ser removido
                if(noAtual.Valor == delValor)
                {
					// O item foi encontrado
					// Verifica se o nó atual é o primeiro da lista ('noAnterior' é nulo)
					if (noAnterior == null) // Remover o primeiro item
                    {
						// Remove o primeiro item da lista
						noCabeca = noAtual.Proximo;
                    }
                    else
                    {
						// Remove o item da lista, conectando o nó anterior ao próximo do nó atual
						noAnterior.Proximo = noAtual.Proximo;
                    }

                    AtualizarListBox();
                    return;
                }
				// Armazena o nó atual em 'noAnterior' para referência na próxima iteração
				noAnterior = noAtual;
				// Avança para o próximo nó da lista ligada
				noAtual = noAtual.Proximo;
            }
            //O item não foi encontrado
            MessageBox.Show("O item não foi encontrado na lista!");
		}

		private void btnAlterar_Click(object sender, EventArgs e)
		{
            int itemSelecionado = listBox1.SelectedIndex;

            if(itemSelecionado != -1)
            {
                // Pega o novo valor que foi dado no input
                decimal novoValor = numValor.Value;

                No noAtual = noCabeca;
				// Encontra o nó na lista que foi selecionado
				for (int i = 0; i < itemSelecionado; i++)
                {
                    noAtual = noAtual.Proximo;
                }

                // Altera o valor do nó da lista
                noAtual.Valor = novoValor;

                AtualizarListBox();
			}
            else
            {
                MessageBox.Show("Selecione um item para alterar!");
            }
		}

		private void btnRead_Click(object sender, EventArgs e)
		{
            // Pega o valor do input para buscar no listbox
            decimal lerValor = numValor.Value;
            // Define o índice do item selecionado como -1 inicialmente
            int indiceSelecionado = -1;

            // Percorre a lista
            No noAtual = noCabeca;
            int indice = 0;

            while(noAtual != null)
            {
                if(noAtual.Valor == lerValor)
                {
                    // Valor encontrado
                    indiceSelecionado = indice;
                    break;
                }

                indice++;
                noAtual = noAtual.Proximo;
            }

            // Atualiza o listbox
            if(indiceSelecionado != -1)
            {
                listBox1.SelectedIndex = indiceSelecionado;
            } 
            else
            {
                MessageBox.Show("O valor não foi encontrado na lista!");
            }
		}
	}
}
